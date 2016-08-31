using VkApi;

namespace VkApi
{
    /// <summary>
    /// Падеж для склонения имени и фамилии пользователя
    /// </summary>
    public enum VkNameCase
    {
        /// <summary>
        /// именительный 
        /// </summary>
        [EnumValue("nom")]
        Nom,
        /// <summary>
        /// родительный  
        /// </summary>
        [EnumValue("gen")]
        Gen,
        /// <summary>
        /// дательный  
        /// </summary>
        [EnumValue("dat")]
        Dat,
        /// <summary>
        /// винительный   
        /// </summary>
        [EnumValue("acc")]
        Acc,
        /// <summary>
        /// творительный    
        /// </summary>
        [EnumValue("ins")]
        Ins,
        /// <summary>
        /// предложный     
        /// </summary>
        [EnumValue("abl")]
        Abl,
    }
}