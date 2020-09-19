using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
{
    public class MoveForwardAction : IActionController
    {
        public string Name => "F";
        public void ExecuteAction(IRobot robot)
        {
            robot.MoveForward();
        }

    }
}