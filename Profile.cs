using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKParanoid_2._0__test_
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            string pathToFileFriends = "Data\\data_friends.txt";
            // Считываем строки в массив
            string[] allLinesfriends = File.ReadAllLines(pathToFileFriends, Encoding.UTF8);
            // Добавляем каждую строку
            foreach (string line in allLinesfriends)
                listBox3.Items.Add(line);

            string pathToFileFollowers = "Data\\data_followers.txt";
            // Считываем строки в массив
            string[] allLinesfollowers = File.ReadAllLines(pathToFileFollowers, Encoding.UTF8);
            // Добавляем каждую строку
            foreach (string line in allLinesfollowers)
                listBox4.Items.Add(line);

            pictureBox2.ImageLocation = Data.photo_200;
        }
    }
}
