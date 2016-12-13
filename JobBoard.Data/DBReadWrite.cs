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

namespace JobBoard.Data
{
    public class DBReadWrite
    {
        static MySqlConnection connection;
        SshClient client;

        public DBReadWrite()
        {
            this.createConnection();
        }

        public void insertQuery(string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MessageBox.Show(query);
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

        //To create Connection with DataBase
        public void createConnection()
        {
            using (client = new SshClient("128.199.155.62", "projectjb", "JbOop2Prjct5.12.16"))
            {
                client.Connect();
                if(client.IsConnected)
                {
                    var pf = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(pf);
                    pf.Start();
                }
            }

            //connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SBS\Documents\JobBoard.mdf;Integrated Security=True;Connect Timeout=30");
            connection = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;UID=JBapp;PASSWORD=jason6;DATABASE=dbJobBoard");
        }

        //To close the connection
        void closeConnection()
        {
            connection.Close();
            
        }
    }
}
