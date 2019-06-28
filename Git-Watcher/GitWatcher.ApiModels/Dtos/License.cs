using Newtonsoft.Json;

namespace Git_Watcher_Client.Dto
{
    public class License
    {
        [JsonConstructor]
        public License()
        {
            
        }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("url")] public string Url { get; set; }
    }
}