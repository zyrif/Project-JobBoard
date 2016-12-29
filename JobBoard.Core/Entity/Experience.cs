using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Experience
    {
        public byte ExpType { get; set; }
        public enum ExtTypeName : byte
        {
            Job,
            Education,
            Award
        }
        public string Title { get; set; }
        public int ExperienceId { set; get; }
        public string Entity { get; set; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public string Details { get; set; }



        public Experience(byte exptype, string title, string entity, DateTime sttime, DateTime edtime, string details)
        {
            this.ExpType = exptype;
            this.Title = title;
            this.Entity = entity;
            this.StartTime = sttime;
            this.EndTime = edtime;
            this.Details = details;
        }

        public Experience(byte exptype, int expId, string title, string entity, DateTime sttime, DateTime edtime, string details)
        {
            this.ExpType = exptype;
            this.ExperienceId = expId;
            this.Title = title;
            this.Entity = entity;
            this.StartTime = sttime;
            this.EndTime = edtime;
            this.Details = details;
        }
    }
}
