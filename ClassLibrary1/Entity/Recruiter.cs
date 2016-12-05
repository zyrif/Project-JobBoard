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
    }
}
