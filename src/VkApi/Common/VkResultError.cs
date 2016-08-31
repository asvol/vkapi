using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkApi
{
    public class VkResultError
    {
        [JsonProperty("captcha_sid")]
        public string CaptchaSid { get; set; }

        [JsonProperty("captcha_img")]
        public string CaptchaImg { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("request_params")]
        public List<VkRequestParam> RequestParams { get; set; }
    }
}