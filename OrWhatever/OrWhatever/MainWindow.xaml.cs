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
using System.Windows.Threading;

namespace OrWhatever
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hungerNum = 100;
        //int animTimer = 0;
        //int animMax = 2;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            hungerNum--;
            if (hungerNum < 0)
            {
                hungerNum = 0;
            }
            hungerStat.Content = hungerNum;
            
            //if (animTimer > animMax && petDisplay.Source == '/image_assets/eat.jpg')
            //{
            //    animTimer = 0;
            //    petDisplay.Source = '/image_assets/idle.jpg';
            //}
        }

        private void feedButton_Click(object sender, RoutedEventArgs e)
        {
            hungerNum += 5;
            if (hungerNum > 100)
            {
                hungerNum = 100;
            }
            hungerStat.Content = hungerNum;

        }
    }
}
