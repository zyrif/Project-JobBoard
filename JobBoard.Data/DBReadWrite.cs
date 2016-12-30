using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using Renci.SshNet;
using System.Threading;

namespace JobBoard.Data
{
    public class DBReadWrite
    {
        public MySqlConnection connection;
        static DBReadWrite instance;

        DBReadWrite()
        {
            if (connection == null)
                createConnection();
        }

        public static DBReadWrite getInstance()
        {
            if (instance == null)
                instance = new DBReadWrite();

            return instance;
        }

        public void insertQuery(string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
        }

        public DataTable selectQuery(string query)
        {
            //Reading Login Data and putting them in a Data Table

            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;

        }

        public void updateQuery(string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
        }

        public void insertimageQuery(MySqlCommand sqlCommand)
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
        }

        //To create Connection with DataBase
        public void createConnection()
        {
            //string conn = "server=127.0.0.1;PORT=3306;userid=sql8150587;password=5CgPsYX9BJ;database=sql8150587";
            string conn = "server=127.0.0.1;PORT=3306;userid=root;password=nopass;database=project_jb";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = conn;
                connection.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //To close the connection
        void closeConnection()
        {
            connection.Close();
        }

        public static void clearInstance()
        {
            instance = null;
        }
    }
}
