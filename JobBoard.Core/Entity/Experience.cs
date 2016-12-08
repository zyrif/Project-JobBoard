using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    class Experience
    {
        public string Position { get; set; }
        public string TimePeriod { get; set; }
        public string CompanyName { get; set; }
        public string WorkType { get; set; }

        public Experience(string position, string timePeriod, string companyName, string workType)
        {
            this.Position = position;
            this.TimePeriod = timePeriod;
            this.CompanyName = companyName;
            this.WorkType = workType;
        }
    }
}
