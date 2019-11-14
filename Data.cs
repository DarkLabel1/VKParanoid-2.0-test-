using xNet;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace VKParanoid_2._0__test_
{
    static class Data
    {
        public static string Token;
        public static int id;
        public static string photo_200_orig;
        public static string name;
        public static string surname;
        //JSON
        public static dynamic json_1;//USERS.GET
        public static dynamic json_2;//FRIENDS.GET
        public static dynamic json_3;//FOLLOWERS
        public static dynamic json_4;//FOLLOWERS (WHILE)
        public static dynamic json_5;//LIKES
        public static dynamic json_6;//WALL_GET
        public static dynamic json_7;//LIKES_GET_LIST
        public static dynamic json_8;//LIKES_GET_LIST(2)
        //COUNT
        public static int count0;//FRIENDS.GET
        public static int count_itog_0;
        public static int count1;
        public static int count_itog_1;//FOLLOWERS
        public static int offset_users_getFollowers;
        public static int count_2;
        public static int count_itog_2;
        public static int count_3;//LIKES
        public static int count_itog_3;
        public static int count_5;
        public static int count_itog_5;
        public static int offset_likes;
        public static int offset_wall;//WALL

        public static int wall_id_post;
    }

    public class Main
    {
        public static void users_get()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string users_get = request.Get("https://api.vk.com/method/users.get?user_ids="
                                          + Data.id
                                          + "&access_token="
                                          + Data.Token
                                          + "&v=5.101"
                                          + "&fields=photo_200, photo_200_orig"
                                         ).ToString();
            Data.json_1 = JObject.Parse(users_get);
            Data.name = Data.json_1["response"][0]["first_name"];
            Data.surname = Data.json_1["response"][0]["last_name"];
            Data.photo_200_orig = Data.json_1["response"][0]["photo_200_orig"];
            return;
        }

        public static void friends_get()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string friends_get = request.Get("https://api.vk.com/method/friends.get?user_id="
                                         + Data.id
                                         + "&access_token="
                                         + Data.Token
                                         + "&v=5.101"
                                         + "&fields=nickname").ToString();
            Data.json_2 = JObject.Parse(friends_get);
            Data.count0 = Data.json_2["response"]["count"];
            Data.count_itog_0 = Data.count0 - 1;
        }

        public static void Kol_vo_followers()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string kol_vo = request.Get("https://api.vk.com/method/users.getFollowers?user_id="
                                                            + Data.id
                                                            + "&access_token="
                                                            + Data.Token
                                                            + "&v=5.101"
                                                            + "&fields=photo_200").ToString();
            Data.json_3 = JObject.Parse(kol_vo);
            Data.count1 = Data.json_3["response"]["count"];
            Data.count_itog_1 = Data.count1 - 1;
            return;
        }

        public static void users_getFollowers()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string users_getFollowers = request.Get("https://api.vk.com/method/users.getFollowers?user_id="
                                                        + Data.id
                                                        + "&access_token="
                                                        + Data.Token
                                                        + "&v=5.101"
                                                        + "&offset="
                                                        + Data.offset_users_getFollowers
                                                        + "&count="
                                                        + 1000
                                                        + "&fields=photo_200").ToString();
            Data.json_4 = JObject.Parse(users_getFollowers);
            Data.count_2 = Data.json_4["response"]["count"];
            Data.count_itog_2 = Data.count_2 - 1;
            Data.offset_users_getFollowers += 1000;
            return;
        }

        public static void Likes_count()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string likes_getList_count = request.Get("https://api.vk.com/method/likes.getList?type="
                                                                + "post"
                                                                + "&owner_id="
                                                                + Data.id
                                                                + "&item_id="
                                                                + Data.wall_id_post
                                                                + "&friends_only=0"
                                                                + "&extended=1"
                                                                + "&access_token="
                                                                + Data.Token
                                                                + "&v=5.103"
                                                                ).ToString();
            Data.json_5 = JObject.Parse(likes_getList_count);
            Data.count_3 = Data.json_5["response"]["count"];
            Data.count_itog_3 = Data.count_3 - 1;
            return;
        }
        public static void wall_get()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string wall_get = request.Get("https://api.vk.com/method/wall.get?type="
                                                       + "post&"
                                                       + "owner_id="
                                                       + Data.id
                                                       + "&count="
                                                       + 6
                                                       + "&access_token="
                                                       + Data.Token
                                                       + "&v=5.103"
                                                       ).ToString();
            Data.json_6 = JObject.Parse(wall_get);
            return;
        }
        public static void likesGetList()
        {
            var request = new HttpRequest();
            Thread.Sleep(100);
            string likes_getList = request.Get("https://api.vk.com/method/likes.getList?type="
                                                                + "post"
                                                                + "&owner_id="
                                                                + Data.id
                                                                + "&item_id="
                                                                + Data.wall_id_post
                                                                + "&friends_only=0"
                                                                + "&extended=1"
                                                                + "&access_token="
                                                                + Data.Token
                                                                + "&v=5.103"
                                                                ).ToString();
            Data.json_7 = JObject.Parse(likes_getList);
            Data.count_5 = Data.json_7["response"]["count"];
            Data.count_itog_5 = Data.count_5 - 1;
            return;
        }
    }
}

