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
        /// ���� �������
        /// </summary>
        public string AccessToken { get; private set; }
        /// <summary>
        /// ������������� ������������
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// ����� �����
        /// </summary>
        public TimeSpan ExpiresIn { get; set; }
        /// <summary>
        /// ������������� ����������
        /// </summary>
        public string AppId { get; set; }
    }
}