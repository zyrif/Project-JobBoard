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
            if (exp.ExpType == 0)
            {
                this.TitleBox.Text = exp.Title.ToString();
                this.expFromDate.SelectedDate = exp.StartTime.Date;
                this.expToDate.SelectedDate = exp.EndTime.Date;
                this.CompanyBox.Text = exp.Entity;
                this.ExpDetailsRichBox.Document.Blocks.Clear();
                this.ExpDetailsRichBox.Document.Blocks.Add(new Paragraph(new Run(exp.Details)));
            }
            else if(exp.ExpType == 1)
            {
                this.DegreeBox.Text = exp.Title.ToString();
                this.eduFromDate.SelectedDate = exp.StartTime.Date;
                this.eduToDate.SelectedDate = exp.EndTime.Date;
                this.InstituteBox.Text = exp.Entity;
                this.EduDetailsRichBox.Document.Blocks.Clear();
                this.EduDetailsRichBox.Document.Blocks.Add(new Paragraph(new Run(exp.Details)));
            }
            else if (exp.ExpType == 2)
            {
                this.AwardNameBox.Text = exp.Title.ToString();
                this.awardDate.SelectedDate = exp.StartTime.Date;
                this.AwardIssuerBox.Text = exp.Entity;
                this.AwardDetailsRichBox.Document.Blocks.Clear();
                this.AwardDetailsRichBox.Document.Blocks.Add(new Paragraph(new Run(exp.Details)));
            }

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
                if (TitleBox.Text == "" || expFromDate.Text == "" || expToDate.Text == "")
                    MessageBox.Show("Add Informations properly");
                else
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
            }

            else if (exptype == 1)
            {
                if (DegreeBox.Text == "" || eduFromDate.Text == "" || eduToDate.Text == "")
                    MessageBox.Show("Add Informations properly");
                else
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
            }

            else if (exptype == 2)
            {
                if (AwardNameBox.Text == "" || awardDate.Text == "")
                    MessageBox.Show("Add Informations properly");
                else
                {
                    DateTime stdate = Convert.ToDateTime(awardDate.SelectedDate);
                    DateTime eddate;
                    string details = new TextRange(AwardDetailsRichBox.Document.ContentStart, AwardDetailsRichBox.Document.ContentEnd).Text;
                    eddate = DateTime.Now;

                    Experience exp = new Experience((byte)exptype, AwardNameBox.Text, AwardIssuerBox.Text, stdate, eddate, details);
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
            }
        }

        private void SectionAddCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
