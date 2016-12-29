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
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;
using JobBoard.Core.Control;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class RecruiterRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser = User.getInstance();
        IEHPatterns iehp = IEHPatterns.getInstance();
        ChooseProfile cpWindow;

        System.Drawing.Image profilePhoto;
        BitmapImage photo = new BitmapImage();

        public RecruiterRegistration(ChooseProfile cp)
        {
            InitializeComponent();
            init();
            this.cpWindow = cp;

            try
            {
                profilePhoto = System.Drawing.Image.FromFile("profileimage.png");
                SetProfileimage();
            }
            catch (Exception) { MessageBox.Show("Default profile Image not in bin/Debug folder."); }
        }

        private void init()
        {
            CompanyListComboBox.ItemsSource = lrControl.getAllRegisteredCompany();
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
            if (iehp.isValidEmail(emailBox.Text) && iehp.isPhoneNumber(phoneBox.Text))
            {
                if (checkEmployerPresent.IsChecked == false)
                {
                    currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, jobposBox.Text, CompanyListComboBox.SelectedItem.ToString());
                    lrControl.register(currentUser);
                    Profile p = new Profile(currentUser);
                    p.Show(); this.Hide();
                }
                else
                {
                    currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, jobposBox.Text);
                    EmployerRegistration er = new EmployerRegistration(currentUser);

                    er.Show();
                    this.Hide();
                }
            }
            else if(!iehp.isValidEmail(emailBox.Text) && !iehp.isPhoneNumber(phoneBox.Text))
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

        private void SetProfileimage()
        {
            using (Bitmap bmp = new Bitmap(profilePhoto))
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                photo = bi;
                profileImage.Source = bi;
            }
        }

        private void addphotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) |*.jpg; *.jpeg; *.png";
            dialog.InitialDirectory = @"%userprofile%\Pictures";
            dialog.Title = "Choose Profile Picture";

            if (dialog.ShowDialog() == true)
            {
                profilePhoto = System.Drawing.Image.FromFile(dialog.FileName);
                using (Bitmap bmp = new Bitmap(profilePhoto))
                {
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    photo = new BitmapImage();
                    photo.BeginInit();
                    photo.StreamSource = ms;
                    photo.EndInit();

                    profileImage.Source = photo;
                }
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

        private void phoneBox_LostFocus(object sender, RoutedEventArgs e)
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
    }
}
