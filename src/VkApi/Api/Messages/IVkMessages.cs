using System.Threading.Tasks;

namespace VkApi
{
    public interface IVkMessages
    {
        Task<int> Send(string message, int? uid = null, int? chatId = null, string capchaSid = null, string capchKey = null);
        
    }
}