using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using xNet;
using System.Threading;
using System.Linq;

namespace VKParanoid_2._0__test_
{
    public partial class VKParanoid : Form
    {
        public VKParanoid()
        { InitializeComponent(); }
        private void Search_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Data\\data_likers.txt", String.Empty);
            File.WriteAllText("Data\\data_likes.txt", String.Empty);
            //Переменная запроса к API VKontakte
            var request = new HttpRequest();
            //Очистка полей, если они заполненны.
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            Data.id = Convert.ToInt32(textBox1.Text);
            //Users_Get
            Main.users_get();
            //Name, surname, photo (Имя, фамилия и фото)
            pictureBox1.ImageLocation = Data.photo_200_orig;
            Name_Suname.Text = Data.name + " " + Data.surname;
            //Kol-vo friends (Кол-во друзей)
            Main.friends_get();
            label4.Text = "[" + Convert.ToString(Data.count0) + "]";
            for (int i = 0; i <= Data.count_itog_0; i++)
            {
                if (Data.json_2["response"]["items"][i] != null)
                {
                    string id_1 = Data.json_2["response"]["items"][i]["id"];
                    string name_1 = Data.json_2["response"]["items"][i]["first_name"];
                    string surname_1 = Data.json_2["response"]["items"][i]["last_name"];
                    listBox1.Items.Insert(i, id_1 + " " + name_1 + " " + surname_1);
                }
                else{}
            }
            //Kol-vo followers (Кол-во подписчиков)
            Main.Kol_vo_followers();
            label5.Text = "[" + Convert.ToString(Data.count1) + "]";
            Data.offset_users_getFollowers = 0;
            while (Data.offset_users_getFollowers < Data.count_itog_1)
            {
                Thread.Sleep(100);
                //Запрос к API
                Main.users_getFollowers();
                try
                {
                    int B = 0;
                    for (int A = 0; A <= Data.count_itog_2; A++)
                    {
                        if (Data.json_4["response"]["items"][B] != null)
                        {
                            string id_2 = Data.json_4["response"]["items"][B]["id"];
                            string name_2 = Data.json_4["response"]["items"][B]["first_name"];
                            string surname_2 = Data.json_4["response"]["items"][B]["last_name"];
                            listBox2.Items.Insert(B, id_2 + " " + name_2 + " " + surname_2);
                            B++;
                        }
                        else{}
                    }
                }
                catch{}
            }

            System.IO.StreamWriter SaveFileFriends = new System.IO.StreamWriter("Data\\data_friends.txt");
            for (int a = 0; a < listBox1.Items.Count; a++)
            {
                string zapisy = listBox1.Items[a].ToString();
                SaveFileFriends.WriteLine(zapisy);
            }
            SaveFileFriends.Close();
            System.IO.StreamWriter SaveFileFollowers = new System.IO.StreamWriter("Data\\data_followers.txt");
            for (int a = 0; a < listBox2.Items.Count; a++)
            {
                string zapisy = listBox2.Items[a].ToString();
                SaveFileFollowers.WriteLine(zapisy);
            }
            SaveFileFollowers.Close();

            //Лайкеры ВК + WallPostId
            Main.wall_get();
            int C = 0;
            while (C < 6)
            {
                int count = Data.json_6["response"]["count"];
                for (int i = 0; i <= count; i++)
                {
                    try
                    {
                        if (Data.json_6["response"]["items"][i]["id"] != null)
                        {
                            Data.wall_id_post = Data.json_6["response"]["items"][i]["id"];
                            Thread.Sleep(100);
                            Main.likesGetList();
                            Data.offset_likes = 0;
                            while (Data.offset_likes < Data.count_itog_5)
                            {
                                Thread.Sleep(100);
                                string likes_getList = request.Get("https://api.vk.com/method/likes.getList?type="
                                                                                    + "post"
                                                                                    + "&owner_id="
                                                                                    + Data.id
                                                                                    + "&item_id="
                                                                                    + Data.wall_id_post
                                                                                    + "&friends_only=0"
                                                                                    + "&extended=1"
                                                                                    + "&offset="
                                                                                    + Data.offset_likes
                                                                                    + "&access_token="
                                                                                    + Data.Token
                                                                                    + "&v=5.103"
                                                                                    ).ToString();
                                Data.json_8 = JObject.Parse(likes_getList);
                                Data.offset_likes += 100;
                                try
                                {
                                    for (int b = 0; b <= Data.count_itog_5; b++)
                                    {
                                        if (Data.json_8["response"]["items"][b] != null)
                                        {
                                            string id_likes = Data.json_7["response"]["items"][b]["id"];
                                            string name_likes = Data.json_7["response"]["items"][b]["first_name"];
                                            string surname_likes = Data.json_7["response"]["items"][b]["last_name"];
                                            string full = id_likes + " " + name_likes + " " + surname_likes;
                                            System.IO.StreamWriter SaveFileLikes = new System.IO.StreamWriter("Data\\data_likes.txt", true);
                                            SaveFileLikes.WriteLine(full);
                                            SaveFileLikes.Close();
                                        }
                                        else { }
                                    }
                                }
                                catch { }
                            }
                        }
                        else { }
                    }
                    catch { }
                    C += 1;
                    File.WriteAllLines("Data\\data_likers.txt", File.ReadAllLines("Data\\data_likes.txt").Distinct().ToArray());
                }
            }
            listBox3.Items.AddRange(File.ReadAllLines("Data\\data_likers.txt"));
            int likesrs_count = System.IO.File.ReadAllLines("Data\\data_likers.txt").Length;
            label7.Text = '[' + Convert.ToString(likesrs_count) + ']';

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/id" + Data.id);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Profile f = new Profile();
            f.Show();
        }

        private void VKParanoid_Load(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
        }
    }
}