using Kifreak.MartianRobots.Lib.Controller.ActionFactory;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    [Collection("UnitTest")]
    public class FactoriesUnitTests
    {
        [Fact]
        public void RobotMoveFactoryTest()
        {
            IRobotMoveFactory factory = new RobotMoveFactory();
            IMovementController instanceNorth = factory.CreateInstance(0);
            IMovementController instanceSouth = factory.CreateInstance(180);
            IMovementController instanceEast = factory.CreateInstance(90);
            IMovementController instanceWest = factory.CreateInstance(270);
            IMovementController instanceNull = factory.CreateInstance(75);
            Assert.Equal("North", instanceNorth.Name);
            Assert.Equal("South", instanceSouth.Name);
            Assert.Equal("East", instanceEast.Name);
            Assert.Equal("West", instanceWest.Name);
            Assert.Equal("Nowhere", instanceNull.Name);
        }

        [Fact]
        public void ActionFactoryTest()
        {
            IActionFactory action = new ActionFactory();
            IActionController leftAction = action.CreateInstance("L");
            IActionController rightAction = action.CreateInstance("R");
            IActionController forwardAction = action.CreateInstance("F");
            IActionController nullAction = action.CreateInstance("NoExist");
            IActionController newAction = action.CreateInstance("Test");
            Assert.Equal("L", leftAction.Name);
            Assert.Equal("R", rightAction.Name);
            Assert.Equal("F", forwardAction.Name);
            Assert.Equal("NoAction", nullAction.Name);
            Assert.Equal("Test", newAction.Name);
        }
    }
}