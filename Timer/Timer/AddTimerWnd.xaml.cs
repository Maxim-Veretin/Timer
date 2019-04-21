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

namespace Timer
{
    public partial class AddTimerWnd : Window
    {
        public DateTime current;

        public AddTimerWnd() => InitializeComponent();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            current = new DateTime (Convert.ToInt32(days), Convert.ToInt32(txh.Text), Convert.ToInt32(txm.Text), txs.Text;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}