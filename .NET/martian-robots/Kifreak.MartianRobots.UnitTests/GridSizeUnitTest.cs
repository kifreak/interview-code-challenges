using System.Linq;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using Xunit;

namespace Kifreak.MartianRobots.UnitTests
{
    public class GridSizeUnitTest
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(10, 15)]
        [InlineData(50, 2)]
        public void CreateGridSizeOk(int x, int y)
        {
            GridSize gridSize = new GridSize(x,y);
            Assert.Equal(x, gridSize.X);
            Assert.Equal(y, gridSize.Y);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 3)]
        [InlineData(3, -25)]
        [InlineData(52, 13)]
        public void CreateGridSizeKo(int x, int y)
        {
            Assert.Throws<GridSizeException>(() => new GridSize(x, y));
        }

        public class RobotManagerUnitTest
        {
            [Fact]
            public void AddRobotsToManagerOk()
            {
                RobotManager manager = new RobotManager(new AvoidArea(), new GridSize(5, 5));
                RobotMovement robotMovement = new RobotMovement();
                manager.AddRobotEngines(new Robot(new Position(0,0,0)), robotMovement);
                manager.AddRobotEngines(new Robot(new Position(1,1,0)), robotMovement );
                Assert.NotEmpty(manager.RobotEngines);
                Assert.Equal(2, manager.RobotEngines.Count);
                Assert.Equal(0, manager.RobotEngines.First().Robot.CurrentPosition.X);
                Assert.Equal(1, manager.RobotEngines.Last().Robot.CurrentPosition.X);
            }


        }
    }
}