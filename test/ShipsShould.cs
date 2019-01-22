using System;
using Xunit;

namespace test
{

    public class ShipsShould
    {
        [Fact]
        public void UseFiveSquaresIfBattleship()
        {
            int expected = 5;
            int actual = (int)Ships.Battleship;
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UseFourSquaresIfDestroyer()
        {
            int expected = 4;
            int actual = (int)Ships.Destroyer;
            Assert.Equal(expected,actual);
        }
    }
}
