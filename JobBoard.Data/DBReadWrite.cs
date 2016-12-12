using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace JobBoard.Data
{
    public class DBReadWrite
    {
        static SqlConnection connection;

        public DBReadWrite()
        {
            this.createConnection();
        }

        public void insertQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MessageBox.Show(query);
        }

        public DataTable selectQuery(string query)
        {
            //Reading Login Data and putting them in a Data Table
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        //To create Connection with DataBase
        public void createConnection()
        {
            if (connection == null)
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SBS\Documents\JobBoard.mdf;Integrated Security=True;Connect Timeout=30");
            //connection = new MySqlConnection(@"SERVER=127.0.0.1;PORT=3306;UID=JBapp;PASSWORD=jason6;DATABASE=dbJobBoard");
        }

        //To close the connection
        void closeConnection()
        {
            connection.Close();
        }
    }
}
