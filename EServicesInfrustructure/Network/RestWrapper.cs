using CommonLibrary.Logging;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesCommon.DI;
using EservicesDomain.ExternalDomain.Common;
using EservicesDomain.ExternalDomain.UAC;
using Marvin.StreamExtensions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EServicesInfrustructure.Network
{
    public class RestWrapper : IRestWrapper
    {
        private readonly CancellationTokenSource _cancellationTokenSource =
          new CancellationTokenSource();

        private readonly IHttpClientFactory _httpClientFactory;
        public ILoggerManager _logger;
        public string Token { get; set; }

        public RestWrapper(IHttpClientFactory httpClientFactory, ILoggerManager logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;

        }

        public string SerilizeObject<T>(T item, bool isRegular = true)
        {
            if (isRegular)
                return JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            else
                return JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        private T DesrilizeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        private object DesrilizeObject(string json)
        {
            return JsonConvert.DeserializeObject(json, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }


        public async Task<TOut> Get<TOut>(string clientName, string link)
        {
            var client = _httpClientFactory.CreateClient(clientName);
            _logger.LogDebug($"Get request to service URL : {client.BaseAddress + link}");
            var response = await client.GetAsync(client.BaseAddress + link).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogDebug($"Success result from the service {client.BaseAddress + link}");
                var responseString = DesrilizeObject(content);
                if ((bool)(responseString.GetType().GetProperty("HasValues").GetValue(responseString)))
                {
                    var wrapper = DesrilizeObject<TOut>(content);
                    return wrapper;
                }
            }
            return default(TOut);
        }

        public async Task<TOut> Get<TIn, TOut>(string clientName, string link, TIn item)
        {
            var client = _httpClientFactory.CreateClient(clientName);
            _logger.LogDebug($"Get request to service URL : {client.BaseAddress + link}", item);
            var itemSerilized = SerilizeObject(item, true);
            var response = await client.GetAsync($"{client.BaseAddress + link}{itemSerilized}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogDebug($"Success result from the service {client.BaseAddress + link}", item);
                var responseString = JsonConvert.DeserializeObject(content);
                if ((bool)(responseString.GetType().GetProperty("HasValues").GetValue(responseString)))
                {
                    var wrapper = DesrilizeObject<TOut>(content);
                    return wrapper;
                }
            }
            return default(TOut);
        }



        public async Task<TOut> Post<TIn, TOut>(string clientName, string link, TIn item)
        {
            var client = _httpClientFactory.CreateClient(clientName);
            _logger.LogDebug($"Get request to service URL : {client.BaseAddress + link}", item);
            var itemSerilized = SerilizeObject(item, true);

            var response = await client.PostAsync($"{client.BaseAddress + link}{itemSerilized}", null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);

            _logger.LogDebug($"Success result from the service {client.BaseAddress + link}", item);
            var result = DesrilizeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }

        public async Task<TOut> PostItemWithFile<TIn, TOut>(string clientName, string link, TIn item, HttpContent formContent = null)
        {
            var client = _httpClientFactory.CreateClient(clientName);
            _logger.LogDebug($"Get request to service URL : {client.BaseAddress + link}", item);
            var itemSerilized = SerilizeObject(item);

            var response = await client.PostAsync($"{link}{itemSerilized}", formContent).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);

            _logger.LogDebug($"Success result from the service {client.BaseAddress + link}", item);

            var result = DesrilizeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }

        public async Task<TOut> Put<TIn, TOut>(string clientName, string link, TIn item)
        {
            var client = _httpClientFactory.CreateClient(clientName);
            _logger.LogDebug($"Get request to service URL : {client.BaseAddress + link}", item);
            var itemSerilized = SerilizeObject(item, true);

            var response = await client.PutAsync($"{client.BaseAddress + link}{itemSerilized}", null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);
            _logger.LogDebug($"Success result from the service {client.BaseAddress + link}", item);
            var result = DesrilizeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }


        public async Task GetAccessToken(HttpClient client, string link)
        {
            if (string.IsNullOrEmpty(Token))
            {
                var response = await GetWithStream<TokenModel>(client, link);
                Token = response.Token;
            }
            if (client.DefaultRequestHeaders.Authorization ==null)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

        }

        public async Task<TOut> GetWithStream<TOut>(HttpClient client, string link)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get, link);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                    await CheckStatusCode(link, client, response);
                }

                var stream = await response.Content.ReadAsStreamAsync();

                return stream.ReadAndDeserializeFromJson<TOut>();

            }
        }

        public async Task<TOut> PostWithReadStream<TIn, TOut>(HttpClient client, string link, TIn objectToPost)
        {
            _logger.LogDebug("PostWithReadStream : objectToPost ", (objectToPost));

            var serilizedItem = SerilizeObject(objectToPost);
            _logger.LogDebug("PostWithReadStream : serilizedItem ", (serilizedItem));

            var request = new HttpRequestMessage(
                HttpMethod.Post, link);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serilizedItem);

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _logger.LogDebug("PostWithReadStream : request ", (request.Content));
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                _logger.LogDebug("PostWithReadStream : response ", (response));
                if (!response.IsSuccessStatusCode)
                {
                    await CheckStatusCode(link, client, response);
                }
                _logger.LogDebug("response.Content : request ", (response.Content));
                var stream = await response.Content.ReadAsStreamAsync();
             
                return stream.ReadAndDeserializeFromJson<TOut>();

            }


        }


        public async Task<TOut> PutWithReadStream<TIn, TOut>(HttpClient client, string link, TIn objectToUpdate, string mediaTypeHeaderValue = "application/json" )
        {
            var serilizedItem = SerilizeObject(objectToUpdate);

            var request = new HttpRequestMessage(
                HttpMethod.Put, link);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            request.Content = new StringContent(serilizedItem);

            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaTypeHeaderValue);

            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                    await CheckStatusCode(link, client, response);
                }

                var stream = await response.Content.ReadAsStreamAsync();

                return stream.ReadAndDeserializeFromJson<TOut>();

            }
        }

        public async Task<TOut> PatchWithReadStream<TIn, TOut>(HttpClient client, string link, JsonPatchDocument<EditConsultationDataViewModel> jsonPatch, string jobId , string mediaTypeHeaderValue = "application/json")
        {
            _logger.LogDebug("PatchWithReadStream : client , link , jsonPatch ", (client, link , jsonPatch));
            var serilizedItem = SerilizeObject(jsonPatch);
            _logger.LogDebug("PatchWithReadStream : serilizedItem ", (serilizedItem));

            link = link.Replace("jobId", jobId);
            _logger.LogDebug("PatchWithReadStream : link ", (link));

            var request = new HttpRequestMessage(
                HttpMethod.Patch, link);
            
            

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serilizedItem);
            _logger.LogDebug("PatchWithReadStream : request.Content ", (request.Content));

            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaTypeHeaderValue);
            _logger.LogDebug("PatchWithReadStream : request.Content.Headers.ContentType ", (request.Content.Headers.ContentType));
            _logger.LogDebug("PatchWithReadStream : request", (request));
            _logger.LogDebug("PatchWithReadStream : HttpCompletionOption.ResponseHeadersRead", (HttpCompletionOption.ResponseHeadersRead));

            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead ))
            {
                _logger.LogDebug("PatchWithReadStream : response", (response));
                if (!response.IsSuccessStatusCode)
                {
                    await CheckStatusCode(link, client, response);
                }

                var stream = await response.Content.ReadAsStreamAsync();
  

                return stream.ReadAndDeserializeFromJson<TOut>();
               


            }
        }


        public async Task<TOut> PostAndReadWithStream<TIn, TOut>(HttpClient client, string link, TIn objectToPost, string mediaTypeHeaderValue = "application/json")
        {

            var memoryContentStream = new MemoryStream();
            memoryContentStream.SerializeToJsonAndWrite(objectToPost, new UTF8Encoding(), 1024, true);
            //set out memory stream to 0 ,as that is what we start streaming it from
            memoryContentStream.Seek(0, SeekOrigin.Begin);

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, link))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var streamContent = new StreamContent(memoryContentStream))
                {
                    request.Content = streamContent;
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaTypeHeaderValue);

                    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            await CheckStatusCode(link, client, response);
                        }

                        var stream = await response.Content.ReadAsStreamAsync();

                        return stream.ReadAndDeserializeFromJson<TOut>();

                    }
                }
            }
        }

        private async Task CheckStatusCode(string link, HttpClient client, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    _logger.LogDebug($"Unauthorized access from the service {client.BaseAddress + link}");
                    throw new HttpRequestException($"Unauthorized access from the service {client.BaseAddress + link}");

                case HttpStatusCode.NotFound:
                    _logger.LogDebug($"Service Not Found ,When calling {client.BaseAddress + link}");
                    throw new HttpRequestException($"Not found when calling the service {client.BaseAddress + link}");

                case HttpStatusCode.UnprocessableEntity:
                    var errorstream = await response.Content.ReadAsStreamAsync();
                    var validationerror = errorstream.ReadAndDeserializeFromJson();
                    _logger.LogDebug($"UnprocessableEntity ,When calling {client.BaseAddress + link}", validationerror);
                    throw new HttpRequestException($"Unprocessable Entity from the service {client.BaseAddress + link}");

            }
            response.EnsureSuccessStatusCode();
        }

        private static HttpRequestMessage PrepareHttpwithContentRequest(HttpMethod httpMethod, string link, string itemSerilized)
        {
            var request = new HttpRequestMessage(httpMethod, link);
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(itemSerilized);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return request;
        }

        private static HttpRequestMessage PrepareHttpRequest(HttpMethod httpMethod, string link)
        {
            var request = new HttpRequestMessage(httpMethod, link);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }



    }

}

