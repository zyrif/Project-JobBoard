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
    /// Interaction logic for CandidateBoxUC.xaml
    /// </summary>
    public partial class CandidateBoxUC : UserControl
    {
        User user;

        public CandidateBoxUC(User user)
        {

            InitializeComponent();
            this.user = user;
            nameLabel.Content = user.FirstName + " " + user.LastName;
            locationLabel.Content = user.Location;
            emailLabel.Content = user.Email;
            phoneLabel.Content = user.PhoneNumber;
            foreach(string skill in user.SkillList)
            {
                Button button = new Button();
                button.Content = skill;
                skillsPanel.Children.Add(button);
            }
        }

        private void conBtn_Click(object sender, RoutedEventArgs e)
        {
            WritemailWindow newmail = new WritemailWindow();
            newmail.recipientBox.Text = user.UserName;
            newmail.Show();
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CandidateBox_MouseEnter(object sender, MouseEventArgs e)
        {
            CandidateBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff353536");
        }

        private void CandidateBox_MouseLeave(object sender, MouseEventArgs e)
        {
            CandidateBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff252526");
        }

        private void CandidateBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AnotherProfile newprofile = new AnotherProfile(user);
            newprofile.Show();
            newprofile.Activate();
            newprofile.Topmost = true;  // important
            newprofile.Focus();
        }
    }
}
