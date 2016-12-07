using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobBoard.Data
{
    public class DBReadWrite
    {
        public static SqlConnection sqlConnection;
        public DBReadWrite()
        {
            if(sqlConnection == null)
                this.createConnection();
        }

        public static DataTable selectQuery(string query)
        {
            //Reading Login Data and putting them in a Data Table
            SqlCommand sqlCommand = new SqlCommand(query, DBReadWrite.sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        //To create Connection with DataBase
        public void createConnection()
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SBS\Documents\JobBoard.mdf;Integrated Security=True;Connect Timeout=30");
        }

        //To close the connection
        void closeConnection()
        {
            sqlConnection.Close();
        }
    }
}
