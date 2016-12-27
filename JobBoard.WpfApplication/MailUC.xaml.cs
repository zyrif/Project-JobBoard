using JobBoard.Core;
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

        public MailUC(Mail m)
        {
            InitializeComponent();
            this.mail = m;

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
            timeLabel.Content += mail.Time.ToString();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser.UserName == mail.SenderUserName)
                mail.SenderDeleted = 1;
            else if (currentUser.UserName == mail.ReceiverUserName)
                mail.ReceiverDeleted = 1;
        }
    }
}
