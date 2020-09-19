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
        private readonly Mock<INotAllowPosition> _notAllowMock;
        private readonly Position _position;
        private readonly Instructions _instructions;
        private readonly Grid _grid;
        private IRobot _robot;
        public RobotUnitTests()
        {
            _robotMovementMock = new Mock<IRobotMovement>();
            _robotMovementMock.Setup(movement => movement.TurnLeft(It.IsAny<int>())).Returns(0);
            _robotMovementMock.Setup(movement => movement.TurnRight(It.IsAny<int>())).Returns(90);
            _robotMovementMock.Setup(movement => movement.MoveForwards(It.IsAny<Position>())).Returns(new Position(1,0,0));
            _notAllowMock = new Mock<INotAllowPosition>();
            _grid = new Grid(5, 5, _notAllowMock.Object);
            _position = new Position(0,0,0);
            _instructions = new Instructions(new []{"F"});
            _robot = new Robot(_position, _robotMovementMock.Object, _grid, _instructions);
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
        public void RobotMoveForwardOk()
        {
            _notAllowMock.Setup(t => t.IsNotAllowPosition(It.IsAny<Position>())).Returns(false);
            _robot.MoveForward();
            _robotMovementMock.Verify(move => move.MoveForwards(It.IsAny<Position>()), Times.Once);
            _notAllowMock.Verify(avoid => avoid.IsNotAllowPosition(It.IsAny<Position>()), Times.Once);
            _notAllowMock.Verify(avoid => avoid.AddNotAllowedPosition(It.IsAny<Position>()), Times.Never);
            Assert.Equal(ERobotStatus.Ok, _robot.Status);
        }

        [Fact]
        public void RobotMoveForwardsOffGrid()
        {
            _notAllowMock.Setup(t => t.IsNotAllowPosition(It.IsAny<Position>())).Returns(false);
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            _robot.MoveForward();
            _robotMovementMock.Verify(t => t.MoveForwards(It.IsAny<Position>()),Times.Once);
            _notAllowMock.Verify(avoid => avoid.AddNotAllowedPosition(It.IsAny<Position>()),Times.Once);
            _notAllowMock.Verify(avoid => avoid.IsNotAllowPosition(It.IsAny<Position>()),Times.Once);
            Assert.Equal(ERobotStatus.Lost, _robot.Status);
            
        }

        [Fact]
        public void RobotMoveToNotAllowPosition()
        {
            _notAllowMock.Setup(t => t.IsNotAllowPosition(It.IsAny<Position>())).Returns(true);
            _robot.MoveForward();
            _robotMovementMock.Verify(move => move.MoveForwards(It.IsAny<Position>()),Times.Once);
            _notAllowMock.Verify(avoid => avoid.AddNotAllowedPosition(It.IsAny<Position>()),Times.Never);
        }

        [Fact]
        public void RobotBuildKoWithNullDependencies()
        {
            Assert.Throws<RobotBuildException>(() =>
                new Robot(null, _robotMovementMock.Object, _grid, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, null, _grid, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, _robotMovementMock.Object, null, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, _robotMovementMock.Object, _grid, null));
        }

        [Theory]
        [InlineData(0,0,0, "0 0 N")]
        [InlineData(1,1,90, "1 1 E")]
        [InlineData(10, 5, 180, "10 5 S")]
        [InlineData(0, 50, 270, "0 50 W")]
        public void RobotToStringVerificationWithOkStatue(int x, int y, int orientation, string expectToString)     
        {
            IRobot robot = new Robot(new Position(x,y,orientation), _robotMovementMock.Object, _grid, _instructions);
            Assert.Equal(expectToString, robot.ToString());
        }

        [Fact]
        public void RobotToStringVerificationWithLostState()
        {
            IRobot robot = new Robot(new Position(0, 0,0), _robotMovementMock.Object, _grid, _instructions);
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            robot.MoveForward();
            Assert.Equal("0 0 N Lost", robot.ToString());
        }
        public void Dispose()
        {
            _robot = null;
        }
    }
}