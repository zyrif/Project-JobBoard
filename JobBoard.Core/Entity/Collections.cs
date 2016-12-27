using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Collections
    {
        static Collections instance;

        private Collections()
        {

        }

        public static Collections getInstance()
        {
            if (instance == null)
                instance = new Collections();
            return instance;
        }

        public List<User> user = new List<User>();
        public List<Experience> experience = new List<Experience>();
        public List<Vacancy> postedjob = new List<Vacancy>();
        public List<Mail> mail = new List<Mail>();
    }
}
