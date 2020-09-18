using System;
using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotEngineUnitTests: IDisposable
    {
        private RobotEngine _engine;
        public RobotEngineUnitTests()
        {
            _engine = new RobotEngine(
                new Robot(new Position(0,0,0)),
                new RobotMovement(), 
                new AvoidArea()
                );
        }
        [Fact]
        public void MoveLeftOk()
        {
            _engine.TurnLeft();
            Assert.Equal(270, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnLeft();
            Assert.Equal(180, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnLeft();
            Assert.Equal(90, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnLeft();
            Assert.Equal(0, _engine.Robot.CurrentPosition.Orientation);
        }

        [Fact]
        public void MoveRightOk()
        {
            _engine.TurnRight();
            Assert.Equal(90, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnRight();
            Assert.Equal(180, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnRight();
            Assert.Equal(270, _engine.Robot.CurrentPosition.Orientation);
            _engine.TurnRight();
            Assert.Equal(0, _engine.Robot.CurrentPosition.Orientation);
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
            _engine.TurnRight();
            realPositions.Add(MoveForwards());
            realPositions.Add(MoveForwards());
            _engine.TurnLeft();
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
            _engine.MoveForward();
            return new Position(_engine.Robot.CurrentPosition.X, _engine.Robot.CurrentPosition.Y, _engine.Robot.CurrentPosition.Orientation);
        }

        //[Fact]
        //public void MoveForwardImpossiblePosition()
        //{
        //    throw new NotImplementedException();
        //}
        public void Dispose()
        {
            _engine = null;
        }
    }
}