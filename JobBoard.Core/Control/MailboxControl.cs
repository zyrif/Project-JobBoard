using JobBoard.Core.Entity;
using JobBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Control
{
    public class MailboxControl
    {
        MailboxQuery query = new MailboxQuery();

        public MailboxControl()
        {

        }

        public void NewMail(User user, Mail mail)
        {
            DateTime time = DateTime.Now;

        }

    }
}
