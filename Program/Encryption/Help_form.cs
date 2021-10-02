using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Help_form : Form
    {
        public Help_form()
        {
            InitializeComponent();
            help_richtextbox.Text += "Нажмите \"закодировать\" для кодирования файла. Для использования собственного ключа кодирования введите его перед кодированием слева от кнопки \"Кодировать\".Нажмите \"декодировать\" для декодирования файла. Для использования собственного ключа декодирования сначала введите его перед слева от кнопки \"Декодировать\".Для перехода в режим онлайн, нажмите кнопку \"Режим онлайн\" и пройдите авторизацию";
            //Press \"Encode\" to encode the file. If you want to choose unique key for encoding, first write the key left of \"Encode\" button.\n\nPress \"Decode\" to Decode the file. If you want to choose unique key for decoding, first write the key left of \"Decode\" button.\n\nYou can go to online-mode pressing the \"Go Online\" button.
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
            this.Close();
        }

        private void Help_form_Load(object sender, EventArgs e)
        {

        }

        private void Help_form_MouseDown(object sender, MouseEventArgs e)
        {
                base.Capture = false;
                Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);   
        }

        private void help_richtextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
