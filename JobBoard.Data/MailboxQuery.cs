using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class MailboxQuery
    {
        DBReadWrite dbReadWrite = DBReadWrite.getInstance();
        DataTable dataTable = new DataTable();
        string query;

        public MailboxQuery()
        {

        }


        public void NewMailQuery(string subject, string body, string senderid, string receiverid, DateTime time, byte isdraft)
        {
            query = "INSERT INTO mail_box (mail_subject, mail_body, sender_id, receiver_id, time, isdraft) VALUES ('" + subject.Trim() + "', '" + body.Trim() + "', '" + senderid.Trim() + "', '" + receiverid.Trim() + "', '" + time.ToString("yyyy-MM-dd") + "', " + isdraft + ")";
            dbReadWrite.insertQuery(query);
        }

        public DataTable RetriveInboxMailQuery(string id)
        {
            query = "SELECT * from mail_box where receiver_id='" + id.Trim() + "' and receiver_isdeleted=0";
            return dbReadWrite.selectQuery(query);
        }

        public DataTable RetriveSenderMailQuery(string id)
        {
            query = "SELECT * from mail_box where sender_id='" + id.Trim() + "' and sender_isdeleted=0";
            return dbReadWrite.selectQuery(query);
        }

        public void UpdateIsDraft(string id, byte value)
        {
            query = "UPDATE mail_box set isdraft=" + value + " where sender_id='" + id.Trim() + "'";
            dbReadWrite.updateQuery(query);
        }

        public void SenderDeleteMail(string userid, int mailid)
        {
            query = "UPDATE mail_box set sender_isdeleted=1 where sender_id='" + userid.Trim() + "' and mail_id=" + mailid + "";
            dbReadWrite.updateQuery(query);
        }

        public void ReceiverDeleteMail(string userid, int mailid)
        {
            query = "UPDATE mail_box set receiver_isdeleted=1 where receiver_id='" + userid.Trim() + "' and mail_id=" + mailid + "";
            dbReadWrite.updateQuery(query);
        }

    }
}
