using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace VKParanoid_2._0__test_
{
    public partial class Users : Form
    {
        public Users()
        {InitializeComponent();}
        private void Users_Load(object sender, EventArgs e)
        {
            Main.wall_post();
            int count = Data.json_9["response"]["count"];
            label2.Text = Convert.ToString(count);
            Data.offset_wall = 0;
            int Num = 0;
            while (Data.offset_wall < count)
            {
                Main.wall_post();
                try
                {
                    for (int P = 0; P <= 100; P++)
                    {
                        Data.ID_WALL_POST_IN_IMG = Data.json_9["response"]["items"][P]["id"];
                        int data = Data.json_9["response"]["items"][P]["date"];
                        DateTime date = new DateTime(1970, 1, 1).AddSeconds(data);
                        string data_create_post = Convert.ToString(date);
                        string text = Data.json_9["response"]["items"][P]["text"];
                        try
                        {
                            Data.photo = Data.json_9["response"]["items"][P]["attachments"][0]["photo"]["sizes"][8]["url"];
                        }
                        catch { }
                        string comments = Data.json_9["response"]["items"][P]["comments"]["count"];
                        string likes = Data.json_9["response"]["items"][P]["likes"]["count"];
                        string reposts = Data.json_9["response"]["items"][P]["reposts"]["count"];
                        string views = Data.json_9["response"]["items"][P]["views"]["count"];
                        dataGridView1.Rows.Insert(Num, Data.ID_WALL_POST_IN_IMG, data_create_post, text, Data.photo, comments, likes, reposts, views);
                        Num += 1;
                    }
                }
                catch { }
                Data.offset_wall += 100;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Process.Start(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            catch { }

            Data.offset_wall_posts = 0;
            Data.ID_POSTA = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Data.CountKol_voComments = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (e.ColumnIndex == 8)
            {
                Comments C = new Comments();
                C.Show();
            }
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
