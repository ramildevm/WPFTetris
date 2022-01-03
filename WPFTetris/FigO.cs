using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigO : Figure
    {
        public FigO(int t, System.Windows.Media.SolidColorBrush color) : base(t, color)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            this.Type = 0;
            return new int[,] { { y, x }, { y, x + 1 }, { y + 1, x + 1 }, { y + 1, x } };
        }
        public override Figure GetCopy()
        {
            return new FigO(this.Type, this.Color);
        }
    }
}
