using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using xNet;
using System.Threading;

namespace VKParanoid_2._0__test_
{
    public partial class VKParanoid : Form
    {
        public VKParanoid()
        {InitializeComponent();}
        private void Search_Click(object sender, EventArgs e)
        {
            //Переменная запроса к API VKontakte
            var request = new HttpRequest();
            //Очистка полей, если они заполненны.
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string id = textBox1.Text;
            //Запрос к API
            string users_get = request.Get("https://api.vk.com/method/users.get?user_ids="
                                           + id
                                           + "&access_token="
                                           + Data.Token
                                           + "&v=5.101"
                                           + "&fields=photo_200"
                                          ).ToString();
            //Name, surname, photo (Имя, фамилия и фото)
            dynamic json = JObject.Parse(users_get);
            string name = json["response"][0]["first_name"];
            string surname = json["response"][0]["last_name"];
            string photo = json["response"][0]["photo_200"];
            pictureBox1.ImageLocation = photo;
            Name_Suname.Text = name + " " + surname;
            //Kol-vo friends (Кол-во друзей)
                //Запрос к API
            string friends_get = request.Get("https://api.vk.com/method/friends.get?user_id="
                                         + id
                                         + "&access_token="
                                         + Data.Token
                                         + "&v=5.101"
                                         + "&fields=nickname").ToString();
            dynamic json_1 = JObject.Parse(friends_get);
            int count_0 = json_1["response"]["count"];
            int count_itog_0 = count_0 - 1;
            for (int i = 0; i <= count_itog_0; i++)
            {
                if (json_1["response"]["items"][i] != null)
                {
                    string id_1 = json_1["response"]["items"][i]["id"];
                    string name_1 = json_1["response"]["items"][i]["first_name"];
                    string surname_1 = json_1["response"]["items"][i]["last_name"];
                    listBox1.Items.Insert(i, id_1 + " " + name_1 + " " + surname_1);
                }
                else{}
            }
            //Kol-vo followers (Кол-во подписчиков)
                //Запрос к API
            string kol_vo = request.Get("https://api.vk.com/method/users.getFollowers?user_id="
                                                            + id
                                                            + "&access_token="
                                                            + Data.Token
                                                            + "&v=5.101"
                                                            + "&fields=photo_200").ToString();
            dynamic json_2 = JObject.Parse(kol_vo);
            int kol = json_2["response"]["count"];
            int kol_itog = kol - 1;
            int offset = 0;
            while (offset < kol_itog)
            {
                Thread.Sleep(100);
                //Запрос к API
                string users_getFollowers = request.Get("https://api.vk.com/method/users.getFollowers?user_id="
                                                        + id
                                                        + "&access_token="
                                                        + Data.Token
                                                        + "&v=5.101"
                                                        + "&offset="
                                                        + offset
                                                        + "&count="
                                                        + 1000
                                                        + "&fields=photo_200").ToString();
                Data.json_3 = JObject.Parse(users_getFollowers);
                int count_1 = Data.json_3["response"]["count"];
                Data.count_itog_1 = count_1 - 1;
                offset += 1000;
                try
                {
                    int B = 0;
                    for (int A = 0; A <= Data.count_itog_1; A++)
                    {
                        if (Data.json_3["response"]["items"][B] != null)
                        {
                            string id_2 = Data.json_3["response"]["items"][B]["id"];
                            string name_2 = Data.json_3["response"]["items"][B]["first_name"];
                            string surname_2 = Data.json_3["response"]["items"][B]["last_name"];
                            listBox2.Items.Insert(B, id_2 + " " + name_2 + " " + surname_2);
                            B++;
                        }
                        else{}
                    }
                }
                catch{}
            }
            richTextBox1.Text = " Count listBox1: " + listBox1.Items.Count + " Count listBox2: " + listBox2.Items.Count;
        }
    }
}