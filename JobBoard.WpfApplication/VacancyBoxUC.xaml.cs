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

        public VacancyBoxUC(Vacancy vacancy)
        {
            InitializeComponent();
            this.vacancy = vacancy;

            PopulateVB();
        }

        private void VacancyBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 110;
        }

        private void VacancyBox_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = 270;
        }

        private void PopulateVB()
        {

            jobtitleLabel.Content += " " + vacancy.JobTitle;
            employerLabel.Content += " " + vacancy.Company;
            locationLabel.Content += " " + vacancy.Location;
            jobtypeLabel.Content += " " + vacancy.JobType;
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
    }
}
//