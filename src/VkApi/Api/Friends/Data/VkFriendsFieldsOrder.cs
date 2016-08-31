using VkApi;

namespace VkApi
{
    public enum VkFriendsFieldsOrder
    {
        /// <summary>
        /// сортировать по имени (работает только при переданном параметре fields)
        /// </summary>
        [EnumValue("name")]
        Name ,
        /// <summary>
        /// ортировать по рейтингу, аналогично тому, как друзья сортируются в разделе Мои друзья
        /// </summary>
        [EnumValue("hints")]
        Hints ,
    }
}