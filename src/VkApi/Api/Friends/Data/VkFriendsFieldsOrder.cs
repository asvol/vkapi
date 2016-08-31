using VkApi;

namespace VkApi
{
    public enum VkFriendsFieldsOrder
    {
        /// <summary>
        /// ����������� �� ����� (�������� ������ ��� ���������� ��������� fields)
        /// </summary>
        [EnumValue("name")]
        Name ,
        /// <summary>
        /// ���������� �� ��������, ���������� ����, ��� ������ ����������� � ������� ��� ������
        /// </summary>
        [EnumValue("hints")]
        Hints ,
    }
}