using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Encryption
{
    class db
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=encryptdb");

        /// <summary>
        /// открыть соединение
        /// </summary>
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        /// <summary>
        /// закрыть соединение
        /// </summary>
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        /// <summary>
        /// получить статус соединения
        /// </summary>
        /// <returns>соединение</returns>
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
