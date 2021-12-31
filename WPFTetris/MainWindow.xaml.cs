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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int[], Button> buttonsDict = new Dictionary<int[], Button>();
        public MainWindow()
        {
            InitializeComponent();
            LoadButtons();
        }
        private void LoadButtons()
        {
            for(int y = 0;y<22; y++)
            {
                for (int x = 0; x < 10; x++)
                {                    
                    Button b = new Button();
                    if (y < 2) b.Visibility = Visibility.Hidden;
                    mainPanel.Children.Add(b);
                    buttonsDict.Add(new int[] {y,x }, b);
                }
            }
        }
    }
}
