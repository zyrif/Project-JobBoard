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
using System.Windows.Shapes;
using JobBoard.Core.Entity;
using JobBoard.Core.Control;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class AnotherProfile : Window
    {
        ProfileInteractionsControl control = ProfileInteractionsControl.getInstance();
        LoginRegistrationControl lrcontrol = LoginRegistrationControl.getInstance();
        User userRef;
        User currentUser = User.getInstance();

        public AnotherProfile(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
            AddUserOverview();
            AddUserHistory();
        }

        public AnotherProfile(String newuser)
        {
            InitializeComponent();
            this.userRef = lrcontrol.GetUserInfo(newuser);
            AddUserOverview();
            AddUserHistory();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ProfileWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }



        private void AddUserOverview()
        {
            if (userRef.UserType == 0)
            {
                AnotherJSUserOverviewUC auo = new AnotherJSUserOverviewUC(userRef, this);
                this.UserOverviewGrid.Children.Add(auo);
            }
            else if (userRef.UserType == 1)
            {
                AnotherRecUserOverviewUC uo = new AnotherRecUserOverviewUC(userRef);
                this.UserOverviewGrid.Children.Add(uo);
            }
        }



        private void AddUserHistory()
        {
            if (userRef.UserType == 0)
            {
                AddCvBox();
            }
            else if (userRef.UserType == 1)
            {
                AddPostedVacancies();
            }
        }

        private void AddCvBox()
        {
            List<Experience> experienceList = control.getExperienceList(userRef.UserId);


            foreach (Experience exp in experienceList)
            {
                CVBoxUC cvBox = new CVBoxUC(exp);
                this.CVview.Children.Add(cvBox);
            }
        }

        private void AddPostedVacancies()
        {
            List<Vacancy> vacancyList = control.getVacanciesPosted(userRef);

            foreach (Vacancy vacancy in vacancyList)
            {
                VacancyBoxUC vBoxUC = new VacancyBoxUC(vacancy);
                this.CVview.Children.Add(vBoxUC);
            }
        }
    }
}
