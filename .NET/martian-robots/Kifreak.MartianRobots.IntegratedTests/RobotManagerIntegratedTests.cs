using Kifreak.MartianRobots.IntegratedTests.Implementations;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Kifreak.MartianRobots.IntegratedTests
{
    public class RobotManagerIntegratedTests : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IRobotMovement _robotMovement;
        private readonly IActionFactory _actionFactory;
        private readonly Grid _grid;
        private NotAllowPosition _notAllowPosition;

        public RobotManagerIntegratedTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _robotMovement = new RobotMovement();
            _actionFactory = new ActionFactory();
            _notAllowPosition = new NotAllowPosition();
            _grid = new Grid(5, 5);
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
            _notAllowPosition.AddNotAllowedPosition(new Position(1, 1, 0));
            Instructions robot1Instructions = new Instructions(new[] { "F", "R", "F", "R", "F" });
            IRobot robot1 = new Robot(new Position(0, 0, 0),
                _robotMovement, robot1Instructions);
            Instructions robot2Instructions = new Instructions(new[] { "F", "F", "F", "F" });
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
            Instructions robot2Instructions = new Instructions(new[] { "R", "R", "F", "F", "F" });
            IRobot robot2 = new Robot(new Position(1, 1, 90),
                _robotMovement, robot2Instructions);

            ExecuteRobotManager(robot1, robot2);

            Assert.Equal("0 1 270 LOST", robot1.ToString());
            Assert.Equal("0 1 270", robot2.ToString());
        }

        [Fact]
        public void LostAllRobots()
        {
            Instructions instruction = new Instructions(new[] { "F", "F", "F", "F", "F", "F" });
            IRobot robot1 = new Robot(new Position(0, 0, 0),
                _robotMovement, instruction);
            IRobot robot2 = new Robot(new Position(0, 0, 90),
                _robotMovement, instruction);
            IRobot robot3 = new Robot(new Position(0, 0, 270), _robotMovement, instruction);
            IRobot robot4 = new Robot(new Position(0, 0, 180), _robotMovement, instruction);
            ExecuteRobotManager(robot1, robot2, robot3, robot4);
            Assert.Equal("0 5 0 LOST", robot1.ToString());
            Assert.Equal("5 0 90 LOST", robot2.ToString());
            Assert.Equal("0 0 270 LOST", robot3.ToString());
            Assert.Equal("0 0 180 LOST", robot4.ToString());
        }

        [Fact]
        public void SampleTest()
        {
            var grid = new Grid(5, 3);
            var manager = new RobotManager(grid, new NotAllowPosition(), new ActionFactory());
            var movement = new RobotMovement();
            var robot1 = new Robot(new Position(1, 1, 90), movement, new Instructions("RFRFRFRF".ToCharArray().Select(t => t.ToString()).ToArray()));
            var robot2 = new Robot(new Position(3, 2, 0), movement, new Instructions("FRRFLLFFRRFLL".ToCharArray().Select(t => t.ToString()).ToArray()));
            var robot3 = new Robot(new Position(0, 3, 270), movement, new Instructions("LLFFFLFLFL".ToCharArray().Select(t => t.ToString()).ToArray()));
            manager.AddRobot(new List<IRobot> { robot1, robot2, robot3 });
            manager.ExecuteAllRobots();
            Assert.Equal("1 1 90", robot1.ToString());
            Assert.Equal("3 3 0 LOST", robot2.ToString());
            Assert.Equal("2 3 180", robot3.ToString());
        }

        [Fact]
        public void Move100RobotsInTheBiggestGrid()
        {
            Random rmd = new Random();
            var manager = new RobotManager(
                new Grid(50, 50),
                new NotAllowPosition(),
                new ActionFactory()
            );
            var robots = Enumerable.Range(1, 100)
                .Select(i =>
                    new Robot(
                    RandomPosition(rmd, 50, 50),
                    _robotMovement,
                    RandomInstructions(rmd)
                ));
            manager.AddRobot(robots);
            DateTime start = DateTime.Now;
            manager.ExecuteAllRobots();
            DateTime end = DateTime.Now;
            _testOutputHelper.WriteLine($"{(end - start).TotalMilliseconds:N0} milliseconds to execute");
        }

        private Position RandomPosition(Random rmd, int maxX, int maxY)
        {
            Dictionary<int, int> orientationDictionary = new Dictionary<int, int>
            {
                {0,0},
                {1,90},
                {2,180},
                {3,270}
            };
            int x = rmd.Next(0, maxX);
            int y = rmd.Next(0, maxY);
            int orientation = rmd.Next(0, 3);

            return new Position(x, y, orientationDictionary[orientation]);
        }

        private Instructions RandomInstructions(Random rmd)
        {
            Dictionary<int, string> instructionDictionary = new Dictionary<int, string>
            {
                {0,"F"},
                {1,"R"},
                {2,"L"}
            };
            List<string> actions = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                int action = rmd.Next(0, 3);
                actions.Add(instructionDictionary[action]);
            }
            return new Instructions(actions.ToArray());
        }

        [Fact]
        public void MoveRobot45DegreesIn90DegreesStructure()
        {
            IRobot robot1 = new Robot(new Position(0, 0, 0),
                new FortyFiveDegreesMovement(),
                new Instructions(new[] { "F", "R", "F", "R", "F", "R" }));
            IRobot robot2 = new Robot(new Position(0, 0, 0),
                new FortyFiveDegreesMovement(),
                new Instructions(new[] { "F", "R", "F", "R", "F", "R", "R", "F" }));
            ExecuteRobotManager(robot1, robot2);
            Assert.Equal("1 1 135", robot1.ToString());
            Assert.Equal("1 0 180", robot2.ToString());
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