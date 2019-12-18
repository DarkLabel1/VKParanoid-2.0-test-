using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VKParanoid_2._0__test_
{
    public partial class Regestration : Form
    {
        public Regestration(){InitializeComponent();}

        private void regestration_button_Click(object sender, EventArgs e)
        {
            Data.NICKNAME_BASE = textBox1.Text;
            Data.EMAIL_BASE = textBox2.Text;
            Data.PASSWD_BASE = textBox3.Text;
            string PASSWD_PROVERKA = textBox4.Text;
            Data.TOKEN_BASE = textBox5.Text;

            //Проверка данных и отправка в БД
            string sostav_email = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (Regex.IsMatch(Data.EMAIL_BASE, sostav_email))//Проверка введенного e-mail
            {
                if (Data.PASSWD_BASE == PASSWD_PROVERKA)//Проверка пароля
                {
                    if (Data.TOKEN_BASE.Length > 80)//Проверка токена
                    {
                        Main.mysql_reg_prog();
                        MessageBox.Show("Вы успешно зарегестрированы!", "Успешно");
                        Login l = new Login();
                        l.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не введен токен!", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен пароль!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Неверно введен e-mail!", "Ошибка");
            }
        }

        private void token_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://oauth.vk.com/authorize?client_id=6121396&scope=501202911&response_type=token");
        }

        private void Regestration_Load(object sender, EventArgs e)
        {

        }
    }
}
