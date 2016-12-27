using JobBoard.Core;
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
    /// Interaction logic for RecUserOverviewUC.xaml
    /// </summary>
    public partial class RecUserOverviewUC : UserControl
    {
        User userRef;

        public RecUserOverviewUC(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
            PopulateUO();
        }

        public void PopulateUO()
        {
            this.uwelcomeLabel.Content += userRef.FirstName;
            this.unameLabel.Content += userRef.UserName;
            this.uemailLabel.Content = userRef.Email;
            this.uphoneLabel.Content = userRef.PhoneNumber;
            this.ujobpositionLabel.Content = userRef.JobPosition;
            this.uemployerLabel.Content = userRef.CompanyName;
            this.profileImage.Source = userRef.Photo;

        }
    }
}
