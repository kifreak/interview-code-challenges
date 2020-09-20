using Kifreak.MartianRobots.Console.Expressions.Parsers;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.Console.UnitTests
{
    public class GridExpressionUnitTests
    {
        [Theory]
        [InlineData("1 1", 1, 1)]
        [InlineData("50 50",50,50)]
        public void ParsingGridOk(string line,  int expectedX, int expectedY)
        {
            var grid = ConsoleUnitTestsHelpers.DataParser<GridParser, Grid>(line);
            Assert.NotNull(grid);
            Assert.Equal(expectedX, grid.X);
            Assert.Equal(expectedY, grid.Y);
        }

        [Theory]
        [InlineData("-1, 0")]
        [InlineData("0, 1000")]
        [InlineData("51 5")]
        [InlineData("5 5 5")]
        [InlineData("Fail1 Fail2")]
        [InlineData("5")]
        [InlineData("")]
        [InlineData("0 0")]
        [InlineData(null)]
        public void ParsingGridKo(string line)
        {
            Assert.Throws<GridSizeException>(() => ConsoleUnitTestsHelpers.DataParser<GridParser, Grid>(line));
        }
        
    }
}