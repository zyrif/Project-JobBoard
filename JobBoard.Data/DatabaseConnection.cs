using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JobBoard.Data
{
    public class DatabaseConnection
    {
        public static SqlConnection sqlConnection;
        public DatabaseConnection()
        {
            this.connect();
        }
        void connect()
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SBS\Documents\JobBoard.mdf;Integrated Security=True;Connect Timeout=30");
        }
        void closeConnection()
        {
            sqlConnection.Close();
        }
    }
}
