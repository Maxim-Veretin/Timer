﻿using System;
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
    public partial class MainWindow : Window
    {
        DateTime date;

        public MainWindow() => InitializeComponent();

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
                date = add_timer.current;
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

        }
    }
}