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
        public string Employer { get; set; }

        public Recruiter(string username,string userpass,string firstName,string lastName,string email,string phNumber,string jobposition, string employer):base(username,userpass,firstName, lastName, email, phNumber)
        {
            this.JobPosition = jobposition;
            this.Employer = employer;
        }
    } 
}

