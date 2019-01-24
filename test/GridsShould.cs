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

            var defaultValue = (Square)grid.Squares.GetValue(0, 0);

            foreach (var square in grid.Squares)
            {
                Assert.Equal(State.Miss, defaultValue.State);

            }
        }
        
    public class Grid
    {
        private const int _defaultNumberOfColumns = 10;
        private const int _defaultNumberOfRows = 10;

        public Square[,] Squares { get;set;}

        public State State { get; set;}    

        public Grid()
        {
            Squares = new Square[_defaultNumberOfRows, _defaultNumberOfColumns];
            var defaultStateValue = State.Miss;
            var mySquare = new Square()
            {
                State = defaultStateValue
            };

            
            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    Squares.SetValue(mySquare, i, j);               
                }
            }
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