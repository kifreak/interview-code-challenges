using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
{
    public class TurnLeftAction : IActionController
    {
        public string Name => "L";
        public void ExecuteAction(IRobot robot, RobotManager robotManager)
        {
            robot.TurnLeft();
        }
    }
}