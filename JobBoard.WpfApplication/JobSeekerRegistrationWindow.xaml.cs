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
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using Microsoft.Win32;
using JobBoard.Core.Control;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class JobSeekerRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser = User.getInstance();
        IEHPatterns iehp = IEHPatterns.getInstance();
        ChooseProfile cpWindow;

        System.Drawing.Image profilePhoto;
        BitmapImage photo = new BitmapImage();

        public JobSeekerRegistration(ChooseProfile cp)
        {
            InitializeComponent();
            this.cpWindow = cp;

            List<string> skillList = lrControl.getAvailableSkills();
            comboBox.ItemsSource = skillList;

            try
            {
                profilePhoto = System.Drawing.Image.FromFile("profileimage.png");
                SetProfileimage();
            }
            catch (Exception) { MessageBox.Show("Default profile Image not in bin/Debug folder."); }
   
        }

        bool fromEdit=false;
        public JobSeekerRegistration()
        {
            InitializeComponent();

            List<string> skillList = lrControl.getAvailableSkills();
            comboBox.ItemsSource = skillList;

            try
            {
                profilePhoto = System.Drawing.Image.FromFile("profileimage.png");
                SetProfileimage();
            }
            catch (Exception) { MessageBox.Show("Default profile Image not in bin/Debug folder."); }

            SetFields();
            fromEdit = true;
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
            if (iehp.isValidEmail(emailBox.Text) && iehp.isPhoneNumber(phoneBox.Text))
            {
                DateTime date = Convert.ToDateTime(birthdayPicker.SelectedDate);

                List<string> skillList = new List<string>();
                foreach (Button skillButton in slctskillsPanel.Children)
                {
                    currentUser.setSkill(skillButton.Content.ToString());
                }
                if (fromEdit == true)
                    updateFields();
                else
                {
                    currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, date, locationBox.Text, skillList);
                    lrControl.register(currentUser);
                }
                Profile jp = new Profile(currentUser);
                jp.Show();
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

        //If skill is selected from combo box
        bool alreadyAdded = false;
        private void JobSeekerRegWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            Button skill = new Button();
            try
            {
                skill.Content = comboBox.SelectedItem.ToString();
                foreach (Button button in slctskillsPanel.Children)
                {
                    if (button.Content.ToString() == skill.Content.ToString())
                    {
                        alreadyAdded = true;
                    }
                        
                }
                if(alreadyAdded == false)
                {
                    slctskillsPanel.Children.Add(skill);
                }
                alreadyAdded = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
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

            if(dialog.ShowDialog() == true)
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

        private void SetFields()
        {
            firstnameBox.Text = currentUser.FirstName;
            lastnameBox.Text = currentUser.LastName;
            emailBox.Text = currentUser.Email;
            phoneBox.Text = currentUser.PhoneNumber;
            birthdayPicker.Text = currentUser.BirthDay.Date.ToString();
            locationBox.Text = currentUser.Location;

            
        }

        private void updateFields()
        {
            User user = new User();
            user = currentUser;
            user.FirstName = firstnameBox.Text;
            user.LastName = lastnameBox.Text;
            user.Email = emailBox.Text;
            user.PhoneNumber = phoneBox.Text;
            user.BirthDay = Convert.ToDateTime(birthdayPicker.SelectedDate.ToString());
            user.Location = locationBox.Text;
            user.Photo = photo;

            foreach (Button btn in slctskillsPanel.Children)
            {
                user.skillList.Add(btn.Content.ToString());
            }
            currentUser = user;
            lrControl.UpdateJS(user);
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
            else if(iehp.isValidEmail(emailBox.Text))
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
