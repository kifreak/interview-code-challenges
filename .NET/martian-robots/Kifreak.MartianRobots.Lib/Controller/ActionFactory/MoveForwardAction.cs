using System;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
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
                 if (robotManager.IsPositionOffGrid(nextPosition))
                 {
                    throw new PositionException();
                 }
            }
            catch
            {
                OffMap(robot, robotManager);
                return;
            }
            if (robotManager.NotAllowPosition.IsNotAllowPosition(nextPosition)) return;
            robot.MoveTo(nextPosition);
        }

        private void OffMap(IRobot robot, RobotManager robotManager)
        {
            robot.LostRobot();
            robotManager.NotAllowPosition.AddNotAllowedPosition(robot.CurrentPosition);

        }
    }
}