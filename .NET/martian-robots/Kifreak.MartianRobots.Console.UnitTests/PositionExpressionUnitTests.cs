using Kifreak.MartianRobots.Console.Expressions.Parsers;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.Console.UnitTests
{
    public class PositionExpressionUnitTests
    {
        [Theory]
        [InlineData("0 0 N", 0, 0, 0)]
        [InlineData("15 50 E", 15, 50, 90)]
        [InlineData("1 1 S", 1, 1, 180)]
        [InlineData("5 25 W", 5, 25, 270)]
        [InlineData("-5 5 N", -5, 5, 0)]
        public void ParsingPositionOk(string line, int expectedX, int expectedY, int expectedOrientation)
        {
            Position position = ConsoleUnitTestsHelpers.DataParser<PositionParser, Position>(line);
            Assert.Equal(new Position(expectedX, expectedY, expectedOrientation).ToString(), position.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("0 0")]
        [InlineData("0 0 N 1 1")]
        [InlineData("F 0 N")]
        [InlineData("0 F N")]
        [InlineData("0 0 H")]
        public void ParsingPositionKo(string line)
        {
            Assert.Throws<PositionException>(() => ConsoleUnitTestsHelpers.DataParser<PositionParser, Position>(line));
        }
    }
}