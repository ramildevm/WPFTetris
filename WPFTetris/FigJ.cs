using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigJ:Figure
    {
        public FigJ(int t) : base(t, System.Windows.Media.Brushes.Blue)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            switch (this.Type)
            {
                case 0:
                    return new int[,] { { y, x }, { y - 1, x }, { y + 1, x }, { y + 1, x - 1 } };
                case 1:
                    return new int[,] { { y, x }, { y, x - 1 }, { y - 1, x - 1 }, { y, x + 1 } };
                case 2:
                    return new int[,] { { y, x }, { y - 1, x + 1 }, { y - 1, x }, { y + 1, x } };
                case 3:
                    return new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y + 1, x + 1 } };
                default:
                    Type = 0;
                    return new int[,] { { y, x }, { y - 1, x }, { y + 1, x }, { y + 1, x - 1 } };
            }
        }
        public override Figure GetCopy()
        {
            return new FigJ(this.Type);
        }
    }
}
