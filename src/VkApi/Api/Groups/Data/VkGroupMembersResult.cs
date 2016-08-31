using Newtonsoft.Json;

namespace VkApi
{
    public class VkGroupMembersResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("users")]
        public int[] Users { get; set; }
    }
}