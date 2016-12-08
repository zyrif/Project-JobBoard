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
    /// Interaction logic for JobSeekerProfile.xaml
    /// </summary>
    public partial class JobSeekerProfile : Window
    {
        public JobSeekerProfile()
        {
            InitializeComponent();
            JSUserOverviewUC uo = new JSUserOverviewUC();
            this.UserOverviewGrid.Children.Add(uo);
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void JobSeekerProfileWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CVUserControl uc = new CVUserControl();   
            this.CVview.Children.Add(uc);
        }
    }
}
