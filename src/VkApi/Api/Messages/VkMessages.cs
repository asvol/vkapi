using System.Threading.Tasks;

namespace VkApi
{
    public class VkMessages: VkApiBase,IVkMessages
    {
        public VkMessages(string accessToken) : base(accessToken)
        {
        }

        public Task<int> Send(string message, int? uid = null, int? chatId = null, string capchaSid = null, string capchKey = null)
        {
            return CallJsonApiDynamic<int>("messages.send", new { uid = uid, chat_id = chatId, message = message, captcha_sid = capchaSid, captcha_key = capchKey});
        }

    }
}