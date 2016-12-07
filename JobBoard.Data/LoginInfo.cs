using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class LoginInfo
    {
        public int getSystemId(string userName, string passWord)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from LoginInfo where username ='" + userName.Trim() + "' and password='" + passWord.Trim() + "'", DatabaseConnection.sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
                return Convert.ToInt32(dataTable.Rows[0]["SystemId"]);
            else
                return -1;
        }
    }
}
