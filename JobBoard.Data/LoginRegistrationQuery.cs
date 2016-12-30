using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBoard.Data
{
    public class LoginRegistrationQuery
    {
        DBReadWrite dbReadWrite;
        DataTable dataTable;
        static LoginRegistrationQuery instance;
        string query, subQuery;

        private LoginRegistrationQuery()
        {
            dbReadWrite = DBReadWrite.getInstance();
        }

        public static LoginRegistrationQuery getInstance()
        {
            if (instance == null)
                instance = new LoginRegistrationQuery();

            return instance;
        }

        public bool getUser(string userName, string passWord)
        {
            query = "select * from user_info where user_name ='" + userName.Trim() + "' and pass='" + passWord.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;
            
            return false;
        }

        public bool getUser(string userName)
        {
            query = "select * from user_info where user_name ='" + userName.Trim()+"'";
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
        //public void createUser(string userName, string passWord)
        //{
        //    query = "INSERT INTO user_info (user_name, pass) VALUES ('" + userName + "', '"+ passWord + "')";
        //    dbReadWrite.insertQuery(query);
        //}

        //public void writeUserInfo(string userName, string firstName, string lastName, string email, string phoneNumber, string jobPosition, string companyName, byte userType)
        //{
        //    subQuery = "(select company_id from company_info where company_name='" + companyName + "')";
        //    query = "UPDATE user_info SET first_name='" + firstName.Trim() + "',last_name='" + lastName.Trim() + "',email='" + email.Trim() + "',phone='" + phoneNumber.Trim() + "',job_position='" + jobPosition + "',company_id=" + subQuery + ",user_type=" + userType + " WHERE user_name='" + userName.Trim() + "'";
        //    dbReadWrite.insertQuery(query);
        //}

        //public void writeUserInfo(string userName, string passWord, string firstName, string lastName, string email, string phoneNumber, DateTime birthDay, string location, byte userType)
        //{
        //    query = "UPDATE user_info SET first_name='" + firstName.Trim() + "',last_name='" + lastName.Trim() + "',email='" + email.Trim() + "',phone='" + phoneNumber.Trim() + "',birth_day='" + birthDay.ToString("yyyy-MM-dd") + "',location='" + location.Trim() + "',user_type=" + userType + " WHERE user_name='" + userName.Trim() + "'";
        //    dbReadWrite.insertQuery(query);
        //}

        public void writeJobSeekerInfo(string userName, string passWord, string firstName, string lastName, string email, string phoneNumber, DateTime birthDay, string location, byte userType)
        {
            query = "INSERT INTO user_info (user_name, pass, first_name, last_name, email, phone, birth_day, location, user_type) VALUES ('" + userName.Trim() + "','" + passWord + "','" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "','" + birthDay.ToString("yyyy-MM-dd") + "','" + location.Trim() + "'," + userType + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeRecruiterInfo(string userName, string passWord, string firstName, string lastName, string email, string phoneNumber, string jobPosition, string companyName, byte userType)
        {
            query = "INSERT INTO user_info (user_name, pass, first_name, last_name, email, phone, job_position, company_id, user_type) VALUES ('" + userName.Trim() + "','" + passWord + "','" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "','" + jobPosition.Trim() + "','" + getCompanyId(companyName) + "'," + userType + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeSkill(int userId, string skill)
        {
            subQuery = "(select skill_id from skill_list where skill='" + skill.Trim() + "')";
            query = "INSERT INTO user_skill(user_id, skill_id) VALUES(" + userId + "," + subQuery + ")";
            dbReadWrite.insertQuery(query);
        }

        public void addimage(string username, byte[] image)
        {
            DBReadWrite.getInstance().insertimageQuery(username, image);
        }
        
        //Company Registration Portion
        public void writeCompanyInfo(string companyName, string address, string country, string phone, string email, string website, byte businessType)
        {
            query = "INSERT INTO company_info(company_name,HQ_location,country,phone,email,website,business_type) VALUES ('" + companyName.Trim() + "','" + address.Trim() + "','" + country + "','"+ phone.Trim() + "','" + email.Trim() + "','" + website.Trim() + "'," + businessType+")";
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

        public DataTable getAllRegisteredCompany()
        {
            query = "select distinct company_name from company_info";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getSkillList()
        {
            query = "select skill from skill_list";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public void UpdateJSInfo(string fname, string lname, string email, string phone, DateTime birthday, string location, int userid)
        {
            query = "update user_info set first_name='" + fname.Trim() + "', last_name='"+lname.Trim()+"',email='"+email.Trim()+"',phone='"+phone.Trim()+"', birth_day='"+birthday.ToString("yyyy-MM-dd")+"', location='"+location.Trim()+"' where user_id = "+userid;
            dbReadWrite.insertQuery(query);
        }

        public void DeleteJSSkill(int id)
        {
            query = "Delete from user_skill where user_id=" + id;
            dbReadWrite.insertQuery(query);
        }
    }
}
