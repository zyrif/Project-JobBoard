using JobBoard.Core;
using JobBoard.Core.Control;
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

        private void addSuggestions(WrapPanel wp, string location)
        {
            string[] s = location.Split(' ');
            CandidateBoxUC vcUC;
            List<User> userList;
            List<string> skillList = new List<string>();
            foreach(Button b in wp.Children)
            {
                skillList.Add(b.Content.ToString());
            }
            userList = sc.candidateSearch(skillList, s[2]);
            foreach (User user in userList)
            {
                vcUC = new CandidateBoxUC(user);
                candidatePanel.Children.Add(vcUC);
            }
        }
    }
}
