using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    class Education
    {
        public string DegreeType { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public string InstitutionName { set; get; }

        public Education(string degreeType,string startTime, string endTime, string institutionName)
        {
            this.DegreeType = degreeType;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.InstitutionName = institutionName;
        }
    }
}
