
using System.Net.Http;


namespace EServicesApplication.Clients
{
    public class UACClient
    {
        public HttpClient Client { get; }

        public UACClient(HttpClient client)
        {
            Client = client;
        }
    }
}

