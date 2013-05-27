using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class Grid
    {
        public bool[,] cells { get; set; }
        public Grid()
        {
            cells = new bool[10,10];
        }

        public int GetCellNeighborCount(int xHome, int yHome) 
        {
            int NeighborCount = 0;

            for (int y = yHome-1; y <= yHome+1; y++)
            {

                for (int x = xHome - 1; x <= xHome+1; x++)
                {
                    if ( x < cells.GetLength(0)
                         && y < cells.GetLength(1) 
                         && !(x<0 || y<0)
                         && !(x==xHome && y ==yHome )
                         && cells[x, y]
                        )
                    {
                        NeighborCount++;
                    }
                }
            }
            return NeighborCount;
        }
        //public int LiveCount()
        //{
        //    int liveCount = 0;
        //    for (int y = 0; y < Cells.GetLength(1); y++)
        //    {
        //        for (int x = 0; x < Cells.GetLength(0); x++)
        //        {
        //            if (Cells[x,y])
        //                liveCount++;
        //        }
        //    }
        //    return liveCount;
        //}

        public bool isGridAlive()
        {
            bool isAlive = false;

            //isAlive = (from c in Cells where c select).count();

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if (cells[x, y])
                    { 
                        isAlive = true;
                        break;
                    }  
                }
                if (isAlive)
                    break;
            }
            return isAlive;
        }
    }
}
