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
    public partial class EditDeleteSuggestUC : UserControl
    {
        Vacancy vacancy;
        Profile profile;
        VacancyBoxUC vbuc;
        User currentUser = User.getInstance();
        public EditDeleteSuggestUC(Vacancy vacancy, Profile profile, VacancyBoxUC vbuc)
        {
            InitializeComponent();
            this.vacancy = vacancy;
            this.profile = profile;
            this.vbuc = vbuc;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileInteractionsControl pic = ProfileInteractionsControl.getInstance();
            pic.DeleteVacancy(currentUser, vacancy);
            Profile newprofile = new Profile(currentUser);
            newprofile.Show();
            profile.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AddVacancyWindow advc = new AddVacancyWindow(vacancy);
            advc.Show();
        }

        private void suggestBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewCandidatesWindow vcWindow = new ViewCandidatesWindow(vbuc);
            vcWindow.Show();
        }
    }
}
