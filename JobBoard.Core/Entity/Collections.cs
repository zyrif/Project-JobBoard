using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    class Collections
    {
         List<string> experience=new List<string>();
         List<string> education = new List<string>();
         List<string> postedjob = new List<string>();

         public void setExperience(string skill)
         {
             experience.Add(skill);
         }
         public List<string> getExperience()
         {
             return experience;
         }

         
        public void setEducation(string edu)
         {
             education.Add(edu);
         }
         public List<string> getExperience()
         {
             return experience;
         }

        
        public void setPostJob(string postjob)
         {
             postedjob.Add(postjob);
         }
         public List<string> getPostJob()
         {
             return postedjob;
         }

    }
}
