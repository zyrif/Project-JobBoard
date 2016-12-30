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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for CandidateBoxUC.xaml
    /// </summary>
    public partial class CandidateBoxUC : UserControl
    {
        public CandidateBoxUC(User user)
        {
            InitializeComponent();
            nameLabel.Content = user.FirstName + " " + user.LastName;
            locationLabel.Content = user.Location;
            emailLabel.Content = user.Email;
            phoneLabel.Content = user.PhoneNumber;
            foreach(string skill in user.SkillList)
            {
                Button button = new Button();
                button.Content = skill;
                skillsPanel.Children.Add(button);
            }
        }
    }
}
