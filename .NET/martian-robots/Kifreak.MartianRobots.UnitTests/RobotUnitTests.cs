using System;
using System.Collections.Generic;
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
        private Mock<IRobotMovement> _robotMovementMock;
        private Mock<IAvoidArea> _avoidAreaMock;
        private Position _position;
        private Instructions _instructions;
        private IRobot _robot;
        public RobotUnitTests()
        {
            _robotMovementMock = new Mock<IRobotMovement>();
            _robotMovementMock.Setup(movement => movement.TurnLeft(It.IsAny<int>())).Returns(0);
            _robotMovementMock.Setup(movement => movement.TurnRight(It.IsAny<int>())).Returns(90);
            _robotMovementMock.Setup(movement => movement.MoveForwards(It.IsAny<Position>())).Returns(new Position(1,0,0));
            _avoidAreaMock = new Mock<IAvoidArea>();
            _position = new Position(0,0,0);
            _instructions = new Instructions(new []{"F"});
            _robot = new Robot(_position, _robotMovementMock.Object, _avoidAreaMock.Object, _instructions);
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
            _avoidAreaMock.Setup(t => t.IsAvoidArea(It.IsAny<Position>())).Returns(false);
            _robot.MoveForward();
            _robotMovementMock.Verify(move => move.MoveForwards(It.IsAny<Position>()), Times.Once);
            _avoidAreaMock.Verify(avoid => avoid.IsAvoidArea(It.IsAny<Position>()), Times.Once);
            _avoidAreaMock.Verify(avoid => avoid.AddAvoidArea(It.IsAny<Position>()), Times.Never);
            Assert.Equal(ERobotStatus.OK, _robot.Status);
        }

        [Fact]
        public void RobotMoveForwardsOffGrid()
        {
            _avoidAreaMock.Setup(t => t.IsAvoidArea(It.IsAny<Position>())).Returns(false);
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            _robot.MoveForward();
            _robotMovementMock.Verify(t => t.MoveForwards(It.IsAny<Position>()),Times.Once);
            _avoidAreaMock.Verify(avoid => avoid.AddAvoidArea(It.IsAny<Position>()),Times.Once);
            _avoidAreaMock.Verify(avoid => avoid.IsAvoidArea(It.IsAny<Position>()),Times.Once);
            Assert.Equal(ERobotStatus.LOST, _robot.Status);
            
        }

        [Fact]
        public void RobotMoveToAvoidArea()
        {
            _avoidAreaMock.Setup(t => t.IsAvoidArea(It.IsAny<Position>())).Returns(true);
            _robot.MoveForward();
            _robotMovementMock.Verify(move => move.MoveForwards(It.IsAny<Position>()),Times.Once);
            _avoidAreaMock.Verify(avoid => avoid.AddAvoidArea(It.IsAny<Position>()),Times.Never);
        }

        [Fact]
        public void RobotBuildKoWithNullDependencies()
        {
            Assert.Throws<RobotBuildException>(() =>
                new Robot(null, _robotMovementMock.Object, _avoidAreaMock.Object, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, null, _avoidAreaMock.Object, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, _robotMovementMock.Object, null, _instructions));
            Assert.Throws<RobotBuildException>(() =>
                new Robot(_position, _robotMovementMock.Object, _avoidAreaMock.Object, null));
        }

        [Theory]
        [InlineData(0,0,0, "0 0 N")]
        [InlineData(1,1,90, "1 1 E")]
        [InlineData(10, 5, 180, "10 5 S")]
        [InlineData(0, 50, 270, "0 50 W")]
        public void RobotToStringVerificationWithOkStatue(int x, int y, int orientation, string expectToString)     
        {
            IRobot robot = new Robot(new Position(x,y,orientation), _robotMovementMock.Object, _avoidAreaMock.Object, _instructions);
            Assert.Equal(expectToString, robot.ToString());
        }

        [Fact]
        public void RobotToStringVerificationWithLostState()
        {
            IRobot robot = new Robot(new Position(0, 0,0), _robotMovementMock.Object, _avoidAreaMock.Object, _instructions);
            _robotMovementMock.Setup(move => move.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            robot.MoveForward();
            Assert.Equal("0 0 N LOST", robot.ToString());
        }
        public void Dispose()
        {
            _robot = null;
        }
    }
}