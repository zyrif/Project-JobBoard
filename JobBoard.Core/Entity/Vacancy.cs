using JobBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Vacancy
    {
        public string JobTitle { set; get; }
        public int JobId { get; set; }
        public string Company { set; get; }
        public User Recruiter { set; get; }
        public string Location { set; get; }
        public DateTime PostedTime { set; get; }
        public DateTime DeadLine { set; get; }
        public double MinimumSalary { set; get; }
        public double MaximumSalary { set; get; }
        public bool JobType { set; get; }
        public enum EJobType:byte
        {
            Temporary,
            Permanent
        }
        public string JobSummary { set; get; }
        public List<string> skillList;

        public Vacancy(string jobTitle, string company, User recruiter, string location, DateTime postedTime, DateTime deadLine, double minimumSalary, double maximumSalary, bool jobType, string jobSummary, List<string> skillList)
        {
            this.JobTitle = jobTitle;
            this.Company = company;
            this.Recruiter = recruiter;
            this.Location = location;
            this.PostedTime = postedTime;
            this.DeadLine = deadLine;
            this.MinimumSalary = minimumSalary;
            this.MaximumSalary = maximumSalary;
            if((byte)EJobType.Temporary == Convert.ToByte(jobType))
            {
                this.JobType = Convert.ToBoolean(EJobType.Temporary);
            }
            else
            {
                this.JobType = Convert.ToBoolean(EJobType.Permanent);
            }
            this.JobSummary = jobSummary;

            this.skillList = skillList;
        }

        public int getJobId()
        {
            if(JobId != 0)
            {
                JobId = SearchQuery.getInstance().getjobId(this.JobTitle, this.Recruiter.UserId);
            }
            return JobId;
        }
    }
}
