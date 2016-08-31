using System;
using System.Linq;
using System.Threading.Tasks;
using VkApi;

namespace VkApi
{
    public class VkFriendsApi : VkApiBase, IVkFriendsApi
    {
        public VkFriendsApi(string accessToken)
            : base(accessToken)
        {
            
        }

        #region Implementation of IVkFriendsApi

        public async Task<int[]> GetIds(int? uid = null, int? count = null, int? offset = null, int? lid = null,VkFriendsFieldsOrder? order = null)
        {
            return await CallJsonApiDynamic<int[]>("friends.get", new { uid = uid, count = count, offset = offset, lid = lid, order = order.HasValue ? order.Value.GetEnumValue() : null });
        }

       

        public async Task<VkUserResult[]> Get(int? uid = null, int? count = null, int? offset = null, int? lid = null, VkFriendsFieldsOrder? order = null, params VkUserFieldsEnum[] fieldsEnum)
        {
            return await CallJsonApiDynamic<VkUserResult[]>("friends.get", new { uid = uid, count = count, offset = offset, lid = lid, order = order.HasValue ? order.Value.GetEnumValue() : null, fields = string.Join(",", fieldsEnum.Select(_ => _.GetEnumValue())) });
        }

        public Task<VkUserResult[]> GetAllInfo(int? uid = null, int? count = null, int? offset = null, int? lid = null, VkFriendsFieldsOrder? order = null)
        {
            return Get(uid, count, offset, lid, order, Enum.GetValues(typeof(VkUserFieldsEnum)).Cast<VkUserFieldsEnum>().ToArray());
        }

        public async Task<VkAddFriendsResultEnum> Add(int uid, string text = null, string capchasid = null, string capchakey = null)
        {
            var res = await CallJsonApiDynamic<int>("friends.add", new { uid, text, captcha_sid = capchasid, captcha_key  = capchakey});
            switch (res)
            {
                case 1:
                    return VkAddFriendsResultEnum.SuccessRequest;
                case 2:
                    return VkAddFriendsResultEnum.SucessAdd;
                case 4:
                    return VkAddFriendsResultEnum.AlreadyRequest;
                default:
                    return VkAddFriendsResultEnum.Unknown;
            }
        }

        #endregion
    }
}