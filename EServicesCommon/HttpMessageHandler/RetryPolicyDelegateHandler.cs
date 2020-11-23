

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EServicesCommon.HttpMessageHandler
{
    public class RetryPolicyDelegateHandler : DelegatingHandler
    {
        private readonly int _nOfTries = 3;
        public RetryPolicyDelegateHandler(int retryTimes)
        {
            _nOfTries = retryTimes;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < _nOfTries; i++)
            {
                response= await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode || response.StatusCode != System.Net.HttpStatusCode.Unauthorized || response.StatusCode != System.Net.HttpStatusCode.BadRequest || response.StatusCode != System.Net.HttpStatusCode.UnprocessableEntity) return response;
            }
            return response;
               
        }

    }
}
