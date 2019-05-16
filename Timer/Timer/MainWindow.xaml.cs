using System;
using System.Collections.Generic;
using System.IO;
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
    /// + 2. Таймер + прекол
    /// 3. Редактирование
    /// + 4. Сохранение
    /// + 5. Загрузка
    /// 6. Удаление
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
            DateTime time = list[stack.SelectedValue.ToString()];

            if ((time - date1).TotalSeconds < 0)
            {
                Timer.Stop();
                TimeEnd end = new TimeEnd();
                if (end.ShowDialog() == true)
                { }
            }
            
            if (Days.IsChecked == true)
                lb.Content += (time - date1).Days.ToString() + ":";

            if (Hours.IsChecked == true)
                lb.Content += (time - date1).Hours.ToString() + ":";

            if (Minutes.IsChecked == true)
                lb.Content += (time - date1).Minutes.ToString() + ":";

            if (Seconds.IsChecked == true)
                lb.Content += (time - date1).Seconds.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };
            dialog.ShowDialog();
            //string line = text.Text;
            using (StreamWriter outputFile = new StreamWriter(dialog.FileName))
            {
                foreach(KeyValuePair<string, DateTime> entry in list)
                {
                    outputFile.WriteLine(entry.Key);
                    outputFile.WriteLine(entry.Value);
                }
                //outputFile.WriteLine(list);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Document.txt"
            };
            dialog.ShowDialog();

            string line;
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\Document.txt");
            while ((line = file.ReadLine()) != null)
            {
                string name = line;
                stack.Items.Add(name);
                line = file.ReadLine();
                DateTime dt = DateTime.Parse(line);
                list.Add(name, date);
            }
            file.Close();
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
            list.Remove(stack.SelectedValue.ToString());
            stack.Items.Remove(stack.SelectedValue.ToString());
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            AddTimerWnd add_timer = new AddTimerWnd();

            if (add_timer.ShowDialog() == true)
            {
                date = add_timer.current;
                name = add_timer.nm;
                list.Remove(stack.SelectedValue.ToString());
                stack.Items.Remove(stack.SelectedValue.ToString());
                list.Add(name, date);
                stack.Items.Add(name);
            }
            else { }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }
    }
}