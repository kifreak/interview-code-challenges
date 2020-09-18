using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class Robot: IRobot
    {
        public Position CurrentPosition { get; private set; }
        public ERobotStatus Status { get; private set; }
        public IRobotMovement Movement { get; }
        public IAvoidArea AvoidArea { get; }

        public Robot(Position startPosition, IRobotMovement movement, IAvoidArea avoidArea)
        {
            CurrentPosition = startPosition;
            Status = ERobotStatus.Ok;
            Movement = movement;
            AvoidArea = avoidArea;
        }

        public void TurnLeft()
        {
            CurrentPosition.Orientation = Movement.TurnLeft(CurrentPosition.Orientation);
        }

        public void TurnRight()
        {
            CurrentPosition.Orientation = Movement.TurnRight(CurrentPosition.Orientation);
        }

        public void MoveForward()
        {
            var nextPosition = Movement.MoveForwards(CurrentPosition);
            if (!AvoidArea.IsAvoidArea(nextPosition))
            {
                CurrentPosition = nextPosition;
            }
        }

        public override string ToString()
        {
            return CurrentPosition.ToString();
        }
    }
}