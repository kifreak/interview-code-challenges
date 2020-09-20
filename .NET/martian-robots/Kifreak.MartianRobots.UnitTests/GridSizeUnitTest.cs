using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class GridSizeUnitTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 15)]
        [InlineData(50, 2)]
        public void CreateGridSizeOk(int x, int y)
        {
            Grid grid = new Grid(x, y);
            Assert.Equal(x, grid.X);
            Assert.Equal(y, grid.Y);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 3)]
        [InlineData(3, -25)]
        [InlineData(52, 13)]
        public void CreateGridSizeKo(int x, int y)
        {
            Assert.Throws<GridSizeException>(() => new Grid(x, y));
        }
    }
}