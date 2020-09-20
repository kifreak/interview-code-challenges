using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
{
    public class NullAction: IActionController
    {
        public string Name => "NoAction";
        public void ExecuteAction(IRobot robot, RobotManager robotManager)
        {
        }
        
    }
}