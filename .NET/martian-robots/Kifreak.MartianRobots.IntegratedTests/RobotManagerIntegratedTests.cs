using System;
using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.IntegratedTests
{
    public class RobotManagerIntegratedTests: IDisposable
    {
        private readonly IRobotMovement _robotMovement;
        private readonly IActionFactory _actionFactory;
        private readonly Grid _grid;
        private NotAllowPosition _notAllowPosition;
        public RobotManagerIntegratedTests()
        {
            _robotMovement = new RobotMovement();
            _actionFactory = new ActionFactory();
            _notAllowPosition = new NotAllowPosition();
            _grid = new Grid(5,5);
            
        }

        [Fact]
        public void MoveFewRobotsWithSimpleInstructions()
        {
            Instructions robot1Instructions = new Instructions(new[] { "F", "F", "R", "F", "F" });
            Instructions robot2Instructions = new Instructions(new[] { "F", "F", "L", "F", "F" });
            IRobot robot1 = new Robot(new Position(0, 0, 0), _robotMovement, robot1Instructions);
            IRobot robot2 = new Robot(new Position(0, 0, 90), _robotMovement, robot2Instructions);
            ExecuteRobotManager(robot1, robot2);
            
            Assert.Equal("2 2 90", robot1.ToString());
            Assert.Equal("2 2 0", robot2.ToString());
        }

        [Fact]
        public void MoveRobotsToAndAvoidPosition()
        {
            _notAllowPosition.AddNotAllowedPosition(new Position(1,1,0));
            Instructions robot1Instructions = new Instructions(new []{"F","R","F","R","F"});
            IRobot robot1 = new Robot(new Position(0, 0, 0), 
                _robotMovement, robot1Instructions);
            Instructions robot2Instructions = new Instructions(new[] { "F","F","F","F" });
            IRobot robot2 = new Robot(new Position(1, 0, 0),
                _robotMovement, robot2Instructions);
            ExecuteRobotManager(robot1, robot2);
            
            Assert.Equal("0 0 180", robot1.ToString());
            Assert.Equal("1 0 0", robot2.ToString());
        }

        [Fact]
        public void MoveRobotToLostPositionAndTheOtherDoesNotTakeThisWay()
        {
            Instructions robot1Instructions = new Instructions(new[] { "F", "L", "F", "R", "F" });
            IRobot robot1 = new Robot(new Position(0, 0, 0),
                _robotMovement, robot1Instructions);
            Instructions robot2Instructions = new Instructions(new[] { "R", "R", "F", "F" });
            IRobot robot2 = new Robot(new Position(1, 1, 90),
                _robotMovement, robot2Instructions);
            Instructions robot3Instructions = new Instructions(new [] { "F", "F", "F", "F", "F", "F", "F", "F" });
            IRobot robot3 = new Robot(new Position(1, 1, 0),
                _robotMovement, robot3Instructions);


            ExecuteRobotManager( robot1, robot2, robot3);

            Assert.Equal("0 1 270 LOST", robot1.ToString());
            Assert.Equal("1 1 270", robot2.ToString());
            Assert.Equal("1 4 0 LOST", robot3.ToString());
        }

        private void ExecuteRobotManager(params IRobot[] robots)
        {
            var manager = new RobotManager(_grid, _notAllowPosition, _actionFactory);
            manager.AddRobot(robots);
            manager.ExecuteAllRobots();
        }
        public void Dispose()
        {
            _notAllowPosition = new NotAllowPosition();
            
        }
    }
}
