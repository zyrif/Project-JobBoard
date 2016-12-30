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
using System.Windows.Shapes;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for AddVacancy.xaml
    /// </summary>
    public partial class AddVacancyWindow : Window
    {
        Vacancy vacancy;
        Profile profile;
        User userRef = User.getInstance();
        ProfileInteractionsControl piControl = ProfileInteractionsControl.getInstance();

        bool updateVacancy = false;

        public AddVacancyWindow(Profile profile)
        {
            InitializeComponent();
            init();
            this.profile = profile;
        }


        public AddVacancyWindow(Vacancy vacancy, Profile profile)
        {
            InitializeComponent();
            this.vacancy = vacancy;
            this.profile = profile;
            updateVacancy = true;
            UpdateVacancy();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SectionAddOkay_Click(object sender, RoutedEventArgs e)
        {
            DateTime postedTime = DateTime.Now;
            DateTime deadLine = Convert.ToDateTime(expDate.SelectedDate.ToString());
            string[] salary = salBrcktComboBox.SelectedItem.ToString().Split('-');
            double minimumSalary = Convert.ToDouble(salary[0]);
            double maximumSalary = Convert.ToDouble(salary[1]);
            string jobdetailsbox = new TextRange(jobDetailBox.Document.ContentStart, jobDetailBox.Document.ContentEnd).Text;
            List<string> skills = new List<string>();
            foreach (Button b in selectWrapPanel.Children)
            {
                bool newSkill = true;
                if (updateVacancy)
                {
                    foreach (string s in vacancy.skillList)
                    {
                        if (s == b.Content.ToString())
                            newSkill = false;
                    }
                }
                if(newSkill)
                {
                    skills.Add(b.Content.ToString());
                }
            }
            
            bool empType = Convert.ToBoolean(empTypeComboBox.SelectedIndex);

            Vacancy newVacancy = new Vacancy(jobtitleBox.Text, userRef.CompanyName, userRef, joblocationBox.Text, postedTime, deadLine, minimumSalary, maximumSalary, empType, jobdetailsbox, skills);
            
            if (updateVacancy)
            {
                newVacancy.JobId = vacancy.JobId;
                piControl.UpdateVacancy(newVacancy);
            }
            else
                piControl.AddVacancy(userRef.UserId, newVacancy);


            Profile newprofile = new Profile(userRef);
            newprofile.Show();
            profile.Close();

            this.Close();
        }

        private void skillComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            bool alreadyAdded = false;
            Button skill = new Button();
            try
            {
                skill.Content = skillComboBox.SelectedItem.ToString();
                foreach (Button button in selectWrapPanel.Children)
                {
                    if (button.Content.ToString() == skill.Content.ToString())
                    {
                        alreadyAdded = true;
                    }
                }
                if (alreadyAdded == false)
                {
                    selectWrapPanel.Children.Add(skill);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        private void init()
        {
            List<string> salaryRangeList = new List<string>();
            List<string> jobTypeList = new List<string>();
            List<string> skillList = LoginRegistrationControl.getInstance().getAvailableSkills();

            salaryRangeList.Add("5000-10000");
            salaryRangeList.Add("10000-20000");
            salaryRangeList.Add("20000-40000");
            salaryRangeList.Add("40000-80000");
            salaryRangeList.Add("80000-120000");
            salaryRangeList.Add("120000-150000");
            salaryRangeList.Add("150000-200000");

            jobTypeList.Add("Temporary");
            jobTypeList.Add("Permanent");

            empTypeComboBox.ItemsSource = jobTypeList;
            if (updateVacancy)
            {
                empTypeComboBox.SelectedIndex = Convert.ToByte(vacancy.JobType);
            }
            else
            {
                empTypeComboBox.SelectedIndex = 0;
            }

            salBrcktComboBox.ItemsSource = salaryRangeList;
            if (updateVacancy)
            {
                foreach(string sr in salaryRangeList)
                {
                    if (sr == vacancy.MinimumSalary + "-" + vacancy.MaximumSalary)
                    {
                        salBrcktComboBox.SelectedValue = sr;
                    }
                }
            }
            else
            {
                salBrcktComboBox.SelectedIndex = 0;
            }
            skillComboBox.ItemsSource = skillList;
        }

        private void UpdateVacancy()
        {
            init();

            updateVacancy = true;

            foreach(string skill in vacancy.skillList)
            {
                Button b = new Button();
                b.Content = skill;
                selectWrapPanel.Children.Add(b);
            }
            jobtitleBox.Text = vacancy.JobTitle;
            joblocationBox.Text = vacancy.Location;
            expDate.SelectedDate = vacancy.DeadLine;

            jobDetailBox.Document.Blocks.Clear();
            jobDetailBox.Document.Blocks.Add(new Paragraph(new Run(vacancy.JobSummary)));
        }
    }
}
