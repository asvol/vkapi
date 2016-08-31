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
        /// ������������ ��������: 1 - �������, 2 - �������, 0 - ��� �������� ����.
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// ���� ��������, ������� � �������: "23.11.1981" ��� "21.9" (���� ��� �����). ���� ���� �������� ������ �������, �� ��� ����� ������ � ������� XML � ���� user ����������� ��� bdate. 
        /// </summary>
        [JsonProperty("bdate")]
        public string Bdate { get; set; }

        /// <summary>
        /// ������� id ������, ���������� � ������������ � ������� "��������". 
        /// �������� ������ �� ��� id ����� ������ ��� ������ ������ getCities. 
        /// ���� ����� �� ������, �� ��� ����� ������ � ������� XML � ���� user ����������� ��� city. 
        /// </summary>
        [JsonProperty("city")]
        public int City { get; set; }

        /// <summary>
        /// ������� id ������, ��������� � ������������ � ������� "��������". 
        /// �������� ������ �� � id ����� ������ ��� ������ ������ getCountries. 
        /// ���� ������ �� �������, �� ��� ����� ������ � ������� XML � ���� user ����������� ��� country. 
        /// </summary>
        [JsonProperty("country")]
        public int Country { get; set; }

        /// <summary>
        /// ������� url ����������  ���������� ������������, ������� ������ 50 ��������. 
        /// � ������ ���������� � ������������ ���������� ������� �����: "http://vkontakte.ru/images/camera_c.gif" 
        /// </summary>
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        /// <summary>
        /// ������� url ���������� ���������� ������������, ������� ������ 100 ��������. 
        /// � ������ ���������� � ������������ ���������� ������� �����: "http://vkontakte.ru/images/camera_b.gif" 
        /// </summary>
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }
        /// <summary>
        /// ������� url ���������� ���������� ������������, ������� ������ 200 ��������.  
        /// ���� ���������� ���� ��������� �����, ���������� � ������ ��������� ����� �� ����, � ���� ������ ����� ���������� false.  
        /// </summary>
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }
        /// <summary>
        /// ������� url ���������� ������������, ������� ������ 200 ��������. 
        /// � ������ ���������� � ������������ ���������� ������� �����: "http://vkontakte.ru/images/camera_a.gif"   
        /// </summary>
        [JsonProperty("photo_200_orig")]
        public string Photo200Orig { get; set; }

        /// <summary>
        /// ������� url ���������� ������������, ������� ������ 400 ��������.  
        /// � ������ ���������� � ������������ ���������� ������ ������� ���� ���������� �� �����. 
        /// </summary>
        [JsonProperty("photo_400_orig")]
        public string Photo400Orig { get; set; }

        /// <summary>
        /// ������� url ���������� ���������� ������������, ������������� �������. ����� ���� ���������� ���������� ������� ������ ��� 200 ��� � 100 ��������. 
        /// � ������ ���������� � ������������ ���������� ������� �����: "http://vkontakte.ru/images/camera_b.gif"  
        /// </summary>
        [JsonProperty("photo_max")]
        public string PhotoMax { get; set; }
        /// <summary>
        /// ������� url ���������� ������������, ������������� �������. ����� ���� ���������� ���������� ������� ������ ��� 400 ��� � 200 ��������. 
        /// � ������ ���������� � ������������ ���������� ������� �����: "http://vkontakte.ru/images/camera_a.gif"  
        /// </summary>
        [JsonProperty("photo_max_orig")]
        public string PhotoMaxOrig { get; set; }

        /// <summary>
        /// ����������, ��������� �� ���� ������������ ������ �� �����. ���� �������� ������ ��� ������ friends.get. 
        /// ������������ ��������: 1 - ���������, 0 - �� ���������.  
        /// ���� ������������ ���������� ��������� ���������� ���� ��������� ������ ����� - ����� ���������� �������������� ���� online_mobile. 
        /// (�������� ������ ���������� ���������� ����� ������� �� apps@vk.com ���� � ������������ �����) 
        /// ���� ������������ ���������� ������ ���������� � �� ���� - �� ������������� ���������� ����� ��������� � ���� online_app. 
        /// </summary>
        [JsonProperty("online")]
        public int Online { get; set; }

        [JsonProperty("online_mobile")]
        public string OnlineMobile { get; set; }

        [JsonProperty("online_app")]
        public string OnlineApp { get; set; }

        /// <summary>
        /// ������, ���������� id ������� ������, � ������� ������� ������� ���� ������������. ����� ��������� id � �������� �������: friends.getLists. 
        /// ���� �������� ������ ��� ������ friends.get. ���� ������� ���� �� ������� �� � ����� ������, �� ��� ����� ������ � ������� XML � ���� user ����������� ��� lists. 
        /// </summary>
        [JsonProperty("lists")]
        public int[] Lists { get; set; }

        /// <summary>
        /// ���������� �������� ����� �������� (������������ ������ ��� ������, �������� andrew). ���� ������������ �� ����� ����� ����� ��������, ������������ 'id'+uid, �������� id35828305. 
        /// </summary>
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// ����������, �������� �� ����� ���������� �������� ������������. 
        /// ������������ ��������: 1 - ��������, 0 - �� ��������. 
        /// ������������� ����� ������� ������ secure.sendSMSNotification. 
        /// </summary>
        [JsonProperty("has_mobile")]
        public int HasMobile { get; set; }

        /// <summary>
        /// ��������� ������� ������������ (���� ��������� ������� ����� ������������ � �� �� �������� ������ Desktop �����������)
        /// </summary>
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// �������� ������� ������������
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
//        /// ������ ������ ������� ���������, � ������� ������ ������� ������������. 
//        /// </summary>
//        [JsonProperty("universities")]
//        public string Universities { get; set; }

//        /// <summary>
//        /// ������ ����, � ������� ������ ������� ������������. 
//        /// </summary>
//        [JsonProperty("schools")]
//        public string[] Schools { get; set; }

        /// <summary>
        /// ��������� �� ��������� ������ �� ����� � ������� ������������. 
        /// </summary>
        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        /// <summary>
        /// ��������� �� �������� ������������ ������ ������ ������ ������������� �� ����� ������� ������������. 
        /// </summary>
        [JsonProperty("can_see_all_posts")]
        public bool CanSeeAllPosts { get; set; }

        /// <summary>
        /// ��������� �� ��������� ������ ��������� ������� ������������. 
        /// </summary>
        [JsonProperty("can_write_private_message")]
        public bool CanWritePrivateMessage { get; set; }

        /// <summary>
        /// ���������� ������, ������������� � �������, ��� ������ ������������ 
        /// </summary>
        [JsonProperty("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// ���������� ������, ���������� ���� time, � ������� ���������� ����� ���������� ������ ������������. 
        /// </summary>
        [JsonProperty("last_seen")]
        public FriendsTime LastSeen { get; set; }

        /// <summary>
        /// ���������� �������� ��������� ������������: 
        /// 1 - �� �����/�� ������� 
        /// 2 - ���� ����/���� ������� 
        /// 3 - ���������/���������� 
        /// 4 - �����/������� 
        /// 5 - �� ������ 
        /// 6 - � �������� ������ 
        /// 7 - ������/�������� 
        /// </summary>
        [JsonProperty("relation")]
        public int Relation { get; set; }

        /// <summary>
        /// ������ ���� ������������ ������ � ��� ������, ���� ���������� �� ������ ������ �������. 
        /// ���� ������� �����������, �� ��� ����� ������ � ������� XML � ���� user ���������� ������ ��� <nickname/>. 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }


        /// <summary>
        /// ���������� ������ ������������� �������� ������������, � ���� ��������, ���������� ���� uid � type. type ����� ��������� ���� �� ��������� ��������: grandchild, grandparent, child, sibling, parent. 
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