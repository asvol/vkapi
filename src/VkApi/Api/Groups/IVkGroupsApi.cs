using System.Threading.Tasks;

namespace VkApi
{
    public interface IVkGroupsApi
    {
        /// <summary>
        /// Возвращает список участников группы. 
        /// </summary>
        /// <param name="gid">ID группы, список пользователей которой необходимо получить.</param>
        /// <param name="count">Максимальное количество участников группы, которое необходимо получить. Максимальное значение 1000.</param>
        /// <param name="offset">Число, обозначающее смещение, для получения следующих после него участников.</param>
        /// <param name="sort">Сортировка с которой необходимо вернуть список групп. Может принимать параметры: id_asc, id_desc, time_asc, time_desc.</param>
        /// <returns></returns>
        Task<VkGroupMembersResult> GetMembers(int gid, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc);

        /// <summary>
        /// Возвращает список участников группы. 
        /// </summary>
        /// <param name="gidScreenName">короткое имя группы, список пользователей которой необходимо получить.</param>
        /// <param name="count">Максимальное количество участников группы, которое необходимо получить. Максимальное значение 1000.</param>
        /// <param name="offset">Число, обозначающее смещение, для получения следующих после него участников.</param>
        /// <param name="sort">Сортировка с которой необходимо вернуть список групп. Может принимать параметры: id_asc, id_desc, time_asc, time_desc.</param>
        /// <returns></returns>
        Task<VkGroupMembersResult> GetMembers(string gidScreenName, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc);

    }
}