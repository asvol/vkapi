using System.Collections.Generic;

namespace VkApi
{
    
    public class VkRequestParam
    {
        public VkRequestParam()
        {
            
        }

        public VkRequestParam(string key,string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}