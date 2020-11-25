using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenQA.Selenium.Remote;
using System.Drawing.Text;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

namespace Encryption
{
    public partial class online_form : Form
    {
        private bool sorted_alph = false;
        private string path_to_folder = @"C:\Users\Asus\Desktop\Studium\3 Семестр\Проект шифрование\local_data_base\";
        private string file_name = "";
        private string file_text = "";
        private string login = "";
        public online_form(string login)
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            label1.Text = login;
            this.login = login;
            teachers_listbox.Visible = false;
            dataGrid_works.ForeColor = Color.White;
            dataGrid_works.BackgroundColor = Color.DarkGray;
            
            update_button_Click();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.Red;
        }

        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void online_form_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void gooffline_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void online_form_Load(object sender, EventArgs e)
        {

        }

        private void back_button_Click(object sender, EventArgs e)
        {
            login_form lf = new login_form(1);
            lf.Show();
            this.Close();
        }

        private void choose_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word 97-2003|*.doc|Word Document|*.docx|Все файлы(*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fileStream = File.OpenRead(Path.GetFullPath(ofd.FileName));

                    //байтовый массив
                    byte[] input = new byte[fileStream.Length];

                    BinaryReader binReader = new BinaryReader(fileStream);

                    //чтение файла по байтам
                    input = binReader.ReadBytes(input.Length);
                    fileStream.Close();

                    //перевод последовательности байтов в строку
                    string s1 = code.ToHexString(input);

                    this.file_name = Path.GetFileName(ofd.FileName);
                    this.file_text = s1;
                    this.status_label.Text = file_name;

                    binReader.Close();
                }
            }
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            if (teachers_listbox.SelectedItem != null && subject_textbox.Text != "Название дисциплины" && subject_textbox.Text != "")
            {
                //общий путь
                string path = this.path_to_folder + this.login + @"\" + get_new_file_name_with_esdf(this.file_name);
                string path_to_folder = this.path_to_folder + this.login + @"\";
                //Дальше сохранение зашифрованного файла в папку и добавление в БД

                db user_db = new db();

                System.Data.DataTable table = new System.Data.DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                //команда для получения ключа
                MySqlCommand command_for_key = new MySqlCommand("SELECT `code_key` FROM `encryptdb`.`code_keys` WHERE id = (SELECT profile_id FROM `encryptdb`.`profiles` WHERE `login` = @ul2)", user_db.getConnection());
                command_for_key.Connection.Open();
                command_for_key.Parameters.Add("@ul2", MySqlDbType.VarChar).Value = this.login;
                var temp_key = command_for_key.ExecuteScalar();

                //кодирование строки
                var enc = new Encryption();
                string encrypted_text = enc.Crypt_for_online(this.file_text, Convert.ToString(temp_key));

                //сохранение текстового файла
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Текстовые файлы(*.sedf)|*.sedf";
                save.FileName = path;
                try
                {
                    StreamWriter write = new StreamWriter(save.FileName);
                    write.Close();
                }
                catch
                {
                    Directory.CreateDirectory(path_to_folder);
                }
                finally
                {
                    StreamWriter write = new StreamWriter(save.FileName);
                    //запись строки, полученной из байтов в файл
                    write.Write(encrypted_text);

                    //команда добавления файла
                    MySqlCommand command = new MySqlCommand("INSERT INTO `encryptdb`.`users_files` (file_name, file_path, user_id, subject, for_teacher_id) VALUES (@fn, @fp, (SELECT profile_id FROM `encryptdb`.`profiles` WHERE `login` = @ul), @subn, (SELECT profile_id FROM `encryptdb`.`teachers` WHERE `surname` = @sn));", user_db.getConnection());

                    //MessageBox.Show(teachers_listbox.SelectedItem.ToString().Split(' ')[0]);

                    //составление параметров
                    command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = get_new_file_name_with_esdf(this.file_name);
                    command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = path;
                    command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = teachers_listbox.SelectedItem.ToString().Split(' ')[0];
                    command.Parameters.Add("@subn", MySqlDbType.VarChar).Value = subject_textbox.Text;

                    //открытие подключения
                    user_db.openConnection();

                    write.Close();
                    try
                    {
                        //выполнение команды
                        if (command.ExecuteNonQuery() == 1)
                        {
                            status_label.Text = "Successfuly loaded";
                        }
                        else
                        {
                            status_label.Text = "Load error";
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException)
                    {
                        MessageBox.Show("Файл с таким именем уже существует");
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбран преподаватель или предмет");
            }
            
        }
        /// <summary>
        /// создание документа на основе массива байтов
        /// </summary>
        /// <param name="byteArray">входной байтовый массив</param>
        /// <param name="newDocument">путь к документу</param>
        public static void WriteFile(byte[] byteArray, string newDocument)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);
                File.WriteAllBytes(newDocument, stream.ToArray());
            }
        }
        /// <summary>
        /// получает имя файла и преобразует в новое имя с расширением .sedf
        /// </summary>
        /// <param name="name">имя файла со старым расширением</param>
        /// <returns>имя файла с новым расширением</returns>
        private string get_new_file_name_with_esdf(string name)
        {
            string new_file_name = "";
            for (int i = name.Length-1; i > 0; i--)
            {
                if (name[i] == '.')
                {
                    new_file_name = name.Substring(0, i);
                }
            }
            return new_file_name + ".sedf";
        }

        private void list_of_works_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            dataGrid_works.Rows.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT `file_name`, `created_at`, `subject` FROM `encryptdb`.`users_files` WHERE `user_id` = (SELECT `profile_id` FROM `encryptdb`.`profiles` WHERE `login` = @ul)", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGrid_works.Rows.Add(reader.GetString(0), reader.GetString(2), reader.GetString(1));
            }
        }
        private void update_button_Click()
        {
            dataGrid_works.Rows.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT `file_name`, `created_at`, `subject` FROM `encryptdb`.`users_files` WHERE `user_id` = (SELECT `profile_id` FROM `encryptdb`.`profiles` WHERE `login` = @ul)", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGrid_works.Rows.Add(reader.GetString(0), reader.GetString(2), reader.GetString(1));
            }
        }

        private void download_button_Click(object sender, EventArgs e)
        {
            //имя выбранного файла
            string file_name = "";
            file_name = dataGrid_works.CurrentRow.Cells[0].Value.ToString();

            //подключение к базе данных
            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT `file_path` FROM `encryptdb`.`users_files` WHERE `file_name` = @fn", user_db.getConnection());

            //определение параметра
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = file_name;

            //открытие соединения
            command.Connection.Open();

            //выполняем команду
            var temp_path = command.ExecuteScalar();

            //скачиваем файл из папки, в которую нашли путь из БД
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовые файлы(.sedf)|.sedf";
            open.FileName = Convert.ToString(temp_path);
            StreamReader read = new StreamReader(open.FileName);
            
            //содержимое файла
            string file_text = read.ReadToEnd();
            read.Close();

            //команда для получения ключа
            MySqlCommand command_for_key = new MySqlCommand("SELECT `code_key` FROM `encryptdb`.`code_keys` WHERE id = (SELECT profile_id FROM `encryptdb`.`profiles` WHERE `login` = @ul2)", user_db.getConnection());
            //command_for_key.Connection.Open();
            command_for_key.Parameters.Add("@ul2", MySqlDbType.VarChar).Value = this.login;
            var temp_key = command_for_key.ExecuteScalar();

            //кодирование строки
            var enc = new Encryption();
            string decrypted_text = enc.DeCrypt_for_online(file_text, Convert.ToString(temp_key));

            //конвертация строки в байтовый массив
            byte[] output = code.ToHexBytes(decrypted_text);

            //открытие файлового диалога для выбора пути сохранение файла
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Word 97-2003|*.doc|Word Document|*.docx|pdf-file(*.pdf*)|*.pdf*";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

            //создание документа из массива байтов
            WriteFile(output, save.FileName);

            //закрытие потоков
            read.Close();
        }

        private void dataGrid_works_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGrid_works.Rows[e.RowIndex].HeaderCell.Value =
                (e.RowIndex + 1).ToString();
        }

        private void dataGrid_works_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //часть строки для поиска в запросе
            string word_for_search = "%" + search_textbox.Text + "%";

            dataGrid_works.Rows.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT `file_name`, `created_at`, `updated_at` FROM `encryptdb`.`users_files` WHERE `user_id` = (SELECT `profile_id` FROM `encryptdb`.`profiles` WHERE `login` = @ul) AND `file_name` LIKE @sw", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@sw", MySqlDbType.VarChar).Value = word_for_search;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGrid_works.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
        }

        private void choose_teacher_Click(object sender, EventArgs e)
        {
            teachers_listbox.Visible = true;
            teachers_listbox.Items.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT * FROM `encryptdb`.`teachers`", user_db.getConnection());

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            string word_for_searching = find_teacher_textbox.Text;

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                if(word_for_searching == "Поиск по фамилии")
                {
                    word_for_searching = "";
                }
                if (reader.GetString(2).Contains(word_for_searching))
                {
                    teachers_listbox.Items.Add(reader.GetString(2) + " " + reader.GetString(1));
                }
            }
        }

        private void find_teacher_textbox_MouseDown(object sender, MouseEventArgs e)
        {
            find_teacher_textbox.Text = "";
        }

        private void subject_textbox_MouseDown(object sender, MouseEventArgs e)
        {
            subject_textbox.Text = "";
        }
    }
}
