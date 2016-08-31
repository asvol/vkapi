using Newtonsoft.Json;

namespace VkApi
{
    public class TopicsResult
    {
        /// <summary>
        /// �������������
        /// </summary>
        [JsonProperty("tid")]
        public int Tid { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// ���� �������� (� ������� unix timestamp)
        /// </summary>
        [JsonProperty("created")]
        public long Created { get; set; }

        /// <summary>
        /// ������������� ������������, ���������� ����
        /// </summary>
        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// ������������� ������������, ����������� ��������� ���������
        /// </summary>
        [JsonProperty("updated_by")]
        public int UpdatedBy { get; set; }

        /// <summary>
        /// 1, ���� ���� �������� �������� (� ��� ������ ��������� ���������)
        /// </summary>
        [JsonProperty("is_closed")]
        public int IsClosed { get; set; }

        /// <summary>
        /// 1, ���� ���� �������� ������������ (��������� � ������ ������ ���)
        /// </summary>
        [JsonProperty("is_fixed")]
        public int IsFixed { get; set; }

        /// <summary>
        /// ����� ��������� � ����.
        /// </summary>
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// (������ ���� � ���� preview ������ ���� 1) - ����� ������� ���������.
        /// </summary>
        [JsonProperty("first_comment")]
        public string FirstComment { get; set; }

        /// <summary>
        /// (������ ���� � ���� preview ������ ���� 2) - ����� ���������� ���������.
        /// </summary>
        [JsonProperty("last_comment")]
        public string LastComment { get; set; }

    }
}