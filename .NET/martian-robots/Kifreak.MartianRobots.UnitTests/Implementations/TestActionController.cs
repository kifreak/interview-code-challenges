using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.UnitTests.Implementations
{
    public class TestActionController : IActionController
    {
        public string Name => "Test";
        public void ExecuteAction(IRobot robot, RobotManager robotManager)
        {   
        }
    }
}