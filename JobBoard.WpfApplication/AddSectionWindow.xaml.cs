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
    /// Interaction logic for AddCVBoxWindow.xaml
    /// </summary>
    public partial class AddSectionWindow : Window
    {
        Experience experience;
        Profile profile;
        User userRef = User.getInstance();
        ProfileInteractionsControl picontrol = ProfileInteractionsControl.getInstance();
        bool forUpdate = false;

        public AddSectionWindow()
        {
            InitializeComponent();
        }

        public AddSectionWindow(Profile profile):this()
        {
            this.profile = profile;
        }

        public AddSectionWindow(Experience exp):this()
        {
            this.experience = exp;
        }

        public AddSectionWindow(Experience exp, User user, Profile profile):this()
        {

            SectionTypeTabControl.SelectedIndex = exp.ExpType;
            this.TitleBox.Text = exp.Title.ToString();
            this.expFromDate.DataContext = exp.StartTime.Date.ToString();
            this.expToDate.DataContext = exp.EndTime.Date.ToString();
            this.CompanyBox.Text = exp.Entity;
            this.ExpDetailsRichBox.Document.Blocks.Clear();
            this.ExpDetailsRichBox.Document.Blocks.Add(new Paragraph(new Run(exp.Details)));

            this.forUpdate = true;
            this.profile = profile;
            this.experience = exp;
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddSection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SectionAddOkay_Click(object sender, RoutedEventArgs e)
        {
            int exptype = SectionTypeTabControl.SelectedIndex;
            if (exptype == 0)
            {
                DateTime stdate = Convert.ToDateTime(expFromDate.SelectedDate);
                DateTime eddate;
                string details = new TextRange(ExpDetailsRichBox.Document.ContentStart, ExpDetailsRichBox.Document.ContentEnd).Text;
                if (ExpcheckBox.IsChecked == true)
                    eddate = DateTime.Now;
                else
                    eddate = Convert.ToDateTime(expToDate.SelectedDate);

                Experience exp = new Experience((byte)exptype, TitleBox.Text, CompanyBox.Text, stdate, eddate, details);
                if (forUpdate)
                {
                    exp.ExperienceId = experience.ExperienceId;
                    picontrol.UpdateSection(exp);
                }
                else
                    picontrol.AddSection(userRef.UserId, exp);

                Profile newprofile = new Profile(userRef);
                newprofile.Show();
                profile.Close();

                this.Close();
            }

            else if (exptype == 1)
            {
                DateTime stdate = Convert.ToDateTime(eduFromDate.SelectedDate);
                DateTime eddate;
                string details = new TextRange(EduDetailsRichBox.Document.ContentStart, EduDetailsRichBox.Document.ContentEnd).Text;
                if (EduCheckBox.IsChecked == true)
                    eddate = DateTime.Now;
                else
                    eddate = Convert.ToDateTime(eduToDate.SelectedDate);

                Experience exp = new Experience((byte)exptype, DegreeBox.Text, InstituteBox.Text, stdate, eddate, details);
                if (forUpdate)
                {
                    exp.ExperienceId = experience.ExperienceId;
                    picontrol.UpdateSection(exp);
                }
                else
                    picontrol.AddSection(userRef.UserId, exp);


                Profile newprofile = new Profile(userRef);
                newprofile.Show();
                profile.Close();

                this.Close();
            }

            else if (exptype == 2)
            {
                DateTime stdate = Convert.ToDateTime(awardDate.SelectedDate);
                DateTime eddate;
                string details = new TextRange(AwardDetailsRichBox.Document.ContentStart, AwardDetailsRichBox.Document.ContentEnd).Text;
                eddate = DateTime.Now;

                Experience exp = new Experience((byte)exptype, AwardNameBox.Text, AwardIssuerBox.Text, stdate, eddate, details);
                if(forUpdate)
                {
                    exp.ExperienceId = experience.ExperienceId;
                    picontrol.UpdateSection(exp);
                }
                else
                    picontrol.AddSection(userRef.UserId, exp);


                Profile newprofile = new Profile(userRef);
                newprofile.Show();
                profile.Close();

                this.Close();
            }
        }

        private void SectionAddCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
