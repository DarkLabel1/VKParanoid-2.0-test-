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
            System.Diagnostics.Process.Start("https://oauth.vk.com/authorize?client_id=6993599&scope=account,ads,apps,board,database,docs,fave,friends,gifts,groups,leads,likes,market,newsfeed,notes,notifications,pages,photos,places,polls,search,secure,stats,status,storage,users,utils,video,podcasts,stories,wall,orders&display=page&response_type=token&v=5.101");
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
        }
    }
}
