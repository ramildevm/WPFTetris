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


namespace WPFTetris
{
    public partial class MainWindow : Window
    {
        Dictionary<string, Button> buttonsDict = new Dictionary<string, Button>();
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            LoadButtons();
            timer.Interval = new TimeSpan(0,0,1,0,500);
            timer.Tick += timer_Tick;

        }
        private void LoadButtons()
        {
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Button b = new Button();
                    if (y < 2) b.Visibility = Visibility.Hidden;
                    mainPanel.Children.Add(b);
                    buttonsDict.Add($"{y},{x}", b);
                }
            }
            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        { 
            for (int y = 2; y < 22; y++)
            {
                bool isWhite = false;
                for (int x = 0; x < 10; x++)
                {
                    if (buttonsDict[$"{y},{x}"].Background == Brushes.White) isWhite = true;
                }
                if (!isWhite)
                {
                    MoveDown(y);
                }
            }
        }
        private void MoveDown(int ymax)
        {
            for (int y = 1; y < ymax; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    buttonsDict[$"{y+1},{x}"].Background = buttonsDict[$"{y}{x}"].Background;
                }
            }
        }
    }
}
