using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class register_student_form : Form
    {
        public register_student_form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// проверка существует ли уже пользователь с таким логином
        /// </summary>
        /// <returns>true - существует, false - не существует</returns>
        public bool isUserExists()
        {
            string login = login_textbox.Text;

            db user_db = new db();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT * FROM `profiles` WHERE `login` = @ul", user_db.getConnection());

            //определение заглушек
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;

            //выполняем команду и результат вставляем в таблицу
            adapter.SelectCommand = command;
            adapter.Fill(table);

            user_db.closeConnection();

            //проверка количества удовлетворяемых строк
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            //try
            //{
                //проверка введенного логина
                if (login_textbox.Text == "")
                {
                    MessageBox.Show("Введите логин!");
                    return;
                }
                else
                {
                    if (login_textbox.Text.Length < 6)
                    {
                        MessageBox.Show("Слишком короткий логин!");
                        return;
                    }
                }

                //проверка введенного пароля
                if (password_textbox.Text == "")
                {
                    MessageBox.Show("Введите пароль!");
                    return;
                }
                else
                {
                    if (password_textbox.Text.Length < 6)
                    {
                        MessageBox.Show("Слишком короткий пароль!");
                        return;
                    }
                }

                //проверка существует ли уже пользователь
                if (isUserExists())
                {
                    MessageBox.Show("Данный пользователь уже существует!");
                    return;
                }

                String login = login_textbox.Text;
                String password = password_textbox.Text;

                db user_db = new db();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                //команда
                MySqlCommand command = new MySqlCommand("INSERT INTO `encryptdb`.`profiles` (login, password, role_id) VALUES (@ul, @up, @it);", user_db.getConnection());

                //хэширование
                string hash_password = Hash.GetHashString(password);

                //составление параметров
                command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@up", MySqlDbType.VarChar).Value = hash_password;
                if (is_teacher_checkbox.Checked == true) command.Parameters.Add("@it", MySqlDbType.Bit).Value = 1;
                else command.Parameters.Add("@it", MySqlDbType.Bit).Value = 0;

                //открытие подключения
                user_db.openConnection();

                //выполнение команды
                if (command.ExecuteNonQuery() == 1)
                {
                    //запись ключа
                    MySqlCommand command_for_key = new MySqlCommand("INSERT INTO `encryptdb`.`code_keys` (id, code_key) VALUES ((SELECT `profile_id` FROM `encryptdb`.`profiles` WHERE `login` = @ul2), @uk)", user_db.getConnection());

                    //добавление параметров для поиска айди по логину
                    command_for_key.Parameters.Add("@ul2", MySqlDbType.VarChar).Value = login;

                    //генерация ключа
                    string new_key = generateKey("abcdefghijklmnopqrstuvxyz0123456789");

                    //добавление параметра
                    command_for_key.Parameters.Add("@uk", MySqlDbType.VarChar).Value = new_key;
                    
                    //выполнение команды
                    if (command_for_key.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт был создан");
                    }
                    else
                    {
                        MessageBox.Show("Индивидуальный ключ не был создан");
                    }
                }
                else
                {
                    MessageBox.Show("Аккаунт не был создан");
                }
            //}
            /*
            catch
            {
                MessageBox.Show("Ошибка");
            }*/
        }

        private string generateKey(string Alphabet)
        {
            //создаем объект Random, генерирующий случайные числа
            Random rnd = new Random();
            //объект StringBuilder с заранее заданным размером буфера под результирующую строку
            StringBuilder sb = new StringBuilder(7);
            //переменную для хранения случайной позиции символа из строки Alphabet
            int Position = 0;

            for (int i = 0; i < 7; i++)
            {
                //получаем случайное число от 0 до последнего
                //символа в строке Alphabet
                Position = rnd.Next(0, Alphabet.Length - 1);
                //добавляем выбранный символ в объект
                //StringBuilder
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            teacher_form tf = new teacher_form();
            tf.Show();
            this.Close();
        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.Red;
        }

        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.FromArgb(64,64,64);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.FromArgb(64,64,64);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
