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
    /// Interaction logic for MailUC.xaml
    /// </summary>
    public partial class MailUC : UserControl
    {
        public MailUC()
        {
            InitializeComponent();
        }

        private void amail_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Height = Double.NaN;
        }

        private void amail_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Height = 50;
        }
    }
}
