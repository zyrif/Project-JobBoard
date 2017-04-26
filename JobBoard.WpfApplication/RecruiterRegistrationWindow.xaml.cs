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
using System.Windows.Resources;

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
        Profile profile;

        System.Drawing.Image defaultPhoto;
        BitmapImage photo = new BitmapImage();

        public RecruiterRegistration(ChooseProfile cp)
        {
            InitializeComponent();
            init();
            this.cpWindow = cp;

            Uri uri = new Uri("pack://application:,,,/JobBoard.WpfApplication;Component/Resources/profileimage.png", UriKind.Absolute);
            StreamResourceInfo sri = Application.GetResourceStream(uri);
            defaultPhoto = System.Drawing.Image.FromStream(sri.Stream);
            SetDefaultProfileimage();
        }

        bool fromEdit = false;
        public RecruiterRegistration(Profile profile)
        {
            InitializeComponent();
            this.profile = profile;
            backBtn.Visibility = Visibility.Hidden;

            photo = currentUser.Photo;

            SetFields();
            fromEdit = true;

            DisableEmployer();

        }

        private void init()
        {
            CompanyListComboBox.ItemsSource = lrControl.getAllRegisteredCompany();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            if (fromEdit)
                this.Close();
            else
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

                    if(fromEdit)
                    {
                        UpdateFields();
                        profile.Close();
                        Profile rp = new Profile(currentUser);
                        rp.Show();
                        this.Close();
                    }

                    else
                    {
                        if (CompanyListComboBox.SelectedItem == null)
                            MessageBox.Show("Select a company or Add a new one");
                        else
                        {
                            currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, jobposBox.Text, CompanyListComboBox.SelectedItem.ToString());
                            lrControl.register(currentUser);
                            LoginRegister lr = new LoginRegister();
                            //Profile p = new Profile(currentUser);
                            lr.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, jobposBox.Text);
                    EmployerRegistration er = new EmployerRegistration(currentUser, this);

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

        private void SetDefaultProfileimage()
        {
            using (Bitmap bmp = new Bitmap(defaultPhoto))
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
                defaultPhoto = System.Drawing.Image.FromFile(dialog.FileName);
                using (Bitmap bmp = new Bitmap(defaultPhoto))
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

        private void SetFields()
        {
            firstnameBox.Text = currentUser.FirstName;
            lastnameBox.Text = currentUser.LastName;
            emailBox.Text = currentUser.Email;
            phoneBox.Text = currentUser.PhoneNumber;
            jobposBox.Text = currentUser.JobPosition;
            profileImage.Source = currentUser.Photo;

            //add companyListComboBox code here. Delete the comment after adding the code.

        }

        private void UpdateFields()
        {
            currentUser.FirstName = firstnameBox.Text;
            currentUser.LastName = lastnameBox.Text;
            currentUser.Email = emailBox.Text;
            currentUser.PhoneNumber = phoneBox.Text;
            currentUser.JobPosition = jobposBox.Text;
            currentUser.Photo = photo;

            // add companyListComboBox code here. Delete the comment after adding the code.

            lrControl.UpdateRec(currentUser);

        }


        private void DisableEmployer()
        {
            this.employerLabel.Visibility = Visibility.Hidden;
            this.CompanyListComboBox.Visibility = Visibility.Hidden;
            this.checkEmployerPresent.Visibility = Visibility.Hidden;
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

        private void RecruiterRegWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            User.clearInstance();
            cpWindow.Show();
            this.Hide();
        }
    }
}
