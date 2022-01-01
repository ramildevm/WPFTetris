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
        int[,] currentFigure = new int[4, 2];
        Figure figure;

        Dictionary<string, int[,]> figuresDict = new Dictionary<string, int[,]>();
        int y = 1;
        int x = 4;
        public MainWindow()
        {
            InitializeComponent();
            LoadButtons();
            FillFiguresDict();
            timer.Interval = new TimeSpan(0,0,0,0,200);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void FillFiguresDict()
        {
            y = 1;
            x = 4;
            //figuresDict.Add("I", new int[,] {{y,x},{y,x-1},{ });
            currentFigure = new int[,] { { y, x }, { y, x - 1 }, {y,x+1 },{ y, x + 2 } };
            figure = new FigI(0);
            for (int q = 0; q < 4; q++)
            {
                buttonsDict[$"{currentFigure[q,0]},{currentFigure[q, 1]}"].Background = Brushes.Black;
                buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "1";
            }
        }
        private void LoadButtons()
        {
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Button b = new Button();
                    //if (y < 2) b.Visibility = Visibility.Hidden;
                    //if (y == 15 || y == 16) { b.Background = Brushes.Black; b.Tag = "1"; }
                    //if (x == 5 && y > 10)
                    //{
                    //    b.Background = Brushes.Black; b.Tag = "1";
                    //}
                    mainPanel.Children.Add(b);
                    buttonsDict.Add($"{y},{x}", b);
                }
            }
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
            int allowed = 0;
            for (int q = 0; q < 4; q++)
            {
                if (y != 21 && !(buttonsDict[$"{currentFigure[q, 0] + 1},{currentFigure[q, 1]}"].Background != Brushes.White && buttonsDict[$"{currentFigure[q, 0]+1},{currentFigure[q, 1]}"].Tag.ToString() != "1"))
                {
                    allowed++;
                }
            }
            if (y < 21 && allowed == 4)
            {
                for (int q = 0; q < 4; q++)
                {
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Background = Brushes.White;
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "0";
                }
                y++;
                currentFigure = new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y, x + 2 } };
                for (int q = 0; q < 4; q++)
                {
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Background = Brushes.Black;
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "1";
                }
            }
            else
            {
                for (int q = 0; q < 4; q++)
                {
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "0";
                }
                FillFiguresDict();
            }
        }
        private void MoveDown(int ymax)
        {
            for (int y = 1; y < ymax; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    buttonsDict[$"{y+1},{x}"].Background = buttonsDict[$"{y},{x}"].Background;
                }
            }
        }
        private void Move(string side)
        {
            int i = (side == "Right") ? 1 : -1;
            int allowed = 0;
            for (int q = 0; q < 4; q++)
            {
                if (i == 1)
                {
                    if (currentFigure[q, 1] + 1 < 10 && !(buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1] + 1}"].Background != Brushes.White && buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1] + 1}"].Tag.ToString() != "1"))
                    {
                        allowed++;
                    }
                }
                else
                {
                    if (currentFigure[q, 1] - 1 >= 0 && !(buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1] - 1}"].Background != Brushes.White && buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1] - 1}"].Tag.ToString() != "1"))
                    {
                        allowed++;
                    }
                }
            }
            if (allowed == 4)
            {
                for (int q = 0; q < 4; q++)
                {
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Background = Brushes.White;
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "0";
                }
                x += i;
                currentFigure = figure.Move(y, x);
                for (int q = 0; q < 4; q++)
                {
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Background = Brushes.Black;
                    buttonsDict[$"{currentFigure[q, 0]},{currentFigure[q, 1]}"].Tag = "1";
                }
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                Move("Right");
            }
            else if (e.Key == Key.Left)
            {
                Move("Left");
            }
        }
    }
}
