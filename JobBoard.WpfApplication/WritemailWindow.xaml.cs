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
using System.Windows.Shapes;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for WritemailWindow.xaml
    /// </summary>
    public partial class WritemailWindow : Window
    {
        User userRef;
        MailboxWindow mailbox;
        MailboxControl mbc = new MailboxControl();
        bool isReply = false;
        bool fromMailbox = false;
        string sendername;

        public WritemailWindow()
        {
            InitializeComponent();
            this.userRef = User.getInstance();
        }

        public WritemailWindow(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
        }

        public WritemailWindow(User usr, MailboxWindow mailbox)
        {
            InitializeComponent();
            this.userRef = usr;
            this.mailbox = mailbox;
            fromMailbox = true;
        }

        public WritemailWindow(User usr, string sendername, string mailSubject, MailboxWindow mailbox)
        {
            InitializeComponent();
            this.userRef = usr;
            this.mailbox = mailbox;
            this.sendername = sendername;
            recipientBox.Text = sendername;
            subjBox.Text = "Re: " + mailSubject;
            isReply = true;
            fromMailbox = true;

        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            //save message to draft.
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isReply)
            {
                string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
                Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, this.sendername, DateTime.Now, 0);
                mbc.NewMail(newmail);
                if(fromMailbox)
                {
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mailbox.Close();
                    newmw.ShowSentMessages();
                }
                this.Close();
            }

            else
            {
                string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
                Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, recipientBox.Text, DateTime.Now, 0);
                mbc.NewMail(newmail);
                if (fromMailbox)
                {
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mailbox.Close();
                    newmw.ShowSentMessages();
                }
                this.Close();
            }
        }

        private void draftBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isReply)
            {
                string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
                Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, this.sendername, DateTime.Now, 1);
                mbc.NewMail(newmail);
                if (fromMailbox)
                {
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mailbox.Close();
                    newmw.ShowDraftMessages();
                }
                this.Close();
            }

            else
            {
                string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
                Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, recipientBox.Text, DateTime.Now, 1);
                mbc.NewMail(newmail);
                if (fromMailbox)
                {
                    MailboxWindow newmw = new MailboxWindow();
                    newmw.Show();
                    mailbox.Close();
                    newmw.ShowDraftMessages();
                }
                this.Close();
            }
        }

        private void Write_Mail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
