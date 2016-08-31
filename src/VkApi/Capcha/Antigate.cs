using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VkApi.Capcha
{
    

    public class Antigate : ICapchaResolver
    {
        private readonly string _key;
        private const string Base64Url = "http://antigate.com/in.php";
        private const string GetCapchaStateUrl = "http://antigate.com/res.php?key={0}&action=get&id={1}";

        public Antigate(string key)
        {
            _key = key;
        }

        private static async Task<string> GetBase64(string url)
        {
            using (var client = new HttpClient())
            {
                var data = await client.GetByteArrayAsync(url);
                return Convert.ToBase64String(data);    
            }
        }

        private static async Task<string> Capcha(string base64,string key)
        {
            using (var client = new HttpClient())
            {
                var par = new Dictionary<string, string> {{"method", "base64"}, {"key", key}, {"body", base64}};
                var content = new FormUrlEncodedContent(par);
                var res = await client.PostAsync(Base64Url, content);
                var resultStr = await res.Content.ReadAsStringAsync();
                if (!resultStr.Contains("OK|"))
                    throw new Exception(resultStr);
                resultStr = resultStr.Replace("OK|","");
                while (true)
                {
                    var capchRes = await client.GetStringAsync(string.Format(GetCapchaStateUrl, key, resultStr));
                    if (capchRes.Contains("OK|"))
                    {
                        return capchRes.Replace("OK|", "");
                    }
                    if (!capchRes.Contains("CAPCHA_NOT_READY"))
                    {
                        throw new Exception(capchRes);
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }
            }
        }

        public async Task<string> ResolveCapcha(string imgUrl)
        {
            var cap = await GetBase64(imgUrl);
            return await Capcha(cap, _key);
        }
    }
}
