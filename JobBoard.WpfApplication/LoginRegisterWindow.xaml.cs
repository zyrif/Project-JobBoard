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
using JobBoard.Core.Entity;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        LoginRegistrationControl loginRegistrationControl = LoginRegistrationControl.getInstance();
        User currentUser;
        Welcome welcomeWindow;


        public LoginRegister()
        {
            InitializeComponent();
        }

        public LoginRegister(Welcome wc):this()
        {
            this.welcomeWindow = wc;
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
                if (LUsernameBox.Text != "")
                {
                    if (loginRegistrationControl.login(LUsernameBox.Text, LPasswordBox.Password.ToString()))
                    {
                        currentUser = User.getInstance();
                        Profile jp = new Profile(currentUser);
                        jp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username Password Mismatch");
                    }
                }
                else
                {
                    MessageBox.Show("Enter User Name to Login Your Account");
                }
            }
            else if(LRTabControl.SelectedIndex == 1)
            {

                if (RUsernameBox.Text != "")
                {
                    if (!loginRegistrationControl.checkUser(RUsernameBox.Text))
                    {
                        if (RPassBox.Password.ToString() == RPassConfirmBox.Password.ToString())
                        {
                            currentUser = User.getInstance();
                            currentUser.UserName = RUsernameBox.Text.Trim();
                            currentUser.UserPassword = RPassBox.Password.ToString();
                            ChooseProfile cp = new ChooseProfile(this);
                            cp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Passwords don't match");
                        }
                    }
                    else
                    {
                        MessageBox.Show("An Account is already created with this Username");
                    }
                }
                else
                {
                    MessageBox.Show("Enter User Name & Password to Create a new Account");
                }
            }
        }

        private void LoginRegisterWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }
    }
}
