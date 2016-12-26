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
    public partial class EmployerRegistration : Window
    {
        
        public EmployerRegistration()
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

        private void EmpRegProceed_Click(object sender, RoutedEventArgs e)
        {
            //Profile jp = new Profile();
            //jp.Show();
            //this.Hide();
        }
    }
}
