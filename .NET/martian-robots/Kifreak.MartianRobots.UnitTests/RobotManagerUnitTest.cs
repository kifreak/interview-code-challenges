using System.Linq;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Moq;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotManagerUnitTest
    {
        private readonly Mock<IActionFactory> _actionFactoryMock;
        private readonly Mock<IRobotMovement> _robotMovement;
        private readonly RobotManager _manager;
        private readonly Mock<IActionController> _actionControllerMock;
        private readonly Grid _grid;
        public RobotManagerUnitTest()
        {
            var notAllowMock = new Mock<INotAllowPosition>();
            _actionFactoryMock = new Mock<IActionFactory>();
            _robotMovement = new Mock<IRobotMovement>();
            _grid = new Grid(5, 5, notAllowMock.Object);
            _manager = new RobotManager(_grid, _actionFactoryMock.Object);
            _actionControllerMock = new Mock<IActionController>();
            _actionFactoryMock.Setup(t => t.CreateInstance(It.IsAny<string>())).Returns(_actionControllerMock.Object);
        }
         
        

        [Fact]
        public void AddRobotsToManagerOk()
        {
            _manager.AddRobot(CreateRobot(new Position(0, 0, 0)));
            _manager.AddRobot(CreateRobot(new Position(1, 1, 0)));
            Assert.NotEmpty(_manager.Robots);
            Assert.Equal(2, _manager.Robots.Count);
            Assert.Equal(0, _manager.Robots.First().CurrentPosition.X);
            Assert.Equal(1, _manager.Robots.Last().CurrentPosition.X);
        }

        [Fact]
        public void ExecuteRobotWithOkStatus()
        {
            IRobot robot = CreateRobot(new Position(1, 1, 0));
            _manager.ExecuteRobot(robot);
            _actionFactoryMock.Verify(factory => factory.CreateInstance("F"), Times.Exactly(robot.Instructions.Actions.Count(action => action == "F")));
            _actionFactoryMock.Verify(factory => factory.CreateInstance("L"), Times.Exactly(robot.Instructions.Actions.Count(action => action == "L")));
            _actionFactoryMock.Verify(factory => factory.CreateInstance("R"), Times.Exactly(robot.Instructions.Actions.Count(action => action=="R")));
            _actionFactoryMock.Verify(factory => factory.CreateInstance(It.IsAny<string>()), Times.Exactly(robot.Instructions.Actions.Length));
            _actionControllerMock.Verify(action => action.ExecuteAction(It.IsAny<IRobot>()), Times.Exactly(robot.Instructions.Actions.Length));
            Assert.Equal(ERobotStatus.Ok, robot.Status);
        }

        [Fact]
        public void ExecuteRobotWithLostStatus()
        {
            _robotMovement.Setup(t => t.MoveForwards(It.IsAny<Position>())).Throws<PositionException>();
            IRobot robot = CreateRobot(new Position(1, 1, 0));
            _actionControllerMock.Setup(action => action.ExecuteAction(It.IsAny<IRobot>()))
                .Callback(() => robot.MoveForward());
            _manager.ExecuteRobot(robot);
            Assert.Equal(ERobotStatus.Lost, robot.Status);
            _actionFactoryMock.Verify(factory => factory.CreateInstance(It.IsAny<string>()), Times.Once);
            _actionControllerMock.Verify(action => action.ExecuteAction(It.IsAny<IRobot>()), Times.Once);

        }

        private IRobot CreateRobot(Position position)
        {
            return new Robot(
                position, _robotMovement.Object, _grid, new Instructions(new[] { "F", "L", "F","R", "F" }));
        }
    }
}