using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class Robot: IRobot
    {
        public Position CurrentPosition { get; private set; }
        public ERobotStatus Status { get; }
        public IRobotMovement Movement { get; set; }
        public Instructions Instructions { get; }
        public IAvoidArea AvoidArea { get; }

        public Robot(Position startPosition, 
            IRobotMovement movement, 
            IAvoidArea avoidArea,
            Instructions instructions)
        {
            CurrentPosition = startPosition;
            Status = ERobotStatus.Ok;
            Movement = movement;
            AvoidArea = avoidArea;
            Instructions = instructions;
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