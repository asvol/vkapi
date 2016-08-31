using System.Threading.Tasks;

namespace VkApi
{
    public interface IVkGroupsApi
    {
        /// <summary>
        /// ���������� ������ ���������� ������. 
        /// </summary>
        /// <param name="gid">ID ������, ������ ������������� ������� ���������� ��������.</param>
        /// <param name="count">������������ ���������� ���������� ������, ������� ���������� ��������. ������������ �������� 1000.</param>
        /// <param name="offset">�����, ������������ ��������, ��� ��������� ��������� ����� ���� ����������.</param>
        /// <param name="sort">���������� � ������� ���������� ������� ������ �����. ����� ��������� ���������: id_asc, id_desc, time_asc, time_desc.</param>
        /// <returns></returns>
        Task<VkGroupMembersResult> GetMembers(int gid, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc);

        /// <summary>
        /// ���������� ������ ���������� ������. 
        /// </summary>
        /// <param name="gidScreenName">�������� ��� ������, ������ ������������� ������� ���������� ��������.</param>
        /// <param name="count">������������ ���������� ���������� ������, ������� ���������� ��������. ������������ �������� 1000.</param>
        /// <param name="offset">�����, ������������ ��������, ��� ��������� ��������� ����� ���� ����������.</param>
        /// <param name="sort">���������� � ������� ���������� ������� ������ �����. ����� ��������� ���������: id_asc, id_desc, time_asc, time_desc.</param>
        /// <returns></returns>
        Task<VkGroupMembersResult> GetMembers(string gidScreenName, int? count = null, int? offset = null, VkMembersGroupSort sort = VkMembersGroupSort.IDDesc);

    }
}