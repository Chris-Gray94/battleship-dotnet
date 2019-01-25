using System;
using Xunit;

namespace test
{

    public class ShipTypeShould
    {
        [Fact]
        public void UseFiveSquaresIfBattleship()
        {
            int expectedSquaresInABattleship = 5;
            int squaresInABattleship = (int)ShipType.Battleship;
            Assert.Equal(expectedSquaresInABattleship, squaresInABattleship);
        }

        [Fact]
        public void UseFourSquaresIfDestroyer()
        {
            int expectedSquaresInADestroyer = 4;
            int squaresInADestroyer = (int)ShipType.Destroyer;
            Assert.Equal(expectedSquaresInADestroyer, squaresInADestroyer);
        }
    }
}
