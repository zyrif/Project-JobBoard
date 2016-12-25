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
using JobBoard.Core;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class RecruiterRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();

        public RecruiterRegistration()
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

        private void RecRegProceed_Click(object sender, RoutedEventArgs e)
        {
            lrControl.register(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, jobposBox.Text, empBox.Text);
            EmployerRegistration er = new EmployerRegistration();
            er.Show();
            this.Hide();
        }
    }
}
