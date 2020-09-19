using System;
using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.IntegratedTests
{
    public class RobotManagerIntegratedTests: IDisposable
    {
        private readonly IRobotMovement _robotMovement;
        private readonly IActionFactory _actionFactory;
        private readonly GridSize _gridSize;
        private AvoidArea _avoidArea;
        public RobotManagerIntegratedTests()
        {
            _robotMovement = new RobotMovement();
            _actionFactory = new ActionFactory();
            _gridSize = new GridSize(5,5);
            _avoidArea = new AvoidArea();
        }

        [Fact]
        public void MoveFewRobotsWithSimpleInstructions()
        {
            Instructions robot1Instructions = new Instructions(new[] { "F", "F", "R", "F", "F" });
            Instructions robot2Instructions = new Instructions(new[] { "F", "F", "L", "F", "F" });
            IRobot robot1 = new Robot(new Position(0, 0, 0), _robotMovement, _avoidArea, robot1Instructions);
            IRobot robot2 = new Robot(new Position(0, 0, 90), _robotMovement, _avoidArea, robot2Instructions);
            ExecuteRobotManager(new List<IRobot> {robot1, robot2});
            
            Assert.Equal("2 2 E", robot1.ToString());
            Assert.Equal("2 2 N", robot2.ToString());
        }

        [Fact]
        public void MoveRobotsToAndAvoidPosition()
        {
            _avoidArea.AddAvoidArea(new Position(1,1,0));
            Instructions robot1Instructions = new Instructions(new []{"F","R","F","R","F"});
            IRobot robot1 = new Robot(new Position(0, 0, 0), 
                _robotMovement, _avoidArea, 
                robot1Instructions);
            Instructions robot2Instructions = new Instructions(new[] { "F","F","F","F" });
            IRobot robot2 = new Robot(new Position(1, 0, 0),
                _robotMovement, _avoidArea,
                robot2Instructions);
            ExecuteRobotManager(new List<IRobot> {robot1, robot2});
            
            Assert.Equal("0 0 S", robot1.ToString());
            Assert.Equal("1 0 N", robot2.ToString());


        }

        private void ExecuteRobotManager(List<IRobot> robots)
        {
            var manager = new RobotManager(_avoidArea, _gridSize, _actionFactory);
            manager.AddRobot(robots);
            manager.ExecuteAllRobots();
        }
        public void Dispose()
        {
            _avoidArea = new AvoidArea();
            
        }
    }
}
