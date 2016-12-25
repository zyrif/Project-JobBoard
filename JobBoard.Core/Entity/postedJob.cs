using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    class PostedJob
    {
        public string JobTitle { set; get; }
        public string Time { set; get; }
        public string JobSummary { set; get; }
        
        public PostedJob(string jobTitle,string time,string jobSummary)
        {
            this.JobTitle = jobTitle;
            this.Time = time;
            this.JobSummary = jobSummary;
        }
    }
}
