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

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        User userRef;
        User currentUser = User.getInstance();

        public Profile(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
            AddUserOverview();
            AddSubControl();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ProfileWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e)
        {

            CVBoxUC uc = new CVBoxUC();
            this.CVview.Children.Add(uc);
        }

        private void AddSectionBtn2_Click(object sender, RoutedEventArgs e)
        {

            VacancyBoxUC vb = new VacancyBoxUC(userRef);
            this.CVview.Children.Add(vb);
        }

        private void AddUserOverview()
        {
            JSUserOverviewUC uo = new JSUserOverviewUC();
            this.UserOverviewGrid.Children.Add(uo);
        }

        private void AddSubControl()
        {
            if (this.userRef == currentUser)
            {
                ProfileSubUserControl ps = new ProfileSubUserControl();
                this.PSubGrid.Children.Add(ps);
            }
        }
    }
}
