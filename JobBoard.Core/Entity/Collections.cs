using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    class Collections
    {
        public List<User> user = new List<User>();
        public List<Experience> experience = new List<Experience>();
        public List<Vacancy> postedjob = new List<Vacancy>();
    }
}
