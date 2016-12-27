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
        Experience exp;

        public CVBoxUC(Experience exp)
        {
            InitializeComponent();
            this.exp = exp;

            PopulateUCBox();
        }

        public CVBoxUC(User user, Experience exp)
        {
            InitializeComponent();
            this.exp = exp;

            PopulateUCBox2();
        }

        private void CVBox_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = Double.NaN;
        }

        private void CVBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 123;
        }

        private void PopulateUCBox()
        {
            jobnameLabel.Content = exp.Title;
            companyLabel.Content = exp.Entity;
            timeperiodLabel.Content = exp.StartTime.Month.ToString() + "/" + exp.StartTime.Year.ToString() + " - " + exp.EndTime.Month.ToString() + "/" + exp.EndTime.Year.ToString();
            descTextblock.Text = exp.Details;
        }

        private void PopulateUCBox2()
        {
            jobnameLabel.Content = exp.Title;
            companyLabel.Content = exp.Entity;
            timeperiodLabel.Content = exp.StartTime.Month.ToString() + "/" + exp.StartTime.Year.ToString() + " - " + exp.EndTime.Month.ToString() + "/" + exp.EndTime.Year.ToString();
            descTextblock.Text = exp.Details;

            CVBSubGrid.Children.Add(new EditDeleteUC());
        }
    }
}
