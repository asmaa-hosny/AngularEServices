using EServicesWithAngular.Domain.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EServicesWithAngular.DAL
{
    public class RestAPICaller
    {
        public static async Task<TOut> Get<TOut>(string clientName, string link)
        {
            var client = StaticClass.HttpClientFactory.CreateClient(clientName);
            var response = await client.GetAsync(client.BaseAddress + link).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    var responseString = JsonConvert.DeserializeObject(content);
                    if ((bool)(responseString.GetType().GetProperty("HasValues").GetValue(responseString)))
                    {
                        var wrapper = JsonConvert.DeserializeObject<TOut>(content, new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,

                        });
                        return wrapper;
                    }
                }
            }
            return default(TOut);
        }


        public static async Task<TOut> Post<TIn, TOut>(string clientName, string link, TIn item)
        {
            var client = StaticClass.HttpClientFactory.CreateClient(clientName);

            var itemSerilized = JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            var response = await client.PostAsync($"{client.BaseAddress + link}{itemSerilized}", null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);

            var result = JsonConvert.DeserializeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }

        public static async Task<TOut> Put<TIn, TOut>(string clientName, string link, TIn item)
        {
            var client = StaticClass.HttpClientFactory.CreateClient(clientName);

            var itemSerilized = JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            var response = await client.PutAsync($"{client.BaseAddress + link}{itemSerilized}", null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);

            var result = JsonConvert.DeserializeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }

        public static async Task<TOut> Put<TOut>(string clientName, string link)
        {
            var client = StaticClass.HttpClientFactory.CreateClient(clientName);

            var response = await client.PutAsync($"{client.BaseAddress + link}", null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(TOut);

            var result = JsonConvert.DeserializeObject<TOut>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }
    }
}
