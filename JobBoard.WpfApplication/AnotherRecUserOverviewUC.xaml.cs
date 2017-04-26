using JobBoard.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecUserOverviewUC.xaml
    /// </summary>
    public partial class AnotherRecUserOverviewUC : UserControl
    {
        User userRef;

        public AnotherRecUserOverviewUC(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
            PopulateUO();
            //setpic();
        }

        public void PopulateUO()
        {
            this.uwelcomeLabel.Content = userRef.FirstName;
            this.uwelcomeLabel.Content += " " + userRef.LastName;
            this.unameLabel.Content += userRef.UserName;
            this.uemailLabel.Content = userRef.Email;
            this.uphoneLabel.Content = userRef.PhoneNumber;
            this.ujobpositionLabel.Content = userRef.JobPosition;
            this.profileImage.Source = userRef.Photo;

            Company emp = new Company();
            emp = ProfileInteractionsControl.getInstance().CompanyInfo(userRef.CompanyName);

            this.empnameLbl.Content += emp.Name;
            this.empaddLbl.Content = emp.Address + ", " + emp.Country;
            this.empmailLbl.Content = emp.Email;
            this.empsiteLbl.Content = emp.Website;
            this.empphoneLbl.Content = emp.Phone;

        }

        //private void setpic()
        //{
        //    System.Drawing.Image profilePhoto;
        //    BitmapImage photo = new BitmapImage();
        //    try
        //    {
        //        profilePhoto = System.Drawing.Image.FromFile("profileimage.png");
        //        using (Bitmap bmp = new Bitmap(profilePhoto))
        //        {
        //            MemoryStream ms = new MemoryStream();
        //            bmp.Save(ms, ImageFormat.Png);
        //            ms.Position = 0;
        //            BitmapImage bi = new BitmapImage();
        //            bi.BeginInit();
        //            bi.StreamSource = ms;
        //            bi.EndInit();

        //            photo = bi;
        //            profileImage.Source = bi;
        //        }
        //    }
        //    catch (Exception) { MessageBox.Show("Default profile Image not in bin/Debug folder."); }
        //}
    }
}
