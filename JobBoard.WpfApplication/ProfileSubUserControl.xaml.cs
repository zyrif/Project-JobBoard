using JobBoard.Core;
using JobBoard.Core.Entity;
using JobBoard.Data;
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
    /// Interaction logic for ProfileSubUserControl.xaml
    /// </summary>
    public partial class ProfileSubUserControl : UserControl
    {
        Profile p;
        public ProfileSubUserControl(Profile p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void UserInbox_Click(object sender, RoutedEventArgs e)
        {
            MailboxWindow mbw = new MailboxWindow();
            mbw.Show();
        }

        private void UserLogout_Click(object sender, RoutedEventArgs e)
        {
            Collections.clearInstance();
            User.clearInstance();
            LoginRegistrationControl.clearInstance();
            DBReadWrite.clearInstance();
            LoginRegister lr = new LoginRegister();
            lr.Show();
            p.Close();
        }
    }
}
