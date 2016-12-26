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
    /// Interaction logic for MailboxWindow.xaml
    /// </summary>
    public partial class MailboxWindow : Window
    {
        public MailboxWindow()
        {
            InitializeComponent();
            for(int i=0; i<5; i++)
            {
                MailUC muc = new MailUC();
                this.mailView.Children.Add(muc);
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
    }
}
