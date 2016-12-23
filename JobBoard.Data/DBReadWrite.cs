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
        static SqlConnection connection;
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
            //using (client = new SshClient("128.199.155.62", "projectjb", "JbOop2Prjct5.12.16"))
            //{
            //    client.Connect();
            //    if (client.IsConnected)
            //    {
            //        ForwardedPortDynamic pf = new ForwardedPortDynamic("127.0.0.1", 3306);
            //        client.AddForwardedPort(pf);
            //        pf.Start();
            //        if (pf.IsStarted)
            //            MessageBox.Show("Port forward started in " + pf.BoundHost + ":" + pf.BoundPort);
            //    }
            //    else
            //        MessageBox.Show("Error while establishing ssh connection to the server.");
            //}

            if (connection == null)
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\git-source-folder\Project-JobBoard\JobBoard.Data\JobBoard.mdf;Integrated Security=True;Connect Timeout=30");
            //connection = new MySqlConnection("Server=127.0.0.1; Database=dbJobBoard; Uid=JBapp; Password=jason6;");
        }

        //To close the connection
        void closeConnection()
        {
            connection.Close();

        }
    }
}
