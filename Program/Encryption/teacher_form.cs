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
    public partial class teacher_form : Form
    {
        public static string login = "";
        private static string name = "";
        private static string surname = "";
        private string path_to_folder = @"C:\Users\Asus\Desktop\Studium\3 Семестр\Проект шифрование\local_data_base\";
        private string file_name = "";
        private string file_text = "";
        private static string selected_student = "";
        private string student_name = "";
        private string student_surname = "";
        private int student_id = -1;
        public teacher_form(string loginn)
        {
            InitializeComponent();

            login = loginn;

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT name, surname FROM teachers WHERE profile_id = (SELECT profile_id FROM profiles WHERE login = @ul)", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            name = reader.GetString(0);
            surname = reader.GetString(1);

            update_students();

            this.WindowState = FormWindowState.Maximized;
        }

        private void gooffline_button_Click(object sender, EventArgs e)
        {

        }

        private void reg_student_button_Click(object sender, EventArgs e)
        {
            register_student_form rsf = new register_student_form();
            rsf.Show();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void back_button_Click(object sender, EventArgs e)
        {
            login_form lf = new login_form(1);
            lf.Show();
            this.Close();
        }

        private void teacher_form_Load(object sender, EventArgs e)
        {

        }

        private void update_button_Click(object sender, EventArgs e)
        {
            update_students();
        }
        private void update_students()
        {
            dataGrid_Students.Rows.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT name, surname, (SELECT name FROM groups WHERE id IN (SELECT group_id FROM Students WHERE prof_id IN (SELECT id_prof FROM prof_spec WHERE prof_spec.id_prof IN (SELECT prof_spec_id FROM subjects WHERE subject_id IN (SELECT subject_id FROM teacher_subject WHERE teacher_id IN (SELECT profile_id FROM teachers WHERE name LIKE @tn AND surname LIKE @ts)))))) AS group_name FROM Students WHERE prof_id IN(SELECT id_prof FROM prof_spec WHERE prof_spec.id_prof IN(SELECT prof_spec_id FROM subjects WHERE subject_id IN(SELECT subject_id FROM teacher_subject WHERE teacher_id IN (SELECT profile_id FROM teachers WHERE name LIKE @tn AND surname LIKE @ts))));", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@ts", MySqlDbType.VarChar).Value = surname;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGrid_Students.Rows.Add(reader.GetString(0) + " " + reader.GetString(1), reader.GetString(2));
            }
        }

        private void dataGrid_Students_DoubleClick(object sender, EventArgs e)
        {
            string name_surname = dataGrid_Students.CurrentRow.Cells[0].Value.ToString();
            string name = name_surname.Split(' ')[0];
            student_name = name;
            string surname = name_surname.Split(' ')[1];
            student_surname = surname;

            choose_button.Visible = true;
            load_button.Visible = true;
            file_textbox.Visible = true;
            subject_textbox.Visible = true;

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT `file_name`, `created_at`, `subject` FROM `encryptdb`.`users_files` WHERE `user_id` = (SELECT `profile_id` FROM `encryptdb`.`students` WHERE `name` = @un AND `surname` = @us) AND `users_files`.`for_teacher_id` = (SELECT profile_id FROM teachers WHERE name = @tn AND surname = @ts);", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@us", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = teacher_form.name;
            command.Parameters.Add("@ts", MySqlDbType.VarChar).Value = teacher_form.surname;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            dataGridWorks.Visible = true;
            dataGridWorks.Enabled = true;
            
            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGridWorks.Rows.Add(reader.GetString(0), reader.GetString(2), reader.GetString(1));
            }
        }

        private void back_to_students_button_Click(object sender, EventArgs e)
        {
            dataGridWorks.Rows.Clear();
            dataGridWorks.Enabled = false;
            dataGridWorks.Visible = false;
            student_id = -1;
            choose_button.Visible = false;
            load_button.Visible = false;
            file_textbox.Visible = false;
            subject_textbox.Visible = false;
        }

        private void download_button_Click(object sender, EventArgs e)
        {
            if (dataGridWorks.Enabled == true)
            {
                //имя выбранного файла
                string file_name = "";
                file_name = dataGridWorks.CurrentRow.Cells[0].Value.ToString();

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


                //конвертация строки в байтовый массив
                byte[] output = code.ToHexBytes(file_text);

                //открытие файлового диалога для выбора пути сохранение файла
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Word 97-2003|*.doc|Word Document|*.docx|pdf-file(*.pdf*)|*.pdf*";
                if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

                //создание документа из массива байтов
                WriteFile(output, save.FileName);

                //закрытие потоков
                read.Close();
            }
            else
            {
                MessageBox.Show("Не выбран файл");
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

        private void Search_student_button_Click(object sender, EventArgs e)
        {
            //часть строки для поиска в запросе
            string word_for_search = "%" + search_student_textbox.Text + "%";

            dataGrid_Students.Rows.Clear();

            db user_db = new db();

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT name, surname, (SELECT name FROM groups WHERE id IN (SELECT group_id FROM Students WHERE prof_id IN (SELECT id_prof FROM prof_spec WHERE prof_spec.id_prof IN (SELECT prof_spec_id FROM subjects WHERE subject_id IN (SELECT subject_id FROM teacher_subject WHERE teacher_id IN (SELECT profile_id FROM teachers WHERE name LIKE @tn AND surname LIKE @ts)))))) AS group_name FROM Students WHERE surname LIKE @wfs AND prof_id IN(SELECT id_prof FROM prof_spec WHERE prof_spec.id_prof IN(SELECT prof_spec_id FROM subjects WHERE subject_id IN(SELECT subject_id FROM teacher_subject WHERE teacher_id IN (SELECT profile_id FROM teachers WHERE name LIKE @tn AND surname LIKE @ts))));", user_db.getConnection());

            //добавление параметра
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@ts", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@wfs", MySqlDbType.VarChar).Value = word_for_search;

            //открытие соединения
            command.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            //чтение всех файлов и запись в listbox
            while (reader.Read())
            {
                dataGrid_Students.Rows.Add(reader.GetString(0) + " " + reader.GetString(1), reader.GetString(2));
            }
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
                    this.file_textbox.Text = file_name;

                    binReader.Close();
                }
            }
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            if (subject_textbox.Text != "Название дисциплины" && subject_textbox.Text != "")
            {
                //общий путь
                string path = this.path_to_folder + teacher_form.selected_student + @"\" + get_new_file_name_with_esdf(this.file_name);
                string path_to_folder = this.path_to_folder + teacher_form.selected_student + @"\";
                //Дальше сохранение зашифрованного файла в папку и добавление в БД

                db user_db = new db();

                System.Data.DataTable table = new System.Data.DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command_for_student_id = new MySqlCommand("SELECT `profile_id` FROM `encryptdb`.`students` WHERE `name` = @un AND `surname` = @us;", user_db.getConnection());

                //добавление параметра
                command_for_student_id.Parameters.Add("@un", MySqlDbType.VarChar).Value = student_name;
                command_for_student_id.Parameters.Add("@us", MySqlDbType.VarChar).Value = student_surname;

                //открытие подключения
                user_db.openConnection();

                student_id = Convert.ToInt32(command_for_student_id.ExecuteScalar().ToString());
                MessageBox.Show(Convert.ToString(student_id));

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
                    write.Write(this.file_text);

                    //команда добавления файла
                    MySqlCommand command = new MySqlCommand("INSERT INTO `encryptdb`.`users_files` (file_name, file_path, user_id, subject, for_teacher_id) VALUES (@fn, @fp, @uid, @subn, (SELECT profile_id FROM `encryptdb`.`profiles` WHERE `login` = @tl));", user_db.getConnection());

                    //MessageBox.Show(teachers_listbox.SelectedItem.ToString().Split(' ')[0]);

                    //составление параметров
                    command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = get_new_file_name_with_esdf(this.file_name);
                    command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = path;
                    command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = student_id;
                    command.Parameters.Add("@tl", MySqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@subn", MySqlDbType.VarChar).Value = subject_textbox.Text;

                    write.Close();
                    try
                    {
                    //выполнение команды
                    if (command.ExecuteNonQuery() == 1)
                    {
                        file_textbox.Text = "Successfuly loaded";
                    }
                    else
                    {
                        file_textbox.Text = "Load error";
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
                MessageBox.Show("Не выбран предмет");
           }
        }

        private void subject_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            subject_textbox.Text = "";
        }
        private string get_new_file_name_with_esdf(string name)
        {
            string new_file_name = "";
            for (int i = name.Length - 1; i > 0; i--)
            {
                if (name[i] == '.')
                {
                    new_file_name = name.Substring(0, i);
                }
            }
            return new_file_name + ".sedf";
        }
    }
}
