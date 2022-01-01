using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    abstract class Figure
    {
        public int Type { get; set; }
        public System.Windows.Media.SolidColorBrush Color { get; private set; } = System.Windows.Media.Brushes.Yellow;
        public Figure()
        {
        }
        public Figure(int type, System.Windows.Media.SolidColorBrush color)
        {
            this.Type = type;
            this.Color = color;
        }
        public virtual int[,] GetFigure(int y, int x) { return null; }

    }
}
