using MySql.Data.MySqlClient;
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
    public partial class sec_pass_form : Form
    {
        public string login_find = "";
        public sec_pass_form()
        {
            InitializeComponent();
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            db user_db = new db();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда
            MySqlCommand command = new MySqlCommand("SELECT sec_password FROM `teachers` WHERE `login` = @ul", user_db.getConnection());

            //определение заглушек
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login_find;

            command.Connection.Open();
            var temp = command.ExecuteScalar();

            if (Convert.ToString(temp) == sec_pass_textbox.Text)
            {
                //teacher_form tf = new teacher_form();
                //this.login_find = "";
                //tf.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
