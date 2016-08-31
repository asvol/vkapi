using VkApi;

namespace VkApi
{
    public enum VkScope
    {
        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления
        /// </summary>
        [EnumValue("notify")]
        Notify,

        /// <summary>
        /// Доступ к друзьям
        /// </summary>
        [EnumValue("friends")]
        Friends,

        /// <summary>
        /// Доступ к фотографиям.
        /// </summary>
        [EnumValue("photos")]
        Photos,

        /// <summary>
        /// Доступ к аудиозаписям.
        /// </summary>
        [EnumValue("audio")]
        Audio,

        /// <summary>
        /// Доступ к видеозаписям.
        /// </summary>
        [EnumValue("video")]
        Video,

        /// <summary>
        /// Доступ к документам.
        /// </summary>
        [EnumValue("docs")]
        Docs,

        /// <summary>
        /// Доступ заметкам пользователя.
        /// </summary>
        [EnumValue("notes")]
        Notes,

        /// <summary>
        /// Доступ к wiki-страницам.
        /// </summary>
        [EnumValue("pages")]
        Pages,

        /// <summary>
        /// Доступ к статусу пользователя.
        /// </summary>
        [EnumValue("status")]
        Status,

        /// <summary>
        /// Доступ к предложениям (устаревшие методы).
        /// </summary>
        [EnumValue("offers")]
        Offers,

        /// <summary>
        /// Доступ к вопросам (устаревшие методы)
        /// </summary>
        [EnumValue("questions")]
        Questions,

        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной.
        /// </summary>
        [EnumValue("wall")]
        Wall,

        /// <summary>
        /// Доступ к группам пользователя.
        /// </summary>
        [EnumValue("groups")]
        Groups,

        /// <summary>
        /// (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями.
        /// </summary>
        [EnumValue("messages")]
        Messages,

        /// <summary>
        /// Доступ к оповещениям об ответах пользователю.
        /// </summary>
        [EnumValue("notifications")]
        Notifications,

        /// <summary>
        /// Доступ к статистике групп и приложений пользователя, администратором которых он является.
        /// </summary>
        [EnumValue("stats")]
        Stats,

        /// <summary>
        /// Доступ к расширенным методам работы с рекламным API.
        /// </summary>
        [EnumValue("ads")]
        Ads,

        /// <summary>
        /// Доступ к API в любое время со стороннего сервера.
        /// </summary>
        [EnumValue("offline")]
        Offline,

        /// <summary>
        /// Возможность осуществлять запросы к API без HTTPS.
        /// </summary>
        [EnumValue("nohttps")]
        Nohttps,

    }
}
