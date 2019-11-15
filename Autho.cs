using System;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    public partial class Autho : Form
    {
        public Autho()
        {InitializeComponent();}

        private void receiving_token_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://oauth.vk.com/authorize?client_id=6121396&scope=501202911&response_type=token");
        }
        private void authorization_Click(object sender, EventArgs e)
        {
            if (access_token.Text == "")
            {
                MessageBox.Show("Не введен токен!", "Ошибка");
            }
            else
            {
                Data.Token = access_token.Text;
                VKParanoid f = new VKParanoid();
                f.Show();
                this.Hide();
            }
            System.IO.StreamWriter SaveToken = new System.IO.StreamWriter("Data\\data_token.txt");
            {
                string zapisy = Data.Token;
                SaveToken.WriteLine(zapisy);
            }
            SaveToken.Close();
        }
    }
}
