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
        public Figure()
        {
        }
        public Figure(int type)
        {
            this.Type = type;
        }
        public virtual int[,] GetType(int i) { return null; }
        public virtual int[,] Move(int y, int x) { return null; }

    }
}
