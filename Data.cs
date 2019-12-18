using xNet;
using Newtonsoft.Json.Linq;
using System.Threading;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    static class Data
    {
        //Переменные
        public static string Token;//Токен пользователя
        public static int id;//Идентификатор пользователя
        public static string photo_200_orig;//Фото пользователя 200x200
        public static string name;//Имя пользователя
        public static string surname;//Фамилия пользователя
        public static string photo;//Фото поста
        public static string Log;//Вводимый логин (БД)
        public static string Pass;//Вводимый пароль (БД)
        public static string name_id;//ID из бд
        public static string NICKNAME_BASE;//Никнейм (БД)
        public static string EMAIL_BASE;//EMAIL (БД)
        public static string PASSWD_BASE;//Пароль пользователя (БД)
        public static string TOKEN_BASE;//Токен пользователя
        public static string ID_POSTA;//ID Поста пользователя
        public static string photo_comments;//Фотография в комментарии
        public static string ID_WALL_POST_IN_IMG;
        public static MySqlCommand command;//Проверка пользователя
        public static MySqlCommand command_2;//Получение токена пользователя
        public static MySqlCommand command_3;//Регистрация пользователя
        //JSON
        public static dynamic json_1;//USERS.GET
        public static dynamic json_2;//FRIENDS.GET
        public static dynamic json_3;//FOLLOWERS
        public static dynamic json_4;//FOLLOWERS (WHILE)
        public static dynamic json_5;//LIKES
        public static dynamic json_6;//WALL_GET
        public static dynamic json_7;//LIKES_GET_LIST
        public static dynamic json_8;//LIKES_GET_LIST(2)
        public static dynamic json_9;//WALL_GET(РАСШИРЕННЫЙ)
        public static dynamic json_10;//WALL_GET_POST(КОММЕНТАРИИ)
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
        public static int offset_wall_posts;
        public static string count_command;
        public static int wall_id_post;
        public static string CountKol_voComments;
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
            return;
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

        public static void wall_post()
        {
            var requests = new HttpRequest();
            Thread.Sleep(100);
            string wall_post = requests.Get("https://api.vk.com/method/wall.get?type=post"
                                                                + "&owner_id="
                                                                + Data.id
                                                                + "&count="
                                                                + 100
                                                                + "&offset="
                                                                + Data.offset_wall
                                                                + "&access_token="
                                                                + Data.Token
                                                                + "&v=5.103"
                                                                ).ToString();
            Data.json_9 = JObject.Parse(wall_post);
            return;
        }
        public static void mysql_autho_prog()
        { 
            string connStr = "server=127.0.0.1;port=3307;username=root;database=users;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Count(*) FROM `profile` WHERE NICKNAME = '" + Data.Log + "' AND PASSWORLD='" + Data.Pass + "';";
            Data.command = new MySqlCommand(sql, conn);
            Data.count_command = Data.command.ExecuteScalar().ToString();
            if (Convert.ToChar(Data.count_command) == '1')
            {
                VKParanoid V = new VKParanoid();
                V.Show();
                string sql_id = "SELECT TOKEN FROM `profile` WHERE NICKNAME = '" + Data.Log + "' AND PASSWORLD='" + Data.Pass + "';";
                Data.command_2 = new MySqlCommand(sql_id, conn);
                Data.Token = Data.command_2.ExecuteScalar().ToString();
            }
            else
            {
                MessageBox.Show("Неверно введен логин или пароль!", "Ошибка");
            }
            conn.Close();
            return;
        }

        public static void mysql_reg_prog()
        {
            string connStr = "server=127.0.0.1;port=3307;username=root;database=users;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql_reg = "INSERT INTO PROFILE(NICKNAME, PASSWORLD, E_MAIL, TOKEN) VALUES ('" + Data.NICKNAME_BASE + "','" + Data.PASSWD_BASE + "','" + Data.EMAIL_BASE + "','" + Data.TOKEN_BASE + "');";
            Data.command_3 = new MySqlCommand(sql_reg, conn);
            Data.command_3.ExecuteScalar();
            conn.Close();
            return;
        }

        public static void comments_posta()
        {
            var requests = new HttpRequest();
            Thread.Sleep(100);
            string wall_post_comments = requests.Get("https://api.vk.com/method/wall.getComments?"
                                                                + "&owner_id="
                                                                + Data.id
                                                                + "&post_id="
                                                                + Data.ID_POSTA
                                                                + "&offset="
                                                                + Data.offset_wall_posts
                                                                + "&access_token="
                                                                + Data.Token
                                                                + "&need_likes=1&sort=desc&preview_length=0&extended=1&count=100&v=5.103"
                                                                ).ToString();
            Data.json_10 = JObject.Parse(wall_post_comments);
            return;
        }
    }
}

