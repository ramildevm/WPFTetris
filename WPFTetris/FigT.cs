using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigT : Figure
    {
        public FigT(int t) : base(t, System.Windows.Media.Brushes.Violet)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            switch (this.Type)
            {
                case 0:
                    return new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y-1, x } };
                case 1:
                    return new int[,] { { y, x }, { y - 1, x }, { y + 1, x }, { y, x+1 } };
                case 2:
                    return new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y + 1, x } };
                case 3:
                    return new int[,] { { y, x }, { y - 1, x }, { y + 1, x }, { y, x - 1 } };
                default:
                    Type = 0;
                    return new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y - 1, x } };
            }
        }
        public override Figure GetCopy()
        {
            return new FigT(this.Type);
        }
    }
}
