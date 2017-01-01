using JobBoard.Core;
using JobBoard.Core.Control;
using JobBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewCandidatesWindow.xaml
    /// </summary>
    public partial class ViewCandidatesWindow : Window
    {
        SearchControl sc = new SearchControl();
        public ViewCandidatesWindow(VacancyBoxUC vbUC)
        {
            InitializeComponent();
            addSuggestions(vbUC.skillPanel,vbUC.locationLabel.Content.ToString());
        }

        public ViewCandidatesWindow(Vacancy vacancy)
        {
            InitializeComponent();
            List<User> userList = sc.candidateSearch(vacancy.JobId);
            CandidateBoxUC cbUC;
            foreach (User user in userList)
            {
                cbUC = new CandidateBoxUC(user);
                VCView.Children.Add(cbUC);
            }
        }

        private void addSuggestions(WrapPanel wp, string location)
        {
            string[] s = location.Split(' ');
            CandidateBoxUC cbUC;
            List<User> userList;
            List<string> skillList = new List<string>();
            foreach(Button b in wp.Children)
            {
                skillList.Add(b.Content.ToString());
            }
            userList = sc.candidateSearch(skillList, s[2]);
            foreach (User user in userList)
            {
                cbUC = new CandidateBoxUC(user);
                VCView.Children.Add(cbUC);
            }
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void View_Candidates_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
//