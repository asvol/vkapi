using Newtonsoft.Json;

namespace VkApi
{
    public class VkBoardsGetTopicsResult
    {
        [JsonProperty("topics")]
        public TopicsResult[] Topics { get; set; }

        /// <summary>
        /// ���� default_order �������� ����� �����, ������������ ��� ���������� �� ��������� (�� ���� �������� ��������������� ������). ��� �������� ������������, ���� �� ������ �������� order. ��������� ��������:
        /// 1 - �� �������� ���� ����������,
        /// 2 - �� �������� ���� ��������,
        /// -1 - �� ����������� ���� ����������,
        /// -2 - �� ����������� ���� ��������.
        /// </summary>
        [JsonProperty("default_order")]
        public int DefaultOrder { get; set; }

        /// <summary>
        /// ���� can_add_topics �������� �������� 1 � ��� ������, ���� ������� ������������ ����� ��������� ����� ���� � ����������� ������ ������ (��� 0 � ��������� ������). 
        /// </summary>
        [JsonProperty("can_add_topics")]
        public int CanAddTopics { get; set; }

        /// <summary>
        /// � ������ �������� ��������� extended ������ 1, ���� profiles �������� ������ �������� � ����������� � ������ �������������, ���������� ����������� ��� ��� ����������� � ��� ��������� ���������. ����� ��������� ���������� � ������� ������� �� �������� � ������� ���������� �� �������� �������� ���� user.
        /// </summary>
        [JsonProperty("profiles")]
        public VkUserResult[] Profiles { get; set; }
    }
}