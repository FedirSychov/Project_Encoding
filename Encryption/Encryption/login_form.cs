using MySql.Data.MySqlClient;
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

namespace Encryption
{
    public partial class login_form : Form
    {
        public login_form(int type)
        {
            InitializeComponent();
            password_textbox.UseSystemPasswordChar = true;
            if (type == 2)
            {
                se_standart_user();
                online_button_Click();
            }
            else
            {

            }
        }
        public void se_standart_user()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Текстовые файлы(.txt)|.txt";
                open.FileName = "temp_file1.txt";
                StreamReader read = new StreamReader(open.FileName);
                List<string> list = new List<string>();
                string s = "";
                while ((s = read.ReadLine()) != null)
                {
                    list.Add(s);
                }
                read.Close();

                //кодирование строки
                var enc = new Encryption();
                login_textbox.Text = enc.DeCrypt(list[0]);
                password_textbox.Text = enc.DeCrypt(list[1]);
            }
            catch
            {

            }
        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.Red;
        }

        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }
        public void close_this()
        {
            this.Close();
        }

        private void online_button_Click(object sender, EventArgs e)
        {
            String login = login_textbox.Text;
            String password = password_textbox.Text;

            db user_db = new db();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT * FROM `profiles` WHERE `login` = @ul AND `password` = @up", user_db.getConnection());

            //хэширование
            string hash_password = Hash.GetHashString(password);

            //определение заглушек
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = hash_password;

            //получаем ячейку с указателем на преподавателя
            MySqlCommand command_for_teacher = new MySqlCommand("SELECT `role_id` FROM `profiles` WHERE `login` = @ul2", user_db.getConnection());
            command_for_teacher.Parameters.Add("@ul2", MySqlDbType.VarChar).Value = login;

            //выполняем команду и результат вставляем в таблицу
            try
            {
                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
            user_db.closeConnection();

            //проверка количества удовлетворяемых строк
            if (table.Rows.Count > 0)
            {
                command_for_teacher.Connection.Open();
                var temp = command_for_teacher.ExecuteScalar();
                if (Convert.ToString(temp) == "1")
                {
                    if (remember_checkBox.Checked)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "Текстовые файлы(.txt)|.txt";
                        save.FileName = "temp_file1.txt";
                        StreamWriter write = new StreamWriter(save.FileName);
                        List<string> list = new List<string>();
                        //кодирование строки
                        var enc = new Encryption();
                        list.Add(enc.Crypt(login_textbox.Text));
                        list.Add(enc.Crypt(password_textbox.Text));
                        for (int i = 0; i < 2; i++)
                        {
                            write.WriteLine(list[i]);
                        }
                        write.Close();
                    }
                    sec_pass_form cpf = new sec_pass_form();

                    cpf.Show();
                    cpf.login_find = login;
                    this.Close();
                }
                else
                {
                    if (remember_checkBox.Checked)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "Текстовые файлы(.txt)|.txt";
                        save.FileName = "temp_file1.txt";
                        StreamWriter write = new StreamWriter(save.FileName);
                        List<string> list = new List<string>();
                        //кодирование строки
                        var enc = new Encryption();
                        list.Add(enc.Crypt(login_textbox.Text));
                        list.Add(enc.Crypt(password_textbox.Text));
                        for (int i = 0; i < 2; i++)
                        {
                            write.WriteLine(list[i]);
                        }
                        write.Close();
                    }
                    online_form of = new online_form(login);
                    of.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }


            /*
            online_form of = new online_form();
            of.Show();
            this.Hide();*/
        }
        private void online_button_Click()
        {
            String login = login_textbox.Text;
            String password = password_textbox.Text;

            remember_checkBox.Checked = true;

            db user_db = new db();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT * FROM `profiles` WHERE `login` = @ul AND `password` = @up", user_db.getConnection());

            //хэширование
            string hash_password = Hash.GetHashString(password);

            //определение заглушек
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = hash_password;

            //получаем ячейку с указателем на преподавателя
            MySqlCommand command_for_teacher = new MySqlCommand("SELECT `role_id` FROM `profiles` WHERE `login` = @ul2", user_db.getConnection());
            command_for_teacher.Parameters.Add("@ul2", MySqlDbType.VarChar).Value = login;

            //выполняем команду и результат вставляем в таблицу
            adapter.SelectCommand = command;
            adapter.Fill(table);

            user_db.closeConnection();

            //проверка количества удовлетворяемых строк
            if (table.Rows.Count > 0)
            {
                command_for_teacher.Connection.Open();
                var temp = command_for_teacher.ExecuteScalar();
                if (Convert.ToString(temp) == "1")
                {
                    sec_pass_form cpf = new sec_pass_form();

                    cpf.Show();
                    cpf.login_find = login;
                    this.Close();
                }
                else
                {
                    if (remember_checkBox.Checked)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "Текстовые файлы(.txt)|.txt";
                        save.FileName = "temp_file1.txt";
                        StreamWriter write = new StreamWriter(save.FileName);
                        List<string> list = new List<string>();
                        //кодирование строки
                        var enc = new Encryption();
                        list.Add(enc.Crypt(login_textbox.Text));
                        list.Add(enc.Crypt(password_textbox.Text));
                        for (int i = 0; i < 2; i++)
                        {
                            write.WriteLine(list[i]);
                        }
                        write.Close();
                    }
                    online_form of = new online_form(login);
                    of.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }


            /*
            online_form of = new online_form();
            of.Show();
            this.Hide();*/
        }

        private void login_form_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void login_form_Load(object sender, EventArgs e)
        {

        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            password_textbox.UseSystemPasswordChar = false;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            password_textbox.UseSystemPasswordChar = true;
        }
    }
}
