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
using System.Windows.Threading;
using TcpServerToClientSendSS.AddditionalClasses;
using TcpServerToClientSendSS.ViewModels;

namespace TcpServerToClientSendSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }
        ScreenShot screenShot = new ScreenShot();
        public DateTime firstTime { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            MainViewModel.Source = screenShot.TakeScreenShot(4);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.01);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            firstTime = DateTime.Now;
            DataContext = MainViewModel;

        }
        int i = 0;
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                MainViewModel.Source = screenShot.TakeScreenShot(i++);
            });
            MainViewModel.Timer = (firstTime-DateTime.Now).ToString();
        }
    }
}
