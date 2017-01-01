using JobBoard.Core;
using JobBoard.Core.Control;
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
        IEHPatterns iehp = IEHPatterns.getInstance();
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser;
        public EmployerRegistration(User currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            phoneBox.Text = "+880";
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
            if (iehp.isValidEmail(emailBox.Text) && iehp.isPhoneNumber(phoneBox.Text))
            {
                Company company = new Company(nameBox.Text, addressbox.Text, countryBox.Text, phoneBox.Text, emailBox.Text, websiteBox.Text, Convert.ToByte(btypeSlider.Value));
                lrControl.register(company);
                currentUser.CompanyId = lrControl.getCompanyId(company.Name);
                currentUser.CompanyName = company.Name;
                lrControl.register(currentUser);
                LoginRegister lr = new LoginRegister();
                lr.Show();
                this.Hide();
            }
            else if (!iehp.isValidEmail(emailBox.Text) && !iehp.isPhoneNumber(phoneBox.Text))
            {
                MessageBox.Show("Provide valid Email & Phone Number!");
            }
            else if (!iehp.isValidEmail(emailBox.Text))
            {
                MessageBox.Show("Provide a valid Email address!");
            }
            else if (!iehp.isPhoneNumber(phoneBox.Text))
            {
                MessageBox.Show("Provide a valid Phone Number!");
            }
        }

        private void EmployerRegWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }

        private void btypeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void phoneBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }

        private void phoneBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!iehp.isPhoneNumber(phoneBox.Text))
            {
                phoneBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (iehp.isPhoneNumber(phoneBox.Text))
            {
                phoneBox.BorderBrush = new SolidColorBrush(Colors.Green);

            }
        }

        private void emailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }

        private void emailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (iehp.isValidEmail(emailBox.Text))
            {
                emailBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
