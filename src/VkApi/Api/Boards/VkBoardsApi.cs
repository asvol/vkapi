using System.Threading.Tasks;

namespace VkApi
{
    public class VkBoardsApi : VkApiBase, IVkBoardsApi
    {
        public VkBoardsApi(string accessToken)
            : base(accessToken)
        {
        }

        public Task<VkBoardsGetTopicsResult> Get(int gid, int[] tids = null, bool extended = false, int? order = null, int? offset = null, int? count = null, int? preview = null, int? previewLength = null)
        {
            return CallJsonApiDynamic<VkBoardsGetTopicsResult>("board.getTopics", new { gid = gid, tids = tids, extended = extended ? 0 : 1, order = order, offset = offset, count = count });
        }
    }
}