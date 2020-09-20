using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions
{
    public interface IActionController
    {
        string Name { get; }

        void ExecuteAction(IRobot robot, RobotManager robotManager);
    }
}