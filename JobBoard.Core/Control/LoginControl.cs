using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JobBoard.Data;

namespace JobBoard.Core
{
    public class LoginControl
    {
        UserInfo userInfo = new UserInfo();
        int systemId;

        public bool login(string userName, string userPassword)
        {
            systemId = userInfo.getSystemId(userName,userPassword);
            if (systemId > 0)
            {
                this.initializeUserInfo(systemId);
                return true;
            }
            return false;
        }

        void initializeUserInfo(int systemId)
        {
            JobSeeker jobSeeker = new JobSeeker();
            DataTable dataTable = userInfo.getUserInfo(systemId);
            jobSeeker.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            jobSeeker.LastName = dataTable.Rows[0]["LastName"].ToString();
            jobSeeker.Email = dataTable.Rows[0]["Email"].ToString();
            jobSeeker.PhoneNumber = dataTable.Rows[0]["Phone"].ToString();

            dataTable = userInfo.getBirthday(systemId);
            jobSeeker.BirthDay = dataTable.Rows[0]["BirthDay"].ToString();

            dataTable = userInfo.getSkill(systemId);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jobSeeker.getSkillList().Add(dataTable.Rows[i]["Skill"].ToString());
            }
        }

        public bool checkUser(string userName)
        {
            systemId = userInfo.getSystemId(userName);
            if (systemId > 0)
            {
                this.initializeUserInfo(systemId);
                return true;
            }
            return false;
        }
    }
}
