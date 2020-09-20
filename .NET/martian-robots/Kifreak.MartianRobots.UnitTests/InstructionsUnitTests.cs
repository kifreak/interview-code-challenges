using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class InstructionsUnitTests
    {
        [Fact]
        public void AddInstructionsOk()
        {
            Instructions instructions = new Instructions(new[] { "F", "F", "F" });
            Assert.NotNull(instructions.Actions);
            Assert.NotEmpty(instructions.Actions);
            Assert.Equal(3, instructions.Actions.Length);
        }

        [Fact]
        public void AddInstructionsKo()
        {
            Assert.Throws<InstructionException>(() => new Instructions(null));
            Assert.Throws<InstructionException>(() => new Instructions(new string[150]));
        }
    }
}