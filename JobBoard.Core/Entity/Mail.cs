using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Entity
{
    public class Mail
    {
        public int MailId { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string SenderUserName { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverUserName { get; set; }
        public DateTime Time { get; set; }
        public byte IsDraft { get; set; }
        public byte SenderDeleted { get; set; }
        public byte ReceiverDeleted { get; set; }

        public Mail()
        {

        }

        public Mail(string mailsub, string mailbody, string sendusr, string recusr, DateTime time, byte isdraft)
        {
            this.MailSubject = mailsub;
            this.MailBody = mailbody;
            this.SenderUserName = sendusr;
            this.ReceiverUserName = recusr;
            this.Time = time;
            this.IsDraft = isdraft;
        }

    }
}
