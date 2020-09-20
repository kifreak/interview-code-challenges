using System;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Xunit;
using Xunit.Abstractions;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotMovementUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
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
        public void MoveRightOk(int currentOrientation, int targetOrientation)
        {
            int current = _movement.TurnRight(currentOrientation);
            Assert.Equal(targetOrientation, current);
        }

        [Theory]
        [InlineData(0, 270)]
        [InlineData(270, 180)]
        [InlineData(180, 90)]
        [InlineData(90, 0)]
        [InlineData(120, 30)]
        public void MoveLeftOk(int currentOrientation, int targetOrientation)
        {
            int current = _movement.TurnLeft(currentOrientation);
            Assert.Equal(targetOrientation, current);
        }
    }
}