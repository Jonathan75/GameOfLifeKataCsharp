using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameOfLife
{
    public class Game
    {
        public Grid grid{ get; set; }
        private int GenerationsToLive = 100; 

        public Game()
        { 
            grid = new Grid();            
        }
        public Game(int SetGenerationsToLive )
        {
            grid = new Grid();
            GenerationsToLive = SetGenerationsToLive;
        }

        public void Play()
        {
            int GenerationCount = 0;

            while (grid.isGridAlive() 
                    && (GenerationCount < GenerationsToLive)
                   )
            {
                Generation();
                GenerationCount++;
            }

        }

        private void Generation() 
        {
            
            for (int x = 0; x <  grid.cells.GetLength(0); x++)
            {
                for (int y = 0; y < grid.cells.GetLength(1); y++)
                {
                    int NeighborCount = grid.GetCellNeighborCount(x, y);


                    //live
                    grid.cells[x, y] = !(NeighborCount < 2);


                    //die
                    grid.cells[x, y] = !(NeighborCount > 3);
                    
                    //born
                    grid.cells[x, y] = !(NeighborCount == 3);

                }
            }
        }


    }
}
