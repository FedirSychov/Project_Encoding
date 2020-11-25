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
    public partial class teacher_form : Form
    {
        public teacher_form()
        {
            InitializeComponent();
        }

        private void gooffline_button_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void reg_student_button_Click(object sender, EventArgs e)
        {
            register_student_form rsf = new register_student_form();
            rsf.Show();
            this.Close();
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
    }
}
