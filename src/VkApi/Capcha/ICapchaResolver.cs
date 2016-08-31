using System.Threading.Tasks;

namespace VkApi.Capcha
{
    public interface ICapchaResolver
    {
        Task<string> ResolveCapcha(string imgUrl);
    }
}