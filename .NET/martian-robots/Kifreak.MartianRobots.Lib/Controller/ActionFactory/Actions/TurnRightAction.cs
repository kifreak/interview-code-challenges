using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions
{
    public class TurnRightAction : IActionController
    {
        public string Name => "R";

        public void ExecuteAction(IRobot robot, RobotManager robotManager)
        {
            robot.TurnRight();
        }
    }
}