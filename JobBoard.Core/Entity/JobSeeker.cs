using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    class JobSeeker : User
    {
        public List<string> skillList = new List<string>();
        DateTime birthDay;
        public string Location { set; get; }

        public DateTime BirthDay
        {
            set { this.birthDay = Convert.ToDateTime(value); }
            get { return this.birthDay; }
        }
        
        public void setSkill(string skill)
        {
            skillList.Add(skill);
        }

        public List<string> getSkillList()
        {
            return skillList;
        }
    }
}
