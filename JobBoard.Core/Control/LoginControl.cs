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
        UserInfo loginInfo = new UserInfo();
        int systemId;

        public bool login(string userName, string userPassword)
        {
            systemId = loginInfo.getSystemId(userName,userPassword);
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
            DataTable dataTable = loginInfo.getUserInfo(systemId);
            jobSeeker.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            jobSeeker.LastName = dataTable.Rows[0]["LastName"].ToString();
            jobSeeker.Email = dataTable.Rows[0]["Email"].ToString();
            jobSeeker.PhoneNumber = dataTable.Rows[0]["Phone"].ToString();

            dataTable = loginInfo.getBirthday(systemId);
            jobSeeker.BirthDay = dataTable.Rows[0]["BirthDay"].ToString();

            dataTable = loginInfo.getSkill(systemId);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jobSeeker.getSkillList().Add(dataTable.Rows[i]["Skill"].ToString());
            }
        }
    }
}
