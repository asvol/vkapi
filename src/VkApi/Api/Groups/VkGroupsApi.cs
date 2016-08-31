using System.Collections.Generic;
using System.Threading.Tasks;
using VkApi;

namespace VkApi
{
    


    public class VkGroupsApi : VkApiBase, IVkGroupsApi
    {
        public VkGroupsApi(string accessToken) : base(accessToken)
        {
        }

        public Task<VkGroupMembersResult> GetMembers(int gid, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc)
        {
            return CallJsonApiDynamic<VkGroupMembersResult>("groups.getMembers", new { gid = gid, count = count, offset = offset, sort = sort.GetEnumValue() });
        }

        public Task<VkGroupMembersResult> GetMembers(string gidScreenName, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc)
        {
            return CallJsonApiDynamic<VkGroupMembersResult>("groups.getMembers", new { gid = gidScreenName, count = count, offset = offset, sort = sort.GetEnumValue() });
        }
    }
}