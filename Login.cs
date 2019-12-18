using System;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    public partial class Login : Form
    {
        public Login(){InitializeComponent();}

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Log = textBox1.Text;
            Data.Pass = textBox2.Text;
            Main.mysql_autho_prog();
            if (Convert.ToChar(Data.count_command) == '1')
            {
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regestration R = new Regestration();
            R.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
