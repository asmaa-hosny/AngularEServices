using EservicesDomain.ExternalDomain.Common;
using EservicesDomain.ExternalDomain.UAC;
using Microsoft.AspNetCore.JsonPatch;
using System.Net.Http;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IRestWrapper
    {
        Task<TOut> Get<TOut>(string clientName, string link);

        Task<TOut> Post<TIn, TOut>(string clientName, string link, TIn item);

        Task<TOut> PostItemWithFile<TIn, TOut>(string clientName, string link, TIn item, HttpContent formContent = null);

        Task<TOut> Put<TIn, TOut>(string clientName, string link, TIn item);

        Task<TOut> Get<TIn, TOut>(string clientName, string link, TIn item);

        Task<TOut> GetWithStream<TOut>(HttpClient client, string link);

        Task<TOut> PostWithReadStream<TIn, TOut>(HttpClient client, string link, TIn objectToPost);

        Task<TOut> PutWithReadStream<TIn, TOut>(HttpClient client, string link, TIn objectToUpdate, string mediaTypeHeaderValue = "application/json");

        Task<TOut> PostAndReadWithStream<TIn, TOut>(HttpClient client, string link, TIn objectToPost, string mediaTypeHeaderValue = "application/json");

        Task<TOut> PatchWithReadStream<TIn, TOut>(HttpClient client, string link, JsonPatchDocument<EditConsultationDataViewModel> jsonPatch, string jobId , string mediaTypeHeaderValue = "application/json" );

        Task GetAccessToken(HttpClient client, string link);

        string SerilizeObject<T>(T item, bool isRegular = true);



    }
}
