using JobBoard.Core;
using JobBoard.Core.Entity;
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

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for EditDeleteUC.xaml
    /// </summary>
    public partial class EditDeleteUC : UserControl
    {
        Experience exp;
        User user;
        User currentUser = User.getInstance();
        Profile profile;
        ProfileInteractionsControl pic = ProfileInteractionsControl.getInstance();

        public EditDeleteUC(User user, Experience exp, Profile profile)
        {
            InitializeComponent();
            this.exp = exp;
            this.user = user;
            this.profile = profile;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSectionWindow addSection = new AddSectionWindow(exp,user,profile);
            addSection.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            pic.DeleteExperience(user, exp);
            Profile newprofile = new Profile(currentUser);
            newprofile.Show();
            profile.Close();
        }
    }
}
