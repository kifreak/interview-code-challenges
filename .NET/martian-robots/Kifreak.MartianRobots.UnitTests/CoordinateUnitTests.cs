using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class CoordinateUnitTests
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(3, 5,90)]
        [InlineData(50, 50,180)]
        [InlineData(25, 23, 270)]
        public void CoordinateParametersOk(int x, int y, int orientation)
        {
            Position position = new Position(x, y, orientation);
            Assert.NotNull(position);
            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }

        [Theory]
        [InlineData(-5, 0,0)]
        [InlineData(0, -3,90)]
        [InlineData(50, 51,180)]
        [InlineData(50000, 1,270)]
        [InlineData(25, 30, 14)]
        public void CoordinatesParameterKo(int x, int y, int orientation)
        {
            Assert.Throws<PositionException>(() => new Position(x, y,orientation));
        }

        
    }
}