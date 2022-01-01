using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigI : Figure
    {
        public FigI(int t) : base(t)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            switch (this.Type)
            {
                case 0:
                    return new int[,] { { y, x }, { y, x - 1 }, { y, x + 1 }, { y, x + 2 } };
                case 1:
                    return new int[,] { { y, x }, { y - 1, x }, { y + 1, x }, { y + 2, x } };
                default:
                    return null;

            }
        }
    }
}
