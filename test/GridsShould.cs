using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.Equal(expectedNumberOfRows, numberOfRows);
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

        [Fact]
        public void Contains_One_Battleships_And_Two_Destroyer()
        {
            var grid = new Grid();
            var expectedNumberOfBattleships = 1;
            var expectedNumberOfDestroyers = 2;

            var actualBattleships = grid.Ships.Where(y => y.Type == ShipType.Battleship).ToList();
            var actualDestroyers = grid.Ships.Where(y => y.Type == ShipType.Destroyer).ToList();

            Assert.Equal(expectedNumberOfBattleships, actualBattleships.Count());
            Assert.Equal(expectedNumberOfDestroyers, actualDestroyers.Count());
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        public void ShipsInTheGrid_Are_In_Different_Positions(int firstPositionToEvaluate, int secondPositionToEvaluate)
        {
            var grid = new Grid();
            var firstShipPoistions = grid.Ships[firstPositionToEvaluate].Positions;
            var secondShipPositions = grid.Ships[secondPositionToEvaluate].Positions;

            foreach(var firstPosition in firstShipPoistions)
            {
                foreach(var secondPosition in secondShipPositions)
                {
                    Assert.NotEqual(firstPosition.X, secondPosition.X);
                    Assert.NotEqual(firstPosition.Y, secondPosition.Y);
                }
            }
        }
    }

    public class Grid
    {
        private const int _defaultNumberOfColumns = 10;
        private const int _defaultNumberOfRows = 10;

        public Square[,] Squares { get;set;}

        public List<Ship> Ships { get; set; }

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

        /// <summary>
        /// Use your learnings to refactor this method.
        /// Think that you have 3 ships here that maybe you could use somewhere else.
        /// Don't give up : D
        /// </summary>
        /// <returns></returns>
        public List<Ship> getShips()
        {
            var shipList = new List<Ship>();
            var battleship = new Ship(ShipType.Battleship);
            shipList.Add(battleship);

            for (int i = 0; i <= 1; i++)
            {
                shipList.Add(new Ship(ShipType.Destroyer));
            }
            return shipList;
        }
    }

    public class Square
    {
        public State State { get; set;}

        public int X { get; set; }

        public int Y { get; set; }
    }

    public class Ship
    {
        public List<Square> Positions { get; set; }
        public ShipType Type { get; set; }

        public Ship(ShipType Type)
        {
            this.Type = Type; 

        }
    }

    public enum State
    {
        Hit = 0,
        Miss = 1,
        Sunk = 2
    }
}