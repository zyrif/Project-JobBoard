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
        DBReadWrite dbReadWrite = new DBReadWrite();
        DataTable dataTable;
        public bool getUser(string userName, string passWord)
        {
            string query = "select * from LoginInfo where username ='" + userName.Trim() + "' and password='" + passWord.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;
            
            return false;
        }

        public bool getUser(string userName)
        {
            string query = "select * from LoginInfo where username ='" + userName.Trim()+"'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;

            return false;
        }

        public DataTable getUserInfo(string userName)
        {
            string query = "select * from UserDetail where UserName ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);


            if (dataTable.Rows.Count > 0)
                System.Windows.Forms.MessageBox.Show("1");
            else
                System.Windows.Forms.MessageBox.Show("2");
            return dataTable;
        }

        public DataTable getBirthday(string userName)
        {
            string query = "select * from JobSeeker where UserName ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getSkill(string userName)
        {
            string query = "select * from Skill where UserName ='" + userName+"'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public void createUser(string userName, string passWord)
        {
            string query = "INSERT INTO LoginInfo VALUES('" + userName.Trim() + "','" + passWord.Trim() + "')";
            dataTable = dbReadWrite.selectQuery(query);
        }
    }
}
