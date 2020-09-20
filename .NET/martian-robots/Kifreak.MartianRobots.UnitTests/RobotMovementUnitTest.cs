using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotMovementUnitTest
    {
        private readonly IRobotMovement _movement;
        public RobotMovementUnitTest()
        {
            _movement = new RobotMovement();
        }
        [Theory]
        [InlineData(0,90)]
        [InlineData(90, 180)]
        [InlineData(180, 270)]
        [InlineData(270, 0)]
        [InlineData(120, 210)]
        [InlineData(500, 0)]
        [InlineData(-100, 270)]
        public void MoveRightOk(int currentOrientation, int targetOrientation)
        {
            int current =_movement.TurnRight(currentOrientation);
            Assert.Equal(targetOrientation, current);
        }
        [Theory]
        [InlineData(0, 270)]
        [InlineData(270, 180)]
        [InlineData(180, 90)]
        [InlineData(90, 0)]
        [InlineData(120, 30)]
        [InlineData(500, 0)]
        [InlineData(-100, 270)]
        public void MoveLeftOk(int currentOrientation, int targetOrientation)
        {
            int current = _movement.TurnLeft(currentOrientation);
            Assert.Equal(targetOrientation, current);
        }
        
    }
}