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
        string query;

        public bool getUser(string userName, string passWord)
        {
            query = "select * from LoginInfo where username ='" + userName.Trim() + "' and password='" + passWord.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;
            
            return false;
        }

        public bool getUser(string userName)
        {
            query = "select * from LoginInfo where username ='" + userName.Trim()+"'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;

            return false;
        }

        public DataTable getUserInfo(string userName)
        {
            query = "select * from UserDetail where UserName ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getBirthday(string userName)
        {
            query = "select * from JobSeeker where UserName ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getSkill(string userName)
        {
            query = "select * from Skill where UserName ='" + userName+"'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public void createUser(string userName, string passWord)
        {
            query = "INSERT INTO LoginInfo VALUES ('" + userName + "', '"+ passWord + "')";
            dbReadWrite.insertQuery(query);
        }

        public void createUserProfile(string userName, string firstName, string lastName, string email, string phoneNumber, byte userType)
        {
            query = "INSERT INTO UserDetail (UserName, FirstName, LastName, Email, Phone, UserType) VALUES('" + userName.Trim() + "','" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "'," + userType + ")";
            dbReadWrite.insertQuery(query);
        }
    }
}
