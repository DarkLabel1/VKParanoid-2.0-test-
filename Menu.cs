using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    public partial class Menu : Form
    {
        public Menu(){InitializeComponent();}

        private void button1_Click(object sender, EventArgs e)
        {
            Regestration R = new Regestration();
            R.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
