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
    public partial class EmployerRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser;
        public EmployerRegistration(User currentUser)
        {
            this.currentUser = currentUser;
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
            Company company = new Company(nameBox.Text,addressbox.Text,countryBox.Text,phoneBox.Text,emailBox.Text,websiteBox.Text, Convert.ToByte(btypeSlider.Value));
            lrControl.register(company);
            currentUser.CompanyId = lrControl.getCompanyId(company.Name);
            currentUser.CompanyName = company.Name;
            lrControl.register(currentUser);
            LoginRegister lr = new LoginRegister();
            lr.Show();
            this.Hide();
        }
    }
}
