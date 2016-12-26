using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Mail
    {
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Time { get; set; }
        public string MailType { get; set; }

        public Mail(string mailsub, string mailbody, int senderid, int receiverid, DateTime time, string mailtype)
        {
            this.MailSubject = mailsub;
            this.MailBody = mailbody;
            this.SenderId = senderid;
            this.ReceiverId = receiverid;
            this.Time = time;
            this.MailType = mailtype;
        }

    }
}
