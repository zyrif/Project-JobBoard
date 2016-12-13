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
        static UserInfo userInfo = new UserInfo();

        public bool login(string userName, string userPassword)
        {
            if (userInfo.getUser(userName, userPassword))
            {
                //this.initializeUserInfo(userName);
                return true;
            }
            return false;
        }

        void initializeUserInfo(string userName)
        {
            JobSeeker jobSeeker = new JobSeeker();
            DataTable dataTable = userInfo.getUserInfo(userName);
            jobSeeker.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            jobSeeker.LastName = dataTable.Rows[0]["LastName"].ToString();
            jobSeeker.Email = dataTable.Rows[0]["Email"].ToString();
            jobSeeker.PhoneNumber = dataTable.Rows[0]["Phone"].ToString();

            dataTable = userInfo.getBirthday(userName);
            jobSeeker.BirthDay = Convert.ToDateTime(dataTable.Rows[0]["BirthDay"].ToString());

            dataTable = userInfo.getSkill(userName);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jobSeeker.getSkillList().Add(dataTable.Rows[i]["Skill"].ToString());
            }
        }

        public bool checkUser(string userName)
        {
            if (userInfo.getUser(userName))
            {
                return true;
            }
            return false;
        }

        public void register(string userName, string passWord)
        {
            User.currentUser.UserName = userName;
            User.currentUser.UserPassword = passWord;

            userInfo.createUser(userName,passWord);
        }

        public void registerProfile(string firstName,string lastName,string email,string phoneNumber,byte userType)
        {
            User.currentUser.FirstName = firstName;
            User.currentUser.LastName = lastName;
            User.currentUser.Email = email;
            User.currentUser.PhoneNumber = phoneNumber;

            //Writes information into Datatbase
            userInfo.writeCommonUserInfo(User.currentUser.UserName, firstName, lastName, email, phoneNumber, userType);
        }
    }
}
