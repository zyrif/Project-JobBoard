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

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class RecruiterRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser = User.getInstance();
        ChooseProfile cpWindow;

        System.Drawing.Image profilePhoto;
        BitmapImage photo = new BitmapImage();

        public RecruiterRegistration(ChooseProfile cp)
        {
            InitializeComponent();
            this.cpWindow = cp;

            try
            {
                profilePhoto = System.Drawing.Image.FromFile("profileimage.png");
                SetProfileimage();
            }
            catch (Exception) { MessageBox.Show("Default profile Image not in bin/Debug folder."); }
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
            currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, photo, jobposBox.Text, empBox.Text);
            lrControl.register(currentUser);
            EmployerRegistration er = new EmployerRegistration();
            er.Show();
            this.Hide();
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
    }
}
