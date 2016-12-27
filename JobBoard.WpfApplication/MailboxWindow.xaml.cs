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
    /// Interaction logic for MailboxWindow.xaml
    /// </summary>
    public partial class MailboxWindow : Window
    {
        User currentUser = User.getInstance();
        Collections collections = Collections.getInstance();

        public MailboxWindow()
        {
            InitializeComponent();
            ShowInboxMessages();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void InboxBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowInboxMessages();
        }


        private void draftBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowDraftMessages();
        }

        private void sentBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowSentMessages();
        }

        private void writemailBtn_Click(object sender, RoutedEventArgs e)
        {
            WritemailWindow wnm = new WritemailWindow(currentUser);
            wnm.Show();
        }


        private void ShowInboxMessages()
        {
            /*MailboxControl mbc = */
            new MailboxControl().InboxMail(currentUser);

            if (this.mailView.Children != null)
                this.mailView.Children.Clear();

            foreach(Mail m in collections.mail)
            {
                if (m.ReceiverUserName == currentUser.UserName && m.ReceiverDeleted!=1)
                {
                    MailUC muc = new MailUC(m);
                    this.mailView.Children.Add(muc);
                }
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    MailUC muc = new MailUC();
            //    this.mailView.Children.Add(muc);
            //}
        }

        private void ShowDraftMessages()
        {
            new MailboxControl().SenderMail(currentUser);

            if (this.mailView.Children != null)
                this.mailView.Children.Clear();


            foreach (Mail m in collections.mail)
            {
                if (m.SenderUserName == currentUser.UserName && m.IsDraft == 1 && m.SenderDeleted != 1)
                {
                    MailUC muc = new MailUC(m);
                    this.mailView.Children.Add(muc);
                }
            }
        }

        private void ShowSentMessages()
        {
            new MailboxControl().SenderMail(currentUser);

            if (this.mailView.Children != null)
                this.mailView.Children.Clear();


            foreach (Mail m in collections.mail)
            {
                if (m.SenderUserName == currentUser.UserName && m.IsDraft != 1 && m.SenderDeleted != 1)
                {
                    MailUC muc = new MailUC(m);
                    this.mailView.Children.Add(muc);
                }
            }
        }
    }
}
