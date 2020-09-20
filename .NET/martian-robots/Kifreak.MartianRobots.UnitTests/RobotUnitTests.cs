using System;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Moq;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotUnitTests: IDisposable
    {
        private readonly Mock<IRobotMovement> _robotMovementMock;
        private readonly Position _startPosition;
        private readonly Instructions _instructions;
        private readonly Grid _grid;
        private IRobot _robot;

        private readonly Position _moveForwardStaticPosition;
        public RobotUnitTests()
        {
            _moveForwardStaticPosition = new Position(0, 1, 0);
            _robotMovementMock = new Mock<IRobotMovement>();
            _robotMovementMock.Setup(movement => movement.TurnLeft(It.IsAny<int>())).Returns(0);
            _robotMovementMock.Setup(movement => movement.TurnRight(It.IsAny<int>())).Returns(90);
            _robotMovementMock.Setup(movement => movement.MoveForwards(It.IsAny<Position>())).Returns(_moveForwardStaticPosition);
            _grid = new Grid(5, 5);
            _startPosition = new Position(0,0,0);
            _instructions = new Instructions(new []{"F"});
            _robot = new Robot(_startPosition, _robotMovementMock.Object, _instructions);
        }

        [Fact]
        public void RobotTurnLeftOk()
        {
            _robot.TurnLeft();
            _robotMovementMock.Verify(move => move.TurnLeft(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void RobotTurnRightOk()
        {
            
            _robot.TurnRight(); 
            _robotMovementMock.Verify(move => move.TurnRight(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void RobotGetNextPosition()
        {
            Position position = _robot.GetNextPosition();
            _robotMovementMock.Verify(move => move.MoveForwards(It.IsAny<Position>()), Times.Once);
            Assert.Equal(_moveForwardStaticPosition.ToString(), position.ToString());
            Assert.Equal("0 0 N", _robot.ToString());
        }

        [Fact]
        public void RobotMoveToOk()
        {
            _robot.MoveTo(new Position(1,1,90));
            Assert.Equal("1 1 E", _robot.ToString());
        }

        [Fact]
        public void RobotLost()
        {
            Assert.Equal(ERobotStatus.Ok, _robot.Status);
            _robot.LostRobot();
            Assert.Equal(ERobotStatus.Lost, _robot.Status);
            Assert.Equal($"{_startPosition} LOST", _robot.ToString());
        }

        [Fact]
        public void RobotMoveForwardsOffGridCannotAssignPosition()
        {
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            Assert.Throws<PositionException>(() => _robot.GetNextPosition());
            _robotMovementMock.Verify(t => t.MoveForwards(It.IsAny<Position>()),Times.Once);
        }

        [Fact]
        public void RobotBuildKoWithNullDependencies()
        {
            Assert.Throws<RobotBuildException>(() =>
                new Robot(null, _robotMovementMock.Object, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_startPosition, null, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_startPosition, _robotMovementMock.Object,  null));
        }

        [Theory]
        [InlineData(0,0,0, "0 0 N")]
        [InlineData(1,1,90, "1 1 E")]
        [InlineData(10, 5, 180, "10 5 S")]
        [InlineData(0, 50, 270, "0 50 W")]
        public void RobotToStringVerificationWithOkStatue(int x, int y, int orientation, string expectToString)     
        {
            IRobot robot = new Robot(new Position(x,y,orientation), _robotMovementMock.Object, _instructions);
            Assert.Equal(expectToString, robot.ToString());
        }

        [Fact]
        public void RobotToStringVerificationWithLostState()
        {
            _robot = new Robot(new Position(0, 0,0), _robotMovementMock.Object, _instructions);
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            Assert.Throws<PositionException>(() => _robot.GetNextPosition());
            _robot.LostRobot();
            Assert.Equal("0 0 N LOST", _robot.ToString());
        }
        public void Dispose()
        {
            _robot = null;
        }
    }
}