using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotEngine: IRobotEngine
    {
        public IRobot Robot { get; }

                public IRobotMovement Movement { get; }
        public IAvoidArea AvoidArea { get; }

        public RobotEngine(IRobot robot, IRobotMovement movement, IAvoidArea avoidArea)
        {
            Robot = robot;
            Movement = movement;
            AvoidArea = avoidArea;
        }

        public void TurnLeft()
        {
            Robot.CurrentPosition.Orientation = Movement.TurnLeft(Robot.CurrentPosition.Orientation);
        }

        public void TurnRight()
        {
            Robot.CurrentPosition.Orientation = Movement.TurnRight(Robot.CurrentPosition.Orientation);
        }

        public void MoveForward()
        {
            var nextPosition = Movement.MoveForwards(Robot.CurrentPosition);
            if (!AvoidArea.IsAvoidArea(nextPosition))
            {
                Robot.CurrentPosition = nextPosition;
            }
        }
    }
}