using System;
using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotUnitTests: IDisposable
    {
        private Robot _robot;
        public RobotUnitTests()
        {
            _robot = new Robot(
                new Position(0,0,0),
                new RobotMovement(), 
                new AvoidArea(),
                new Instructions(new [] {"F","F","F"})
                );
        }
        [Fact]
        public void MoveLeftOk()
        {
            _robot.TurnLeft();
            Assert.Equal(270, _robot.CurrentPosition.Orientation);
            _robot.TurnLeft();
            Assert.Equal(180, _robot.CurrentPosition.Orientation);
            _robot.TurnLeft();
            Assert.Equal(90, _robot.CurrentPosition.Orientation);
            _robot.TurnLeft();
            Assert.Equal(0, _robot.CurrentPosition.Orientation);
        }

        [Fact]
        public void MoveRightOk()
        {
            _robot.TurnRight();
            Assert.Equal(90, _robot.CurrentPosition.Orientation);
            _robot.TurnRight();
            Assert.Equal(180, _robot.CurrentPosition.Orientation);
            _robot.TurnRight();
            Assert.Equal(270, _robot.CurrentPosition.Orientation);
            _robot.TurnRight();
            Assert.Equal(0, _robot.CurrentPosition.Orientation);
        }

        [Fact]
        public void MoveForwardsOk()
        {
            List<Position> expectedPositions = new List<Position>
            {
                new Position(0,1,0),
                new Position(1,1,90),
                new Position(2,1,90),
                new Position(2,2,0),
                new Position(2,3,0)
            };
            List<Position> realPositions = new List<Position>();
            realPositions.Add(MoveForwards());
            _robot.TurnRight();
            realPositions.Add(MoveForwards());
            realPositions.Add(MoveForwards());
            _robot.TurnLeft();
            realPositions.Add(MoveForwards());
            realPositions.Add(MoveForwards());
            Assert.NotEmpty(realPositions);
            Assert.Equal(expectedPositions.Count, realPositions.Count);
            for (int i = 0; i < expectedPositions.Count; i++)
            {
                Assert.Equal(expectedPositions[i].ToString(), realPositions[i].ToString());
            }
        }

        private Position MoveForwards()
        {
            _robot.MoveForward();
            return new Position(_robot.CurrentPosition.X, _robot.CurrentPosition.Y, _robot.CurrentPosition.Orientation);
        }

        //[Fact]    
        //public void MoveForwardImpossiblePosition()
        //{
        //    throw new NotImplementedException();
        //}
        public void Dispose()
        {
            _robot = null;
        }
    }
}