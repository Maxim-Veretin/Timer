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

namespace Timer
{
    /// <summary>
    /// + 1. Диалоговое окно с добавленеием даты
    /// + 2. Таймер
    /// 3. Редактирование
    /// 4. Сохранение
    /// 5. Загрузка
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

        System.Windows.Threading.DispatcherTimer Timer;
        DateTime date;
        DateTime date1 = DateTime.Now;

        public string name;

        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(DispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);

            Seconds.IsChecked = true;
            Minutes.IsChecked = true;
            Hours.IsChecked = true;
            Days.IsChecked = true;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(1);
            lb.Content = "";

            if ((list[stack.SelectedValue.ToString()] - date1).TotalSeconds < 0)
            {
                Timer.Stop();
                TimeEnd end = new TimeEnd();
                if (end.ShowDialog() == true)
                { }
            }
            
            if (Days.IsChecked == true)
                lb.Content += (list[stack.SelectedValue.ToString()] - date1).Days.ToString() + ":";

            if (Hours.IsChecked == true)
                lb.Content += (list[stack.SelectedValue.ToString()] - date1).Hours.ToString() + ":";

            if (Minutes.IsChecked == true)
                lb.Content += (list[stack.SelectedValue.ToString()] - date1).Minutes.ToString() + ":";

            if (Seconds.IsChecked == true)
                lb.Content += (list[stack.SelectedValue.ToString()] - date1).Seconds.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Timer_Click(object sender, RoutedEventArgs e)
        {
            AddTimerWnd add_timer = new AddTimerWnd();

            if (add_timer.ShowDialog() == true)
            {
                date = add_timer.current;
                name = add_timer.nm;
                list.Add(name, date);
                stack.Items.Add(name);
            }
            else { }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }
    }
}