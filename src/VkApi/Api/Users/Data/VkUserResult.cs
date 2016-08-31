using System;
using Newtonsoft.Json;

namespace VkApi
{
    public class VkUserResult
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Возвращаемые значения: 1 - женский, 2 - мужской, 0 - без указания пола.
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// Дата рождения, выдаётся в формате: "23.11.1981" или "21.9" (если год скрыт). Если дата рождения скрыта целиком, то при приёме данных в формате XML в узле user отсутствует тег bdate. 
        /// </summary>
        [JsonProperty("bdate")]
        public string Bdate { get; set; }

        /// <summary>
        /// Выдаётся id города, указанного у пользователя в разделе "Контакты". 
        /// Название города по его id можно узнать при помощи метода getCities. 
        /// Если город не указан, то при приёме данных в формате XML в узле user отсутствует тег city. 
        /// </summary>
        [JsonProperty("city")]
        public int City { get; set; }

        /// <summary>
        /// Выдаётся id страны, указанной у пользователя в разделе "Контакты". 
        /// Название страны по её id можно узнать при помощи метода getCountries. 
        /// Если страна не указана, то при приёме данных в формате XML в узле user отсутствует тег country. 
        /// </summary>
        [JsonProperty("country")]
        public int Country { get; set; }

        /// <summary>
        /// Выдаётся url квадратной  фотографии пользователя, имеющей ширину 50 пикселей. 
        /// В случае отсутствия у пользователя фотографии выдаётся ответ: "http://vkontakte.ru/images/camera_c.gif" 
        /// </summary>
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        /// <summary>
        /// Выдаётся url квадратной фотографии пользователя, имеющей ширину 100 пикселей. 
        /// В случае отсутствия у пользователя фотографии выдаётся ответ: "http://vkontakte.ru/images/camera_b.gif" 
        /// </summary>
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }
        /// <summary>
        /// Выдаётся url квадратной фотографии пользователя, имеющей ширину 200 пикселей.  
        /// Если фотография была загружена давно, фотографии с такими размерами может не быть, в этом случае будет возвращено false.  
        /// </summary>
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }
        /// <summary>
        /// Выдаётся url фотографии пользователя, имеющей ширину 200 пикселей. 
        /// В случае отсутствия у пользователя фотографии выдаётся ответ: "http://vkontakte.ru/images/camera_a.gif"   
        /// </summary>
        [JsonProperty("photo_200_orig")]
        public string Photo200Orig { get; set; }

        /// <summary>
        /// Выдаётся url фотографии пользователя, имеющей ширину 400 пикселей.  
        /// В случае отсутствия у пользователя фотографии такого размера поле возвращено не будет. 
        /// </summary>
        [JsonProperty("photo_400_orig")]
        public string Photo400Orig { get; set; }

        /// <summary>
        /// Выдаётся url квадратной фотографии пользователя, максимального размера. Может быть возвращена фотография имеющая ширину как 200 так и 100 пикселей. 
        /// В случае отсутствия у пользователя фотографии выдаётся ответ: "http://vkontakte.ru/images/camera_b.gif"  
        /// </summary>
        [JsonProperty("photo_max")]
        public string PhotoMax { get; set; }
        /// <summary>
        /// Выдаётся url фотографии пользователя, максимального размера. Может быть возвращена фотография имеющая ширину как 400 так и 200 пикселей. 
        /// В случае отсутствия у пользователя фотографии выдаётся ответ: "http://vkontakte.ru/images/camera_a.gif"  
        /// </summary>
        [JsonProperty("photo_max_orig")]
        public string PhotoMaxOrig { get; set; }

        /// <summary>
        /// Показывает, находится ли этот пользователь сейчас на сайте. Поле доступно только для метода friends.get. 
        /// Возвращаемые значения: 1 - находится, 0 - не находится.  
        /// Если пользователь использует мобильное приложение либо мобильную версию сайта - будет возвращено дополнительное поле online_mobile. 
        /// (Получить статус мобильного приложения можно написав на apps@vk.com либо в техподдержку сайта) 
        /// Если пользователь использует именно приложение а не сайт - то идентификатор приложения будет возвращен в поле online_app. 
        /// </summary>
        [JsonProperty("online")]
        public int Online { get; set; }

        [JsonProperty("online_mobile")]
        public string OnlineMobile { get; set; }

        [JsonProperty("online_app")]
        public string OnlineApp { get; set; }

        /// <summary>
        /// Список, содержащий id списков друзей, в которых состоит текущий друг пользователя. Метод получения id и названий списков: friends.getLists. 
        /// Поле доступно только для метода friends.get. Если текущий друг не состоит ни в одном списке, то при приёме данных в формате XML в узле user отсутствует тег lists. 
        /// </summary>
        [JsonProperty("lists")]
        public int[] Lists { get; set; }

        /// <summary>
        /// Возвращает короткий адрес страницы (возвращается только имя адреса, например andrew). Если пользователь не менял адрес своей страницы, возвращается 'id'+uid, например id35828305. 
        /// </summary>
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Показывает, известен ли номер мобильного телефона пользователя. 
        /// Возвращаемые значения: 1 - известен, 0 - не известен. 
        /// Рекомендуется перед вызовом метода secure.sendSMSNotification. 
        /// </summary>
        [JsonProperty("has_mobile")]
        public int HasMobile { get; set; }

        /// <summary>
        /// Мобильный телефон пользователя (Если мобильный телефон скрыт приватностью – то он доступен только Desktop приложениям)
        /// </summary>
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Домашний телефон пользователя
        /// </summary>
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }

        
        [JsonProperty("university")]
        public string University { get; set; }

        [JsonProperty("university_name")]
        public string UniversityName { get; set; }

        [JsonProperty("faculty")]
        public string Faculty { get; set; }

        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        [JsonProperty("graduation")]
        public string Graduation { get; set; }

//        /// <summary>
//        /// Список высших учебных заведений, в которых учился текущий пользователь. 
//        /// </summary>
//        [JsonProperty("universities")]
//        public string Universities { get; set; }

//        /// <summary>
//        /// Список школ, в которых учился текущий пользователь. 
//        /// </summary>
//        [JsonProperty("schools")]
//        public string[] Schools { get; set; }

        /// <summary>
        /// Разрешено ли оставлять записи на стене у данного пользователя. 
        /// </summary>
        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        /// <summary>
        /// Разрешено ли текущему пользователю видеть записи других пользователей на стене данного пользователя. 
        /// </summary>
        [JsonProperty("can_see_all_posts")]
        public bool CanSeeAllPosts { get; set; }

        /// <summary>
        /// Разрешено ли написание личных сообщений данному пользователю. 
        /// </summary>
        [JsonProperty("can_write_private_message")]
        public bool CanWritePrivateMessage { get; set; }

        /// <summary>
        /// Возвращает статус, расположенный в профиле, под именем пользователя 
        /// </summary>
        [JsonProperty("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// Возвращает объект, содержащий поле time, в котором содержится время последнего захода пользователя. 
        /// </summary>
        [JsonProperty("last_seen")]
        public FriendsTime LastSeen { get; set; }

        /// <summary>
        /// Возвращает семейное положение пользователя: 
        /// 1 - не женат/не замужем 
        /// 2 - есть друг/есть подруга 
        /// 3 - помолвлен/помолвлена 
        /// 4 - женат/замужем 
        /// 5 - всё сложно 
        /// 6 - в активном поиске 
        /// 7 - влюблён/влюблена 
        /// </summary>
        [JsonProperty("relation")]
        public int Relation { get; set; }

        /// <summary>
        /// Данное поле возвращается только в том случае, если получается не больше одного профиля. 
        /// Если никнейм отсутствует, то при приёме данных в формате XML в узле user содержится пустой тег <nickname/>. 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }


        /// <summary>
        /// Возвращает список родственников текущего пользователя, в виде объектов, содержащих поля uid и type. type может принимать одно из следующих значений: grandchild, grandparent, child, sibling, parent. 
        /// </summary>
        [JsonProperty("relatives")]
        public FriendsRelatives[] Relatives { get; set; }


        public override string ToString()
        {
            return string.Format("uid:{0,-10} {1,-10} {2,-10} {3}", Uid, FirstName, LastName, ScreenName);
        }
    }


    public class FriendsRelatives
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        /// <summary>
        /// grandchild, grandparent, child, sibling, parent. 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class FriendsTime
    {
        [JsonProperty("time")]
        public long Time { get; set; }
    }
}