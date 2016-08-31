using VkApi;

namespace VkApi
{
    /// <summary>
    /// ����� ��� ��������� ����� � ������� ������������
    /// </summary>
    public enum VkNameCase
    {
        /// <summary>
        /// ������������ 
        /// </summary>
        [EnumValue("nom")]
        Nom,
        /// <summary>
        /// �����������  
        /// </summary>
        [EnumValue("gen")]
        Gen,
        /// <summary>
        /// ���������  
        /// </summary>
        [EnumValue("dat")]
        Dat,
        /// <summary>
        /// �����������   
        /// </summary>
        [EnumValue("acc")]
        Acc,
        /// <summary>
        /// ������������    
        /// </summary>
        [EnumValue("ins")]
        Ins,
        /// <summary>
        /// ����������     
        /// </summary>
        [EnumValue("abl")]
        Abl,
    }
}