using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using xNet;
using System.Threading;

namespace VKParanoid_2._0__test_
{
    public partial class VKParanoid : Form
    {
        public VKParanoid()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            var request = new HttpRequest();
            string users_get = request.Get("https://api.vk.com/method/users.get?user_ids=" 
                                           + id 
                                           + "&access_token=" 
                                           + Data.Token 
                                           + "&v=5.101" 
                                           + "&fields=photo_200"
                                          ).ToString();
            //Name, surname, photo
            dynamic json = JObject.Parse(users_get);
            string name = json["response"][0]["first_name"];
            string surname = json["response"][0]["last_name"];
            string photo = json["response"][0]["photo_200"];
            pictureBox1.ImageLocation = photo;
            Name_Suname.Text = name + " " + surname;
            //Kol-vo friends
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
                string id_1 = json_1["response"]["items"][i]["id"];
                string name_1 = json_1["response"]["items"][i]["first_name"];
                string surname_1 = json_1["response"]["items"][i]["last_name"];
                listBox1.Items.Insert(i, id_1 + " " + name_1 + " " + surname_1);
            }
            richTextBox1.Text = friends_get + " " + listBox1.Items.Count;
            //Followers
            try
            {
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
                    dynamic json_3 = JObject.Parse(users_getFollowers);
                    int count_1 = json_3["response"]["count"];
                    int count_itog_1 = count_1 - 1;
                    if (Data.A == 1000)
                    {
                        Data.A = 0;
                        for (Data.A = 0; Data.A <= count_itog_1; Data.A++)
                        {
                            string id_2 = json_3["response"]["items"][Data.A]["id"];
                            string name_2 = json_3["response"]["items"][Data.A]["first_name"];
                            string surname_2 = json_3["response"]["items"][Data.A]["last_name"];
                            listBox2.Items.Add(id_2 + " " + name_2 + " " + surname_2);
                        }
                    }
                    offset += 1000;
                    Thread.Sleep(100);
                }
                richTextBox1.Text = kol_itog + " " + offset + " " + listBox1.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Text = Convert.ToString(listBox2.Items.Count);
            }
        }
    }
}
