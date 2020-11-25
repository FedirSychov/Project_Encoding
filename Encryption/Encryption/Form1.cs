using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using OpenQA.Selenium.Remote;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Encryption
{
    public partial class Form1 : Form
    {
        public static string new_key_for_crypt = "";
        public static string new_key_for_decrypt = "";
        private Int64 Length = 0;
        
        
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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



        private void button1_Click(object sender, EventArgs e)
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

                    //изменение ключа
                    Form1.new_key_for_crypt = new_key_textbox.Text;

                    //кодирование строки
                    var enc = new Encryption();
                    string encrypted_s = enc.Crypt(s1);

                    //сохранение текстового файла
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Текстовые файлы(*.sedf)|*.sedf";
                    if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
                    StreamWriter write = new StreamWriter(save.FileName);

                    //запись строки, полученной из байтов в файл
                    write.Write(encrypted_s);

                    //закрытие потоков
                    binReader.Close();
                    fileStream.Close();
                    write.Close();
                }
            }
        }

        private void decode_button_Click(object sender, EventArgs e)
        {
            //открытие и чтение содержимого текстового файла
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовые файлы(*.sedf)|*.sedf";
            if (open.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
            StreamReader read = new StreamReader(open.FileName);
            string s = read.ReadToEnd();

            //изменение ключа
            Form1.new_key_for_decrypt = decode_textbox.Text;

            //декодирование строки
            var enc = new Encryption();
            string s1 = enc.DeCrypt(s);

            //выходной байтовый массив
            byte[] output = new byte[Length];

            //конвертация строки в байтовый массив
            output = code.ToHexBytes(s1);

            //открытие файлового диалога для выбора пути сохранение файла
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Word 97-2003|*.doc|Word Document|*.docx|pdf-file(*.pdf*)|*.pdf*";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

            //создание документа из массива байтов
            WriteFile(output, save.FileName);

            //закрытие потоков
            read.Close();
        }

        private void new_key_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //резрешены только цифры, буквы и клавиша BackSpace
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && (e.KeyChar <= 96 || e.KeyChar >= 123)) 
            {
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //резрешены только цифры, буквы и клавиша BackSpace
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && (e.KeyChar <= 96 || e.KeyChar >= 123))
            {
                e.Handled = true;
            }
        }

        private void exit_button_MouseHover_1(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.Red;
        }

        private void exit_button_MouseLeave_1(object sender, EventArgs e)
        {
            exit_button.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void exit_button_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void online_button_Click(object sender, EventArgs e)
        {
            login_form f1_login = new login_form(1);
            f1_login.Show();
            this.Hide();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void help_label_MouseHover(object sender, EventArgs e)
        {
            help_label.BackColor = System.Drawing.Color.Green;
        }

        private void help_label_MouseLeave(object sender, EventArgs e)
        {
            help_label.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void help_label_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void help_label_Click(object sender, EventArgs e)
        {
            Help_form hf = new Help_form();
            hf.Show();
        }

        private void exit_button_MouseMove(object sender, MouseEventArgs e)
        {
            exit_button.Show();
        }
    }
}
