using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class PostedJob
    {
        public string JobTitle { set; get; }
        public string Company { set; get; }
        public string Recruiter { set; get; }
        public string Location { set; get; }
        public DateTime PostedTime { set; get; }
        public DateTime DeadLine { set; get; }
        public double MinimumSalary { set; get; }
        public double MaximumSalary { set; get; }
        public string JobType { set; get; }
        public enum EJobType:byte
        {
            Temporary,
            Permanent
        }
        public string JobSummary { set; get; }
        public List<string> skillList;

        public PostedJob(string jobTitle, string company, string recruiter, string location, DateTime postedTime, DateTime deadLine, double minimumSalary, double maximumSalary, bool jobType, string jobSummary, List<string> skillList)
        {
            this.JobTitle = jobTitle;
            this.Company = company;
            this.Recruiter = recruiter;
            this.Location = location;
            this.PostedTime = postedTime;
            this.DeadLine = deadLine;
            this.MinimumSalary = minimumSalary;
            this.MaximumSalary = maximumSalary;
            if((byte)EJobType.Permanent == Convert.ToByte(jobType))
            {
                this.JobType = EJobType.Temporary.ToString();
            }
            else
            {
                this.JobType = EJobType.Permanent.ToString();
            }
            this.JobSummary = jobSummary;

            this.skillList = skillList;
        }
    }
}
