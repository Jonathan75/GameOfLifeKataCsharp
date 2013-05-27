using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GridTests
    {
        //Grid grid;
        Game game;

        [SetUp]
        public void Setup()
        {
            //grid = new Grid();
            game = new Game(1);
        }

        //[Test]
        //public void empty_cells_in_new_grid_dont_cause_exceptions()
        //{
        //    Assert.DoesNotThrow(new TestDelegate(TryToStickNullInCell));
        //}
        //[Test]
        //public void cells_in_new_grid_must_be_able_to_be_empty() 
        //{
        //    grid.Cells[1, 1] = null;
        //    Cell cell = grid.Cells[1, 1];
        //    Assert.IsNull(cell);
        //}

        //void TryToStickNullInCell()
        //{
        //    grid.Cells[1, 1] = null;
        //}


        [Test]
        public void cell_can_be_alive()
        {
            game.grid.cells[0, 0] = true;
            Assert.IsTrue(game.grid.cells[0,0]);
        }
        [Test]
        public void cell_can_be_dead()
        {
            game.grid.cells[0, 0] = false;
            Assert.IsFalse(game.grid.cells[0, 0]);
        }
        [Test]
        public void new_game_will_contain_a_new_grid()
        {   
            Assert.IsNotNull(game.grid);
        }

        [Test]
        public void grid_should_get_the_neighbors_of_a_cell()
        {
            int NeighborCount = game.grid.GetCellNeighborCount(1,1);
            Assert.GreaterOrEqual(NeighborCount,0);
            
        }

        [Test]
        public void cell_with_less_then_2_neighbors_should_die()
        {
            //int NeighborCount = game.grid.GetCellNeighborCount(1, 1);
            //0x
            //00

            //home cell
            game.grid.cells[0, 0] = true;

            //neighbors
            game.grid.cells[1, 0] = true;
            
            game.Play();

            Assert.IsFalse(game.grid.cells[0, 0], "Should die");            
        }

        //2. Any live cell with two or three live neighbors lives on to the next generation.
        [Test]
        public void Any_live_cell_with_two_or_three_live_neighbors_lives_on_to_the_next_generation()
        {
            //int NeighborCount = game.grid.GetCellNeighborCount(1, 1);
            //xx
            //x0

            //home cell
            game.grid.cells[0, 0] = false;

            //neighbors
            game.grid.cells[0, 1] = true;
            game.grid.cells[1, 0] = true;
            game.Play();
            //game.grid.cells[1, 1] = true;
            Assert.IsTrue(game.grid.cells[0, 0], "Should live");
        }

        //3. Any live cell with more than three live neighbours dies, as if by overcrowding.
        [Test]
        public void Any_live_cell_with_more_than_three_live_neighbors_dies()
        {
            //int NeighborCount = game.grid.GetCellNeighborCount(1, 1);
            //oXx
            //xxx

            //home cell
            game.grid.cells[0, 1] = true;

            //neighbors
            game.grid.cells[0, 2] = true;
            game.grid.cells[1, 0] = true;
            game.grid.cells[1, 1] = true;
            game.grid.cells[1, 2] = true;

            game.Play();
            //game.grid.cells[1, 1] = true;
            Assert.IsFalse(game.grid.cells[0, 1], "Should die");
        }

        //4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        [Test]
        public void Any_dead_cell_with_exactly_three_live_neighbours_becomes_a_live_cell()
        {
            //ooo
            //xxx

            //home cell
            game.grid.cells[0, 1] = false;

            //neighbors            
            game.grid.cells[1, 0] = true;
            game.grid.cells[1, 1] = true;
            game.grid.cells[1, 2] = true;

            game.Play();
            //game.grid.cells[1, 1] = true;
            Assert.IsTrue(game.grid.cells[0, 1], "Should live");
        }

    }
}
