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
        public Grid Grid { get; }

        public Robot(Position startPosition, 
            IRobotMovement movement, 
            Grid grid,
            Instructions instructions)
        {
            CurrentPosition = startPosition??throw new RobotBuildException(nameof(Position));
            Status = ERobotStatus.Ok;
            Movement = movement??throw new RobotBuildException(nameof(IRobotMovement));
            Grid = grid ?? throw new RobotBuildException(nameof(Grid));
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
            Position nextPosition;
            try
            {
                nextPosition = Movement.MoveForwards(CurrentPosition);
                if (IsRobotOutSideGrid(nextPosition))
                {
                    throw new PositionException();
                }

            }
            catch 
            {
                nextPosition = CurrentPosition;
                Grid.NotAllow.AddNotAllowedPosition(CurrentPosition);
                Status = ERobotStatus.Lost;
            }

            if (!Grid.NotAllow.IsNotAllowPosition(nextPosition))
            {
                CurrentPosition = nextPosition;
            }
        }

        private bool IsRobotOutSideGrid(Position nextPosition)
        {
            return nextPosition.X >= Grid.X || nextPosition.Y >= Grid.Y;
        }
        public override string ToString()
        {
            string lostTest = Status == ERobotStatus.Lost ? $" {Status.ToString().ToUpper()}" : string.Empty;
            return $"{CurrentPosition}{lostTest}";
        }
    }
}