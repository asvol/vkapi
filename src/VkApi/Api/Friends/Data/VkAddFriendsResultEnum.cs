namespace VkApi
{
    public enum VkAddFriendsResultEnum
    {
        
        Unknown,
        /// <summary>
        /// В случае успешной отправки заявки на добавление в друзья возвращает 1. 
        /// </summary>
        SuccessRequest,
        /// <summary>
        /// В случае успешного одобрения заявки на добавление в друзья в возвращает 2. 
        /// </summary>
        SucessAdd,
        /// <summary>
        /// В случае повторной отправки заявки возвращает 4. 
        /// </summary>
        AlreadyRequest,

    }
}