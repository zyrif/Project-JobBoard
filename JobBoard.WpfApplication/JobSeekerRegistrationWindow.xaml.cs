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
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class JobSeekerRegistration : Window
    {
        LoginRegistrationControl loginRegistrationControl = new LoginRegistrationControl();

        public JobSeekerRegistration()
        {
            InitializeComponent();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RecruiterRegWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void JSRegProceed_Click(object sender, RoutedEventArgs e)
        {
            loginRegistrationControl.registerProfile(firstnameBox.Text,lastnameBox.Text,emailBox.Text,phoneBox.Text,1);
            JobSeekerProfile jp = new JobSeekerProfile();
            jp.Show();
            this.Hide();
        }
    }
}
