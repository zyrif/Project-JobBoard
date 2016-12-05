using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    class JobSeeker:User
    {
        List<string> skillList = new List<string>();;

        public string BirthDay { get; set; }
        
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
