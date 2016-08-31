using System;
using System.Linq;
using System.Threading.Tasks;
using VkApi;

namespace VkApi
{
    public class VkUsersApi : VkApiBase, IVkUsersApi
    {
        public VkUsersApi(string accessToken) : base(accessToken)
        {
        }

        public Task<VkUserResult[]> Get(int[] uids, VkNameCase nameCase = VkNameCase.Nom, params VkUserFieldsEnum[] fields)
        {
            var uidsStr = string.Join(",", uids);
            return CallJsonApiDynamic<VkUserResult[]>("users.get", new { uids = uidsStr, name_case = nameCase.GetEnumValue(), fields = string.Join(",", fields.Select(_ => EnumHelper.GetEnumValue(_))) });
        }

        public Task<VkUserResult[]> Get(string[] screenNames, VkNameCase nameCase = VkNameCase.Nom, params VkUserFieldsEnum[] fields)
        {
            var uidsStr = string.Join(",", screenNames);
            return CallJsonApiDynamic<VkUserResult[]>("users.get", new { uids = uidsStr, name_case = nameCase.GetEnumValue(), fields = string.Join(",", fields.Select(_ => _.GetEnumValue())) });
        }

        public Task<VkUserResult[]> GetAllInfo(string[] screenNames, VkNameCase nameCase = VkNameCase.Nom)
        {
            return Get(screenNames, nameCase, Enum.GetValues(typeof (VkUserFieldsEnum)).Cast<VkUserFieldsEnum>().ToArray());
        }

        public Task<VkUserResult[]> GetAllInfo(int[] uids, VkNameCase nameCase = VkNameCase.Nom)
        {
            return Get(uids, nameCase, Enum.GetValues(typeof(VkUserFieldsEnum)).Cast<VkUserFieldsEnum>().ToArray());
        }

       
    }
}