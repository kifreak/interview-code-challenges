using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class RobotMoveFactoryUnitTests
    {
        [Fact]
        public void MoveOk()
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
    }
}