using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    class Recruiter:User
    {
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }

        public Recruiter() { }

        public Recruiter(string userName, string userPass, string firstName, string lastName, string email, string phoneNumber, string jobPosition, string companyName):base(userName, userPass, firstName, lastName, email, phoneNumber)
        {
            this.JobPosition = jobPosition;
            this.CompanyName = companyName;
        }
    } 
}

