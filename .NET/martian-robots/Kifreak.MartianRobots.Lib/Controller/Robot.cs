using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class Robot: IRobot
    {
        public Position CurrentPosition { get; private set; }
        public ERobotStatus Status { get; private set; }
        public IRobotMovement Movement { get; set; }
        public Instructions Instructions { get; }
        public IAvoidArea AvoidArea { get; }

        public Robot(Position startPosition, 
            IRobotMovement movement, 
            IAvoidArea avoidArea,
            Instructions instructions)
        {
            CurrentPosition = startPosition??throw new RobotBuildException(nameof(Position));
            Status = ERobotStatus.OK;
            Movement = movement??throw new RobotBuildException(nameof(IRobotMovement));
            AvoidArea = avoidArea??throw new RobotBuildException(nameof(IAvoidArea));
            Instructions = instructions??throw new RobotBuildException(nameof(Instructions));
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
            Position nextPosition = null;
            try
            {
                nextPosition = Movement.MoveForwards(CurrentPosition);
            }
            catch (PositionException exception)
            {
                nextPosition = CurrentPosition;
                AvoidArea.AddAvoidArea(nextPosition);
                Status = ERobotStatus.LOST;
            }

            if (!AvoidArea.IsAvoidArea(nextPosition))
            {
                CurrentPosition = nextPosition;
            }
        }

        public override string ToString()
        {
            string lostTest = Status == ERobotStatus.LOST ? $" {Status}" : string.Empty;
            return $"{CurrentPosition}{lostTest}";
        }
    }
}