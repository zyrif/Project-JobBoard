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
using JobBoard.Core;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChooseProfile : Window
    {
        LoginRegister lrWindow;
        User currentUser = User.getInstance();

        public ChooseProfile(LoginRegister lr)
        {
            InitializeComponent();
            lrWindow = lr;
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ChooseProfileWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RecruiterNext_Click(object sender, RoutedEventArgs e)
        {
            currentUser.UserType = 1;
            RecruiterRegistration rr = new RecruiterRegistration(this);
            rr.Show();
            this.Hide();
        }

        private void JobHunterNext_Click(object sender, RoutedEventArgs e)
        {
            currentUser.UserType = 0;
            JobSeekerRegistration jr = new JobSeekerRegistration(this);
            jr.Show();
            this.Hide();
        }

        private void ChooseProfileWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }
    }
}
