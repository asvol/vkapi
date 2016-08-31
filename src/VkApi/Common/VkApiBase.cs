using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;

namespace VkApi
{
    public class VkApiBase
    {
        private readonly string _accessToken;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private const string ApiUrl = "https://api.vk.com/method/";

        protected VkApiBase(string accessToken)
        {
            _accessToken = accessToken;
        }

        protected async Task<string> CallJsonApi(string method, IEnumerable<KeyValuePair<string, string>> methodArgs = null)
        {
            var args = (methodArgs == null) ?
                new[] { new KeyValuePair<string, string>("access_token", _accessToken) } :
                methodArgs.Concat(new[] { new KeyValuePair<string, string>("access_token", _accessToken) });

            _logger.Trace("VkApi.{0}({1})", method, string.Join(", ", args.Select(_ => string.Concat(_.Key, "=", _.Value))));

            using (var client = new HttpClient())
            {
                var res = await client.PostAsync(ApiUrl + method, new FormUrlEncodedContent(args));
                res.EnsureSuccessStatusCode();
                return await res.Content.ReadAsStringAsync();
            }
        }

        protected async Task<T> CallJsonApi<T>(string method, IEnumerable<KeyValuePair<string, string>> methodArgs = null)
        {
            var json = await CallJsonApi(method, methodArgs);
            var result = await JsonConvert.DeserializeObjectAsync<VkResultBase<T>>(json);
            if (result.Error != null)
            {
                switch (result.Error.ErrorCode)
                {
                    case 14:
                        throw new VkRequestCapchaNeededException(result.Error.ErrorMsg, result.Error);
                    case 6:
                        throw new VkRequestTooManyRequestsPerSecond(result.Error.ErrorMsg, result.Error);
                    default:
                        throw new VkRequestErrorException(result.Error.ErrorMsg, result.Error);
                }
            }
            return result.Response;
        }

        protected async Task<T> CallJsonApiDynamic<T>(string method, object args)
        {
            var argsDict = new Dictionary<string, string>();
            if (args != null)
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(args))
                {
                    var value = propertyDescriptor.GetValue(args);
                    if (value != null)
                        argsDict.Add(propertyDescriptor.Name, value.ToString());
                }
            }
            return await CallJsonApi<T>(method, argsDict);
        }
    }

    
}