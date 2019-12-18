using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    public partial class Comments : Form
    {
        public Comments(){InitializeComponent();}
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Process.Start(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
            catch { }
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            Main.comments_posta();
            int count = Data.json_10["response"]["count"];
            try
            {
                for (int A = 0; A <= count; A++)
                {
                    string id_comments = Data.json_10["response"]["items"][A]["id"];
                    string from_id = Data.json_10["response"]["items"][A]["from_id"];
                    int data = Data.json_10["response"]["items"][A]["date"];
                    DateTime date = new DateTime(1970, 1, 1).AddSeconds(data);
                    string data_create_comments = Convert.ToString(date);
                    string text_comments = Data.json_10["response"]["items"][A]["text"];
                    string likes_comments = Data.json_10["response"]["items"][A]["likes"]["count"];
                    try
                    {
                        Data.photo_comments = Data.json_10["response"]["items"][A]["attachments"][0]["photo"]["sizes"][8]["url"];
                    }
                    catch { }
                    dataGridView1.Rows.Insert(A, id_comments, from_id, data_create_comments, text_comments, likes_comments, Data.photo_comments);
                    Data.photo_comments = null;
                }
            }
            catch { }
            label2.Text = Data.CountKol_voComments;
        }
    }
}
