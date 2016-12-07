using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class UserInfo
    {
        DataTable dataTable;
        public int getSystemId(string userName, string passWord)
        {
            string query = "select * from LoginInfo where username ='" + userName.Trim() + "' and password='" + passWord.Trim() + "'";
            dataTable = DBReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return Convert.ToInt32(dataTable.Rows[0]["SystemId"]);
            else
                return -1;
        }

        public int getSystemId(string userName)
        {
            string query = "select * from LoginInfo where username ='" + userName.Trim()+"'";
            dataTable = DBReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return Convert.ToInt32(dataTable.Rows[0]["SystemId"]);
            else
                return -1;
        }

        public DataTable getUserInfo(int systemId)
        {
            string query = "select * from UserDetail where SystemId =" + systemId;
            dataTable = DBReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getBirthday(int systemId)
        {
            string query = "select * from JobSeeker where SystemId =" + systemId;
            dataTable = DBReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getSkill(int systemId)
        {
            string query = "select * from Skill where SystemId =" + systemId;
            dataTable = DBReadWrite.selectQuery(query);

            return dataTable;
        }
    }
}
