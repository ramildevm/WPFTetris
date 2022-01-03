using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigZL : Figure
    {
        public FigZL(int t) : base(t, System.Windows.Media.Brushes.Red)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            switch (this.Type)
            {
                case 0:
                    return new int[,] { { y, x }, { y, x + 1 }, { y - 1, x + 1}, { y + 1, x } };
                case 1:
                    return new int[,] { { y, x }, { y + 1, x }, { y + 1, x + 1 }, { y, x - 1 } };
                default:
                    this.Type = 0;
                    return new int[,] { { y, x }, { y, x + 1 }, { y - 1, x + 1 }, { y + 1, x } };
            }
        }
        public override Figure GetCopy()
        {
            return new FigZL(this.Type);
        }
    }
}
