using System;
using Xunit;

namespace test
{

    public class ShipsShould
    {
        [Fact]
        public void UseFiveSquaresIfBattleship()
        {
            int expectedSquaresInABattleship = 5;
            int squaresInABattleship = (int)Ships.Battleship;
            Assert.Equal(expectedSquaresInABattleship, squaresInABattleship);
        }

        [Fact]
        public void UseFourSquaresIfDestroyer()
        {
            int expectedSquaresInADestroyer = 4;
            int squaresInADestroyer = (int)Ships.Destroyer;
            Assert.Equal(expectedSquaresInADestroyer, squaresInADestroyer);
        }
    }
}
