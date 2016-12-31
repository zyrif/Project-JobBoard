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
    /// Interaction logic for JobsBoxUC.xaml
    /// </summary>
    public partial class JobsBoxUC : UserControl
    {
        Vacancy vacancy;
        
        public JobsBoxUC(Vacancy vacancy)
        {
            InitializeComponent();
            this.vacancy = vacancy;

            PopulateJB();
        }

        private void JobsBox_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = double.NaN;
        }

        private void JobsBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 105;
        }

        private void PopulateJB()
        {
            jobtitleLabel.Content += " " + vacancy.JobTitle;
            employerLabel.Content += " " + vacancy.Company;
            locationLabel.Content += " " + vacancy.Location;
            if (!vacancy.JobType)
                jobtypeLabel.Content += " Temporary";
            else
                jobtypeLabel.Content += " Permanent";
            salbrcktLabel.Content += " " + vacancy.MinimumSalary + "-" + vacancy.MaximumSalary;
            deadlineLabel.Content += " " + vacancy.DeadLine.ToShortDateString();
            foreach (string skill in vacancy.skillList)
            {
                Button btn = new Button();
                btn.Content = skill;
                skillPanel.Children.Add(btn);
            }

            dtlsRTxtBox.AppendText(vacancy.JobSummary);
        }

        private void contactBtn_Click(object sender, RoutedEventArgs e)
        {
            WritemailWindow newmail = new WritemailWindow();
            newmail.recipientBox.Text = vacancy.Recruiter.UserName;
            newmail.Show();
        }

        private void viewProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            AnotherProfile recprofile = new AnotherProfile(vacancy.Recruiter);
            recprofile.Show();
            recprofile.Activate();
            recprofile.Topmost = true;
            recprofile.Focus();
        }
    }
}
