using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using VkApi.Capcha;

namespace VkApi
{
    public static class VkApiExtentions
    {
        public static async Task<int?> Send(this IVkMessages src, ICapchaResolver resolver, string message, int? uid = null, int? chatId = null)
        {
            var tryAgainWithCapcha = false;
            string sid = null;
            string img = null;
            const int maxAttempt = 5;
            var currentAttempt = 0;

            while (currentAttempt < maxAttempt)
            {
                currentAttempt++;
                try
                {
                    if (tryAgainWithCapcha)
                    {
                        var capcha = await resolver.ResolveCapcha(img);
                        await src.Send(message, uid, chatId, sid, capcha);
                    }
                    else
                    {
                        return await src.Send(message, uid, chatId);    
                    }

                }
                catch (VkRequestCapchaNeededException ex)
                {
                    sid = ex.Error.CaptchaSid;
                    img = ex.Error.CaptchaImg;
                    tryAgainWithCapcha = true;
                }
            }
            return null;
        }

        public static async Task<VkAddFriendsResultEnum> Add(this IVkFriendsApi src, ICapchaResolver resolver, int uid, string text = null)
        {
            var tryAgainWithCapcha = false;
            string sid = null;
            string img = null;
            const int maxAttempt = 5;
            var currentAttempt = 0;

            while (currentAttempt<maxAttempt)
            {
                currentAttempt++;
                try
                {
                    if (tryAgainWithCapcha)
                    {
                        var capcha = await resolver.ResolveCapcha(img);
                        return await src.Add(uid, text, sid, capcha);
                    }
                    else
                    {
                        return await src.Add(uid, text);    
                    }
                    
                }
                catch (VkRequestCapchaNeededException ex)
                {
                    sid = ex.Error.CaptchaSid;
                    img = ex.Error.CaptchaImg;
                    tryAgainWithCapcha = true;
                }
            }
            return VkAddFriendsResultEnum.Unknown;
        }


        /// <summary>
        /// Возвращает всех друзей группы за один раз
        /// </summary>
        /// <param name="src"> </param>
        /// <param name="gid"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static async Task<int[]> GetAllMembers(this IVkGroupsApi src, int gid, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc)
        {
            const int maxPartSize = 1000;
            var offset = 0;
            var result = new List<int>();
            while (true)
            {
                try
                {
                    var vkUserInfo = await src.GetMembers(gid, sort: sort, offset: offset, count: maxPartSize);
                    if (vkUserInfo.Users.Length == 0) break;
                    result.AddRange(vkUserInfo.Users);
                    offset += maxPartSize;
                }
                catch (VkRequestTooManyRequestsPerSecond ex)
                {
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                }
                
            }
            return result.ToArray();
        }

        /// <summary>
        /// Возвращает всех друзей группы за один раз
        /// </summary>
        /// <param name="src"> </param>
        /// <param name="gidScreenName"> </param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static async Task<int[]> GetAllMembers(this IVkGroupsApi src, string gidScreenName, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc)
        {
            const int maxPartSize = 1000;
            var offset = 0;
            var result = new List<int>();
            while (true)
            {
                try
                {
                    var vkUserInfo = await src.GetMembers(gidScreenName, sort: sort, offset: offset, count: maxPartSize);
                    if (vkUserInfo.Users.Length == 0) break;
                    result.AddRange(vkUserInfo.Users);
                    offset += maxPartSize;
                }
                catch (VkRequestTooManyRequestsPerSecond ex)
                {
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    
                    break;
                }
                
            }
            return result.ToArray();
        }
    }
}