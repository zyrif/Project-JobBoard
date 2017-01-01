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
    /// Interaction logic for CVUserControl.xaml
    /// </summary>
    public partial class CVBoxUC : UserControl
    {
        Profile profile;
        Experience exp;
        User user;

        public CVBoxUC(Experience exp)
        {
            InitializeComponent();
            this.exp = exp;

            PopulateUCBox();
        }

        public CVBoxUC(User user, Experience exp, Profile profile)
        {
            InitializeComponent();
            this.exp = exp;
            this.user = user;
            this.profile = profile;

            PopulateUCBox2();
        }

        private void CVBox_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void CVBox_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void PopulateUCBox()
        {
            jobnameLabel.Content = exp.Title;
            companyLabel.Content = exp.Entity;
            timeperiodLabel.Content = exp.StartTime.Month.ToString() + "/" + exp.StartTime.Year.ToString() + " - " + exp.EndTime.Month.ToString() + "/" + exp.EndTime.Year.ToString();
            descTextblock.Text = exp.Details;

            SetColor();
        }

        private void PopulateUCBox2()
        {
            jobnameLabel.Content = exp.Title;
            companyLabel.Content = exp.Entity;
            timeperiodLabel.Content = exp.StartTime.Month.ToString() + "/" + exp.StartTime.Year.ToString() + " - " + exp.EndTime.Month.ToString() + "/" + exp.EndTime.Year.ToString();
            descTextblock.Text = exp.Details;

            CVBSubGrid.Children.Add(new EditDeleteUC(user, exp, profile));

            SetColor();
        }

        private void SetColor()
        {
            if(exp.ExpType == 0)
            {
                CVBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3498DB"));
                CVBox.Background.Opacity = 0.3;
            }

            else if (exp.ExpType == 1)
            {
                CVBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#27AE60"));
                CVBox.Background.Opacity = 0.5;
            }

            else if (exp.ExpType == 2)
            {
                CVBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff5c33"));
                CVBox.Background.Opacity = 0.5;
            }
        }

        private void CVBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Height == 123)
                this.Height = Double.NaN;
            else
                this.Height = 123;

        }
    }
}
