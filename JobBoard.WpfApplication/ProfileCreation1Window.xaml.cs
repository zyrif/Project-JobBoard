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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProfileCreation1 : Window
    {
        public ProfileCreation1()
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

        private void ProfileCreation1Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RecruiterNext_Click(object sender, RoutedEventArgs e)
        {
            RecruiterRegistration rr = new RecruiterRegistration();
            rr.Show();
            this.Hide();
        }

        private void JobHunterNext_Click(object sender, RoutedEventArgs e)
        {
            JobSeekerRegistration jr = new JobSeekerRegistration();
            jr.Show();
            this.Hide();
        }
    }
}
