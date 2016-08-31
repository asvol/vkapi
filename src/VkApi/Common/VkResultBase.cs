using Newtonsoft.Json;

namespace VkApi
{
    public class VkResultBase<T>
    {
        [JsonProperty("response")]
        public T Response { get; set; }
        [JsonProperty("error")]
        public VkResultError Error { get; set; }

    }
}