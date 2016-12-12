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
using JobBoard.Core.Control;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        DBConnectionControl connectionControl;
        LoginRegistrationControl loginRegistrationControl;


        public LoginRegister()
        {
            connectionControl = new DBConnectionControl();
            loginRegistrationControl = new LoginRegistrationControl();
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

        private void LoginRegisterWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LRProceed_Click(object sender, RoutedEventArgs e)
        {
            if (LRTabControl.SelectedIndex == 0)
            {
                if (loginRegistrationControl.login(LUsernameBox.Text, LPasswordBox.Password.ToString()))

                {
                    Profile jp = new Profile();
                    jp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username Password Mismatch");
                }
            }
            else if(tabControl.SelectedIndex == 1)
            {
                if (loginRegistrationControl.checkUser(RUsernameBox.Text))
                {
                    loginRegistrationControl.register(RUsernameBox.Text,RPasswordBox.Password.ToString());
                    ChooseProfile cp = new ChooseProfile();
                    cp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("An Account is already created with this Username");
                }
            }
        }
    }
}
