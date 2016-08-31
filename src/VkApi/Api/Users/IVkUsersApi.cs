using System.Threading.Tasks;

namespace VkApi
{
    public interface IVkUsersApi
    {
        /// <summary>
        /// Возвращает расширенную информацию о пользователях. 
        /// </summary>
        /// <param name="uids">перечисленные через запятую ID пользователей. Максимум 1000 пользователей.</param>
        /// <param name="nameCase">падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom.</param>
        /// <param name="fields">перечисленные через запятую поля анкет, необходимые для получения. Доступные значения: uid, first_name, last_name, nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, rate, contacts, education, online, counters.</param>
        /// <returns></returns>
        Task<VkUserResult[]> Get(int[] uids,VkNameCase nameCase = VkNameCase.Nom, params VkUserFieldsEnum[] fields);

        /// <summary>
        /// Возвращает расширенную информацию о пользователях. 
        /// </summary>
        /// <param name="screenNames">перечисленные  короткие имена (screen_name). Максимум 1000 пользователей.</param>
        /// <param name="nameCase">падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom.</param>
        /// <param name="fields">перечисленные через запятую поля анкет, необходимые для получения. Доступные значения: uid, first_name, last_name, nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, rate, contacts, education, online, counters.</param>
        /// <returns></returns>
        Task<VkUserResult[]> Get(string[] screenNames, VkNameCase nameCase = VkNameCase.Nom, params VkUserFieldsEnum[] fields);

        /// <summary>
        /// Возвращает всю возможную(все поля) информацию о пользователях. 
        /// </summary>
        /// <param name="screenNames">перечисленные  короткие имена (screen_name). Максимум 1000 пользователей.</param>
        /// <param name="nameCase">падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom.</param>
        /// <returns></returns>
        Task<VkUserResult[]> GetAllInfo(string[] screenNames, VkNameCase nameCase = VkNameCase.Nom);

        /// <summary>
        /// Возвращает всю возможную(все поля) информацию о пользователях. 
        /// </summary>
        /// <param name="uids">перечисленные через запятую ID пользователей. Максимум 1000 пользователей.</param>
        /// <param name="nameCase">падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom.</param>
        /// <returns></returns>
        Task<VkUserResult[]> GetAllInfo(int[] uids, VkNameCase nameCase = VkNameCase.Nom);

        

    }
}