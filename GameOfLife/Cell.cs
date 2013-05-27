using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }
    }
}
