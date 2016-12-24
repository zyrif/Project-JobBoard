using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class LoginRegistrationQuery
    {
        DBReadWrite dbReadWrite = DBReadWrite.getInstance();
        DataTable dataTable;
        static LoginRegistrationQuery instance;
        string query, subQuery;

        private LoginRegistrationQuery() { }

        public static LoginRegistrationQuery getInstance()
        {
            if (instance == null)
                instance = new LoginRegistrationQuery();

            return instance;
        }

        public bool getUser(string userName, string passWord)
        {
            query = "select * from user_info where username ='" + userName.Trim() + "' and pass='" + passWord.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;
            
            return false;
        }

        public bool getUser(string userName)
        {
            query = "select * from login_info where user_name ='" + userName.Trim()+"'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;

            return false;
        }

        public DataTable getUserInfo(string userName)
        {
            query = "select * from user_info where user_name ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
        
        public DataTable getSkill(int userId)
        {
            query = "select * from user_skill where user_id =" + userId;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
        
        //User Registration Portion
        public void createUser(string userName, string passWord)
        {
            query = "INSERT INTO user_info (user_name, pass) VALUES ('" + userName + "', '"+ passWord + "')";
            dbReadWrite.insertQuery(query);
        }

        public void writeUserInfo(string userName, string firstName, string lastName, string email, string phoneNumber, string jobPosition, string companyName, byte userType)
        {
            subQuery = "(select company_id from company_info where company_name='" + companyName + "')";
            query = "INSERT INTO user_info (first_name, last_name, email, phone, job_position, company_id, user_type) VALUES('" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "','" + jobPosition.Trim() + "'," + subQuery + "," + userType + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeUserInfo(string userName, string firstName, string lastName, string email, string phoneNumber, DateTime birthDay, string location, byte userType)
        {
            query = "INSERT INTO user_info (first_name, last_name, email, phone, birth_day, location, user_type) VALUES('" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "'," + birthDay + ",'" + location.Trim() + "'," + userType + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeSkill(string userId, string skill)
        {
            subQuery = "(select skill_id from skill_list where skill='" + skill.Trim() + "')";
            query = "INSERT INTO user_skill(user_id, skill_id) VALUES(" + userId + ",'" + subQuery + "')";
            dbReadWrite.insertQuery(query);
        }
        
        //Company Registration Portion
        public void writeCompanyInfo(string companyName, string address, string country, string phone, string email, string website, byte businessType)
        {
            query = "INSERT INTO Company VALUES ('" + companyName.Trim() + "','" + address.Trim() + "','" + country + "','"+ phone.Trim() + "','" + email.Trim() + "','" + website.Trim() + "'," + ")";
            dbReadWrite.insertQuery(query);
        }
        
        public int getCompanyId(string companyName)
        {
            query = "select company_id from company_info where company_name ='" + companyName.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return Convert.ToInt32(dataTable.Rows[0]["company_id"]);
        }

        public string getCompanyName(uint companyId)
        {
            query = "select company_name from company_info where company_id =" + companyId;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable.Rows[0]["company_name"].ToString();
        }
    }
}
