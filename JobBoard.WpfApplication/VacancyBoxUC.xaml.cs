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
    /// Interaction logic for VacancyBoxUC.xaml
    /// </summary>
    public partial class VacancyBoxUC : UserControl
    {
        Vacancy vacancy;
        Profile profile;

        public VacancyBoxUC(Vacancy vacancy)
        {
            InitializeComponent();
            this.vacancy = vacancy;

            PopulateVB();
        }

        public VacancyBoxUC(User user, Vacancy vacancy, Profile profile)
        {
            InitializeComponent();
            this.vacancy = vacancy;
            this.profile = profile;

            PopulateVB2();
        }

        private void VacancyBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 110;
        }

        private void VacancyBox_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = Double.NaN;
        }

        private void PopulateVB()
        {

            jobtitleLabel.Content += " " + vacancy.JobTitle;
            employerLabel.Content += " " + vacancy.Company;
            locationLabel.Content += " " + vacancy.Location;
            if(!vacancy.JobType)
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

        private void PopulateVB2()
        {
            jobtitleLabel.Content += " " + vacancy.JobTitle;
            employerLabel.Content += " " + vacancy.Company;
            locationLabel.Content += " " + vacancy.Location;
            if (vacancy.JobType == true)
                jobtypeLabel.Content += " Permanent";
            else
                jobtypeLabel.Content += " Temporary";
            salbrcktLabel.Content += " " + vacancy.MinimumSalary + "-" + vacancy.MaximumSalary;
            deadlineLabel.Content += " " + vacancy.DeadLine.ToShortDateString();
            foreach (string skill in vacancy.skillList)
            {
                Button btn = new Button();
                btn.Content = skill;
                skillPanel.Children.Add(btn);
            }

            dtlsRTxtBox.AppendText(vacancy.JobSummary);

            VCBSubGrid.Children.Add(new EditDeleteSuggestUC(vacancy, profile, this));

        }
    }
}
//