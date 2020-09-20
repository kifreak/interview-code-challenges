using Kifreak.MartianRobots.Console.Expressions.Parsers;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.Console.UnitTests
{
    public class InstructionExpressionUnitTests
    {
        [Theory]
        [InlineData("FFFF", "F", "F", "F", "F")]
        [InlineData("FRL", "F","R","L")]
        [InlineData("FF HH", "F","F"," ", "H", "H")]
        public void ParsingInstructionsOk(string line, params string[] expected)
        {
            Instructions instruction = ConsoleUnitTestsHelpers.DataParser<InstructionParser, Instructions>(line);
            Assert.Equal(expected.Length, instruction.Actions.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], instruction.Actions[i]);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ParsingInstructionsKo(string line)
        {
            Assert.Throws<InstructionException>(() =>
                ConsoleUnitTestsHelpers.DataParser<InstructionParser, Instructions>(line));
        }
    }
}
