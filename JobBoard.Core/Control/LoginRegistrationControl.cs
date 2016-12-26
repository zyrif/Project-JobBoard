using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JobBoard.Data;
using System.Windows.Forms;

namespace JobBoard.Core
{
    public class LoginRegistrationControl
    {
        static LoginRegistrationControl instance;
        LoginRegistrationQuery query = LoginRegistrationQuery.getInstance();
        DataTable dataTable;

        private LoginRegistrationControl() { }

        public static LoginRegistrationControl getInstance()
        {
            if (instance == null)
                instance = new LoginRegistrationControl();

            return instance;
        }

        //Login portion
        public bool login(string userName, string userPassword)
        {
            if (query.getUser(userName, userPassword))
            {
                this.initializeUserInfo(userName);
                return true;
            }
            return false;
        }

        //Check user type and initialize all user info
        void initializeUserInfo(string userName)
        {
            dataTable = query.getUserInfo(userName);

            if (Convert.ToByte(dataTable.Rows[0]["user_type"]) == 0)

                initializeJobSeekerInfo(userName);
            else
                initializeRecruiterInfo(userName);
        }

        //After login is verified initialize Job Seeker info
        void initializeJobSeekerInfo(string userName)
        {
            User jobSeeker = User.getInstance();

            jobSeeker.UserName = dataTable.Rows[0]["user_name"].ToString();
            jobSeeker.UserId = Convert.ToInt32(dataTable.Rows[0]["user_id"]);
            jobSeeker.UserType = Convert.ToByte(dataTable.Rows[0]["User_type"]);
            jobSeeker.FirstName = dataTable.Rows[0]["first_name"].ToString();
            jobSeeker.LastName = dataTable.Rows[0]["last_name"].ToString();
            jobSeeker.Email = dataTable.Rows[0]["email"].ToString();
            jobSeeker.PhoneNumber = dataTable.Rows[0]["phone"].ToString();
            jobSeeker.BirthDay = Convert.ToDateTime(dataTable.Rows[0]["birth_day"].ToString());
            jobSeeker.Location = dataTable.Rows[0]["location"].ToString();
           
            dataTable = query.getSkill(Convert.ToInt32(dataTable.Rows[0]["user_id"]));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jobSeeker.getSkillList().Add(dataTable.Rows[i]["skill"].ToString());
            }
        }

        //After login is verified initialize Recruiter info
        void initializeRecruiterInfo(string userName)
        {

            User recruiter = User.getInstance();

            recruiter.UserName = dataTable.Rows[0]["user_name"].ToString();
            recruiter.UserId = Convert.ToInt32(dataTable.Rows[0]["user_id"]);
            recruiter.UserType = Convert.ToByte(dataTable.Rows[0]["user_type"]);

            recruiter.FirstName = dataTable.Rows[0]["first_name"].ToString();
            recruiter.LastName = dataTable.Rows[0]["last_name"].ToString();
            recruiter.Email = dataTable.Rows[0]["email"].ToString();
            recruiter.PhoneNumber = dataTable.Rows[0]["phone"].ToString();

            recruiter.JobPosition = dataTable.Rows[0]["job_position"].ToString();

            recruiter.CompanyName = query.getCompanyName(Convert.ToUInt32(dataTable.Rows[0]["company_id"]));
        }

        //Check if a user name is already taken or registered
        public bool checkUser(string userName)
        {
            if (query.getUser(userName))
            {
                return true;
            }
            return false;
        }

        
        
        ////Registration portion
        //public void register(string userName, string passWord)
        //{
        //    currentUser.UserName = userName;
        //    currentUser.UserPassword = passWord;

        //    query.createUser(userName,passWord);
        //}
        
        ////Register Job Seeker Profile
        //public void register(string firstName, string lastName, string email, string phoneNumber, DateTime birthDay, string location, List<string> skillList)
        //{
        //    query.writeUserInfo(currentUser.UserName, firstName, lastName, email, phoneNumber, birthDay, location, 0);

        //    dataTable = query.getUserInfo(currentUser.UserName);
        //    foreach (string skill in skillList)
        //    {
        //        query.writeSkill(Convert.ToInt32(dataTable.Rows[0]["user_id"]), skill);
        //    }
        //}

        ////Register Recruiter Profile
        //public void register(string firstName, string lastName, string email, string phoneNumber, string jobPosition, string companyName)
        //{
        //    query.writeUserInfo(currentUser.UserName, firstName, lastName, email, phoneNumber, jobPosition, companyName, 1);
        //}

        ////Register Company Information
        //public void registerCompany(string companyName, string address, string country, string phoneNumber, string email, string website, byte businessType)
        //{
        //    query.writeCompanyInfo(companyName, address, country, phoneNumber, email, website, businessType);
        //}


        public void register(User userref)
        {
            if (userref.UserType == 0)
                query.writeJobSeekerInfo(userref.UserName, userref.UserPassword, userref.FirstName, userref.LastName, userref.Email, userref.PhoneNumber, userref.BirthDay, userref.Location, userref.UserType);
            else if (userref.UserType == 1)
                query.writeRecruiterInfo(userref.UserName, userref.UserPassword, userref.FirstName, userref.LastName, userref.Email, userref.PhoneNumber, userref.JobPosition, userref.CompanyName, userref.UserType);
        }

        public List<string> getAvailableSkills()
        {
            dataTable = query.getSkillList();
            List<string> skillList= new List<string>();

            for(int i=0; i<dataTable.Rows.Count; i++)
            {
                skillList.Add(dataTable.Rows[i]["skill"].ToString());
            }

            return skillList;
        }
    }
}
