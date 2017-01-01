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
using JobBoard.Core.Control;
using JobBoard.Core.Entity;
using JobBoard.Core;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for SearchJobWindow.xaml
    /// </summary>
    public partial class SearchJobWindow : Window
    {
        SearchControl control = new SearchControl();
        User userRef;
        public SearchJobWindow(User userRef)
        {
            InitializeComponent();
            this.userRef = userRef;
            init();
        }

        void init()
        {
            List<string> jobTitleList = control.getJobTitleList();
            List<string> employerList = control.getEmployerList();
            List<string> locationList = control.getLocationList();
            List<string> salaryRangeList = new List<string>();
            List<string> jobTypeList = new List<string>();

            salaryRangeList.Add("5000-10000");
            salaryRangeList.Add("10000-20000");
            salaryRangeList.Add("20000-40000");
            salaryRangeList.Add("40000-80000");
            salaryRangeList.Add("80000-120000");
            salaryRangeList.Add("120000-150000");
            salaryRangeList.Add("150000-200000");

            jobTypeList.Add("Temporary");
            jobTypeList.Add("Permanent");

            titleComboBox.ItemsSource = jobTitleList;
            employerComboBox.ItemsSource = employerList;
            locationComboBox.ItemsSource = locationList;
            salaryBrctComboBox.ItemsSource = salaryRangeList;
            empTypeComboBox.ItemsSource = jobTypeList;
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void expdateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.search();
        }

        private void titleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.search();
        }

        private void employerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.search();
        }

        private void locationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.search();
        }

        private void salaryBrctComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.search();
        }

        private void empTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.search();
        }

        void search()
        {
            string[] selection = new string[5];
            if (titleComboBox.SelectedItem == null) { selection[0] = ""; } else { selection[0] = titleComboBox.SelectedItem.ToString(); }
            if (employerComboBox.SelectedItem == null) { selection[1] = ""; } else { selection[1] = employerComboBox.SelectedItem.ToString(); }
            if (locationComboBox.SelectedItem == null) { selection[2] = ""; } else { selection[2] = locationComboBox.SelectedItem.ToString(); }
            if (salaryBrctComboBox.SelectedItem == null) { selection[3] = ""; } else { selection[3] = salaryBrctComboBox.SelectedItem.ToString(); }
            if (empTypeComboBox.SelectedItem == null) { selection[4] = ""; } else { selection[4] = empTypeComboBox.SelectedItem.ToString(); }


            List<Vacancy> postedJobList = control.search(selection[0], selection[1], selection[2], selection[3], selection[4]);
            jobPanel.Children.Clear();
            foreach (Vacancy pj in postedJobList)
            {
                this.jobPanel.Children.Add(new JobsBoxUC(pj, this.userRef));
            }

        }

        private void Search_Job_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
