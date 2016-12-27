using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Experience
    {
        public string Position { get; set; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public string CompanyName { get; set; }
        public string WorkType { get; set; }

        public Experience(string position, string startTime, string endTime, string companyName, string workType)
        {
            this.Position = position;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.CompanyName = companyName;
            this.WorkType = workType;
        }
    }
}
