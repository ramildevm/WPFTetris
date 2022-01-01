using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris
{
    class FigO : Figure
    {
        public FigO(int t) : base(t)
        {
        }
        public override int[,] GetFigure(int y, int x)
        {
            return new int[,] { { y, x }, { y, x + 1 }, { y + 1, x + 1 }, { y + 1, x } };
        }
    }
}
