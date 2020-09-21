using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    [Collection("UnitTest")]
    public class RobotMovementUnitTest
    {
        private readonly IRobotMovement _movement;

        public RobotMovementUnitTest()
        {
            _movement = new RobotMovement(new RobotMoveFactory());
        }

        [Theory]
        [InlineData(0, 90)]
        [InlineData(90, 180)]
        [InlineData(180, 270)]
        [InlineData(270, 0)]
        [InlineData(120, 210)]
        [InlineData(300, 30)]
        public void MoveRightOk(int currentOrientation, int targetOrientation)
        {
            Assert.Equal(targetOrientation, _movement.TurnRight(currentOrientation));
        }

        [Theory]
        [InlineData(0, 270)]
        [InlineData(270, 180)]
        [InlineData(180, 90)]
        [InlineData(90, 0)]
        [InlineData(120, 30)]
        [InlineData(45, 315)]
        public void MoveLeftOk(int currentOrientation, int targetOrientation)
        {
            Assert.Equal(targetOrientation, _movement.TurnLeft(currentOrientation));
        }
    }
}