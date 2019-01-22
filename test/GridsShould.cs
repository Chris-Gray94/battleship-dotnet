using System;
using Xunit;

namespace test
{
    public class GridsShould 
    { 
        [Fact]
        public void HaveTenColumns()
        {
            int expectedNumberOfColumns = 10;

            var grid = new Grid();
            int indexOfColumns = 1;

            int numberOfColumns = grid.Squares.GetLength(indexOfColumns);
            Assert.Equal(expectedNumberOfColumns, numberOfColumns);
        }

       [Fact]
        public void HaveTenRows()
        {
            int expectedNumberOfRows = 10;
            
            var grid = new Grid();
            int indexOfRows = 0;

            int numberOfRows = grid.Squares.GetLength(indexOfRows);
            Assert.Equal(expectedNumberOfRows,numberOfRows);
        }

        [Fact]
        public void HaveMissesByDefault()
        {
            var grid = new Grid();
            
            foreach(var square in grid.Squares)
            {
                Assert.Equal(State.Miss, square.State);
            }
        }
    }   

    public class Grid
    {
        private const int _defaultNumberOfColumns = 10;
        private const int _defaultNumberOfRows = 10;

        public Square[,] Squares { get;set;}

        public Grid()
        {
            Squares = new Square[_defaultNumberOfRows, _defaultNumberOfColumns];
        }
    }

    public class Square
    {
        public State State { get; set;} 

    }

    public enum State
    {
        Hit = 0,
        Miss = 1,
        Sunk = 2
    }
}