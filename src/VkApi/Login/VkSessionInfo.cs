using System;

namespace VkApi
{
    public class VkSessionInfo
    {
        public VkSessionInfo(string accessToken, string expiresIn, string userID,string appId)
        {
            AccessToken = accessToken;
            UserID = userID;
            AppId = appId;
            ExpiresIn = TimeSpan.FromSeconds(int.Parse(expiresIn));
        }

        /// <summary>
        /// Ключ доступа
        /// </summary>
        public string AccessToken { get; private set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Время жизни
        /// </summary>
        public TimeSpan ExpiresIn { get; set; }
        /// <summary>
        /// Идентификатор приложения
        /// </summary>
        public string AppId { get; set; }
    }
}