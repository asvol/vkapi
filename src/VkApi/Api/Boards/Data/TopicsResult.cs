using Newtonsoft.Json;

namespace VkApi
{
    public class TopicsResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonProperty("tid")]
        public int Tid { get; set; }

        /// <summary>
        /// заголовок
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// дата создания (в формате unix timestamp)
        /// </summary>
        [JsonProperty("created")]
        public long Created { get; set; }

        /// <summary>
        /// идентификатор пользователя, создавшего тему
        /// </summary>
        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// идентификатор пользователя, оставившего последнее сообщение
        /// </summary>
        [JsonProperty("updated_by")]
        public int UpdatedBy { get; set; }

        /// <summary>
        /// 1, если тема является закрытой (в ней нельзя оставлять сообщения)
        /// </summary>
        [JsonProperty("is_closed")]
        public int IsClosed { get; set; }

        /// <summary>
        /// 1, если тема является прилепленной (находится в начале списка тем)
        /// </summary>
        [JsonProperty("is_fixed")]
        public int IsFixed { get; set; }

        /// <summary>
        /// число сообщений в теме.
        /// </summary>
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// (только если в поле preview указан флаг 1) - текст первого сообщения.
        /// </summary>
        [JsonProperty("first_comment")]
        public string FirstComment { get; set; }

        /// <summary>
        /// (только если в поле preview указан флаг 2) - текст последнего сообщения.
        /// </summary>
        [JsonProperty("last_comment")]
        public string LastComment { get; set; }

    }
}