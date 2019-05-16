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
        public string nm;

        public AddTimerWnd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nm = txname.Text;
                current = new DateTime(Convert.ToInt32(days.SelectedDate.Value.Year), Convert.ToInt32(days.SelectedDate.Value.Month), Convert.ToInt32(days.SelectedDate.Value.Day), Convert.ToInt32(txh.Text), Convert.ToInt32(txm.Text), Convert.ToInt32(txs.Text));
            }
            catch(InvalidOperationException)
            {
                string st1 = "Дата и/или имя таймера не были введены.";
                MessageBox.Show(st1, "Error", MessageBoxButton.OK);
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}