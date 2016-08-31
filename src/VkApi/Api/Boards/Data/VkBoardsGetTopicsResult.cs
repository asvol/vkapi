using Newtonsoft.Json;

namespace VkApi
{
    public class VkBoardsGetTopicsResult
    {
        [JsonProperty("topics")]
        public TopicsResult[] Topics { get; set; }

        /// <summary>
        /// ѕоле default_order содержит целое число, обозначающее тип сортировки по умолчанию (то есть заданный администратором группы). Ёто значение используетс€, если не указан параметр order. ¬озможные значени€:
        /// 1 - по убыванию даты обновлени€,
        /// 2 - по убыванию даты создани€,
        /// -1 - по возрастанию даты обновлени€,
        /// -2 - по возрастанию даты создани€.
        /// </summary>
        [JsonProperty("default_order")]
        public int DefaultOrder { get; set; }

        /// <summary>
        /// ѕоле can_add_topics содержит значение 1 в том случае, если текущий пользователь может создавать новые темы в обсуждени€х данной группы (или 0 в противном случае). 
        /// </summary>
        [JsonProperty("can_add_topics")]
        public int CanAddTopics { get; set; }

        /// <summary>
        /// ¬ случае передачи параметра extended равным 1, поле profiles содержит массив объектов с информацией о данных пользователей, €вл€ющихс€ создател€ми тем или оставившими в них последнее сообщение. Ѕолее подробна€ информаци€ о формате каждого из объектов в массиве содержитс€ на странице ќписание пол€ user.
        /// </summary>
        [JsonProperty("profiles")]
        public VkUserResult[] Profiles { get; set; }
    }
}