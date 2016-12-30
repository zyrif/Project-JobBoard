using JobBoard.Core;
using JobBoard.Core.Control;
using JobBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for MailUC.xaml
    /// </summary>
    public partial class MailUC : UserControl
    {
        User currentUser = User.getInstance();
        Mail mail;
        MailboxWindow mw;

        public MailUC(Mail m, MailboxWindow mw)
        {
            InitializeComponent();
            this.mail = m;
            this.mw = mw;

            PopulateUC();
        }

        private void amail_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = Double.NaN;
        }

        private void amail_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 50;
        }

        private void PopulateUC()
        {
            senderLabel.Content += mail.SenderUserName;
            msgBox.Text = mail.MailSubject;
            msgbodyRTBox.Document.Blocks.Clear();
            msgbodyRTBox.Document.Blocks.Add(new Paragraph(new Run(mail.MailBody)));
            timeLabel.Content = mail.Time.ToString();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mail.SenderUserName == currentUser.UserName)
            {
                if(mail.IsDraft == 0)
                {
                    new MailboxControl().DeleteSenderMail(currentUser, mail);
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mw.Close();
                    newmw.ShowSentMessages();
                }

                else if (mail.IsDraft == 1)
                {
                    new MailboxControl().DeleteSenderMail(currentUser, mail);
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mw.Close();
                    newmw.ShowDraftMessages();
                }

            }
            else if (mail.ReceiverUserName == currentUser.UserName)
            {
                new MailboxControl().DeleteReceiverMail(currentUser, mail);
                MailboxWindow newmw = new MailboxWindow();
                newmw.Show();
                mw.Close();
            }
        }

        private void senderLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoginRegistrationControl lrc = LoginRegistrationControl.getInstance();
            AnotherProfile senderprofile = new AnotherProfile(lrc.GetJobSeekerInfo(mail.SenderUserName));
            senderprofile.Show();
            senderprofile.Activate();
            senderprofile.Topmost = true;  // important
            senderprofile.Focus();
        }

        private void replyBtn_Click(object sender, RoutedEventArgs e)
        {
            WritemailWindow reply = new WritemailWindow(currentUser, mail.SenderUserName);
            reply.Show();
        }
    }
}
