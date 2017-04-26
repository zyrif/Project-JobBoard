using JobBoard.Core.Entity;
using JobBoard.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Control
{
    public class MailboxControl
    {
        MailboxQuery query = new MailboxQuery();
        DataTable dataTable = new DataTable();
        Collections collections = Collections.getInstance();

        public MailboxControl()
        {

        }

        public void NewMail(Mail mail)
        {
            DateTime time = DateTime.Now;
            query.NewMailQuery(mail.MailSubject, mail.MailBody, mail.SenderUserName, mail.ReceiverUserName, mail.Time, mail.IsDraft);

        }

        public void InboxMail(User user)
        {
            dataTable = query.RetriveInboxMailQuery(user.UserName);

            collections.mail.Clear();
            foreach(DataRow row in dataTable.Rows)
            {
                Mail mail = new Mail();

                mail.MailId = Convert.ToInt32(row["mail_id"]);
                mail.MailSubject = row["mail_subject"].ToString();
                mail.MailBody = row["mail_body"].ToString();
                mail.SenderUserName = row["sender_id"].ToString();
                mail.ReceiverUserName = row["receiver_id"].ToString();
                mail.Time = Convert.ToDateTime(row["time"].ToString());
                mail.IsDraft = Convert.ToByte(row["isdraft"]);
                mail.SenderDeleted = Convert.ToByte(row["sender_isdeleted"]);
                mail.ReceiverDeleted = Convert.ToByte(row["receiver_isdeleted"]);

                collections.mail.Add(mail);

            }
        }

        public void SenderMail(User user)
        {
            dataTable = query.RetriveSenderMailQuery(user.UserName);

            collections.mail.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                Mail mail = new Mail();

                mail.MailId = Convert.ToInt32(row["mail_id"]);
                mail.MailSubject = row["mail_subject"].ToString();
                mail.MailBody = row["mail_body"].ToString();
                mail.SenderUserName = row["sender_id"].ToString();
                mail.ReceiverUserName = row["receiver_id"].ToString();
                mail.Time = Convert.ToDateTime(row["time"].ToString());
                mail.IsDraft = Convert.ToByte(row["isdraft"]);
                mail.SenderDeleted = Convert.ToByte(row["sender_isdeleted"]);
                mail.ReceiverDeleted = Convert.ToByte(row["receiver_isdeleted"]);

                collections.mail.Add(mail);

            }
        }

        public void DeleteSenderMail(User user, Mail mail)
        {
            query.SenderDeleteMail(user.UserName, mail.MailId);
        }

        public void DeleteReceiverMail(User user, Mail mail)
        {
            query.ReceiverDeleteMail(user.UserName, mail.MailId);
        }



    }
}
