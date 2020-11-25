using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    //Name: Система шифрования и хранения студенческих работ
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login_form(1));
        }
    }
    //Новая информация по загрузке и выгрузке файлов
    /*
     private DataTable data_bin;

private MySqlDataAdapter da;

private MySqlCommandBuilder cb;

…

//делаем коннект к БД

…

data_bin = new DataTable();

da = new MySqlDataAdapter(

       "SELECT * FROM `myDataBase`.`products`", conn);

cb = new MySqlCommandBuilder(da);

da.Fill(data_bin);

DataColumn column0 = data_bin.Columns.Add("name(string)", typeof(string));

foreach (DataRow rows in data_bin.Rows)

{

rows[column0] = Encoding.UTF8.GetString((byte[])rows["name"]);

}

DataColumn column1 = data_bin.Columns.Add("picture(string)", typeof(string));

foreach (DataRow rows in data_bin.Rows)

{

rows[column1] = Encoding.UTF8.GetString((byte[])rows["description"]);

}

data_bin.Columns.Remove("name");

data_bin.Columns.Remove("description");

DataGridViewString.DataSource = data_bin;


    //Загрузка файлов в базу данных
    byte[] name1 = Encoding.UTF8.GetBytes(dataGridViewString.Rows[i].Cells[1].Value.ToString().Trim()); 

    data_bin = new DataTable();

da = new MySqlDataAdapter(

       "SELECT `name`,`picture` FROM `myDataBase`.`products`", conn);

cb = new MySqlCommandBuilder(da);

da.Fill(data_bin);

foreach (DataRow rows in data_bin.Rows)

{

string str = "C:\\"+Encoding.UTF8.GetString((byte[])rows["name"])+".jpg";

byte[] Img = (byte[])rows["picture"];

FileStream fs = new FileStream(str, FileMode.CreateNew, FileAccess.Write);

fs.Write(Img, 0, Img.Length);

fs.Flush();

fs.Close();

}

    Image image1 = new Bitmap(new MemoryStream((byte[])rows["picture"]);

image1.Save(str, System.Drawing.Imaging.ImageFormat.Jpeg);

    byte[] ReadImageToBytes(string sPath)

{

 byte[] data = null;

 //FileInfo для получения размера файла

 FileInfo fInfo = new FileInfo(sPath);

 long numBytes = fInfo.Length;

 //Открываем поток FileStream для чтения файла

 FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

 //Используем BinaryReader и читаем данные в буфер byte[]

 BinaryReader br = new BinaryReader(fStream);

 data = br.ReadBytes((int)numBytes);

 return data;

}


     */
}
