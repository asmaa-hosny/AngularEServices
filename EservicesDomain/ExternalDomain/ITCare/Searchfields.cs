using Newtonsoft.Json;


namespace EservicesDomain.ExternalDomain.ITCare
{
    public class Searchfields
    {
        [JsonProperty("requester.name")]
        public string name { get; set; }
    }
}
