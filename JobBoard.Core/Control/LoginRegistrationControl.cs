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
        LoginRegistrationQuery query = new LoginRegistrationQuery();
        DataTable dataTable;

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

        void initializeUserInfo(string userName)
        {
            dataTable = query.getUserInfo(userName);
            if (Convert.ToByte(dataTable.Rows[0]["UserType"]) == 0)
                initializeJobSeekerInfo(userName);
            else
                initializeEmployerInfo(userName);
        }

        void initializeJobSeekerInfo(string userName)
        {
            JobSeeker jobSeeker = new JobSeeker();

            jobSeeker.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            jobSeeker.LastName = dataTable.Rows[0]["LastName"].ToString();
            jobSeeker.Email = dataTable.Rows[0]["Email"].ToString();
            jobSeeker.PhoneNumber = dataTable.Rows[0]["Phone"].ToString();
            jobSeeker.BirthDay = Convert.ToDateTime(dataTable.Rows[0]["BirthDay"].ToString());
           
            dataTable = query.getSkill(userName);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jobSeeker.getSkillList().Add(dataTable.Rows[i]["Skill"].ToString());
            }

            
        }

        void initializeEmployerInfo(string userName)
        {
            Recruiter recruiter = new Recruiter();

            recruiter.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            recruiter.LastName = dataTable.Rows[0]["LastName"].ToString();
            recruiter.Email = dataTable.Rows[0]["Email"].ToString();
            recruiter.PhoneNumber = dataTable.Rows[0]["Phone"].ToString();
            recruiter.JobPosition = dataTable.Rows[0]["BirthDay"].ToString();
            recruiter.CompanyId = Convert.ToUInt32(dataTable.Rows[0]["CompanyId"]);
        }

        public bool checkUser(string userName)
        {
            if (query.getUser(userName))
            {
                return true;
            }
            return false;
        }

        //Registration portion
        public void register(string userName, string passWord)
        {
            User.currentUser.UserName = userName;
            User.currentUser.UserPassword = passWord;

            query.createUser(userName,passWord);
        }
        
        void registerCommonProfileInfo(string firstName,string lastName,string email,string phoneNumber,byte userType)
        {
            //Writes information into Datatbase
            query.writeCommonUserInfo(User.currentUser.UserName, firstName, lastName, email, phoneNumber, userType);
        }
        
        public void register(string firstName, string lastName, string email, string phoneNumber, string birthDay, string location, List<string> skillList)
        {
            registerCommonProfileInfo(firstName, lastName, email, phoneNumber, 0);
            query.writeBirthDay(User.currentUser.UserName, Convert.ToDateTime(birthDay));
            foreach(string skill in skillList)
            {
                query.writeSkill(User.currentUser.UserName, skill);
            }
        }

        public void register(string firstName, string lastName, string email, string phoneNumber, string jobPosition, int companyId)
        {
            registerCommonProfileInfo(firstName, lastName, email, phoneNumber, 1);
            query.writeAdditionalEmployerInfo(User.currentUser.UserName, jobPosition, companyId);
        }
    }
}
