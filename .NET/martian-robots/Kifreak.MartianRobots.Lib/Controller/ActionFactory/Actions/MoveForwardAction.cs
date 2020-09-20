using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions
{
    public class MoveForwardAction : IActionController
    {
        public string Name => "F";

        public void ExecuteAction(IRobot robot, RobotManager robotManager)
        {
            Position nextPosition;
            try
            {
                nextPosition = robot.GetNextPosition();
            }
            catch
            {
                return;
            }

            if (robotManager.NotAllowPosition.IsNotAllowPosition(nextPosition)) return;
            if (robotManager.IsPositionOffGrid(nextPosition))
            {
                OffMap(robot, robotManager, nextPosition);
                return;
            }
            robot.MoveTo(nextPosition);
        }

        private void OffMap(IRobot robot, RobotManager robotManager, Position nextPosition)
        {
            robot.LostRobot();
            robotManager.NotAllowPosition.AddNotAllowedPosition(nextPosition);
        }
    }
}