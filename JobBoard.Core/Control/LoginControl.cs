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
        LoginInfo loginInfo = new LoginInfo();

        public bool login(string userName, string userPassword)
        {
            if (loginInfo.getSystemId(userName,userPassword) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
