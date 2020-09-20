using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class Robot : IRobot
    {
        public Position CurrentPosition { get; private set; }
        public ERobotStatus Status { get; private set; }
        public IRobotMovement Movement { get; set; }
        public Instructions Instructions { get; }

        public Robot(Position startPosition,
            IRobotMovement movement,
            Instructions instructions)
        {
            CurrentPosition = startPosition ?? throw new RobotBuildException(nameof(Position));
            Status = ERobotStatus.Ok;
            Movement = movement ?? throw new RobotBuildException(nameof(IRobotMovement));
            Instructions = instructions ?? throw new RobotBuildException(nameof(Instructions));
        }

        public void TurnLeft()
        {
            CurrentPosition.Orientation = Movement.TurnLeft(CurrentPosition.Orientation);
        }

        public void TurnRight()
        {
            CurrentPosition.Orientation = Movement.TurnRight(CurrentPosition.Orientation);
        }

        public Position GetNextPosition()
        {
            return Movement.MoveForwards(CurrentPosition);
        }

        public void LostRobot()
        {
            Status = ERobotStatus.Lost;
        }

        public void MoveTo(Position nextPosition)
        {
            CurrentPosition = nextPosition;
        }

        public override string ToString()
        {
            return ToString(CurrentPosition.ToString());
        }

        public string ToString(string position)
        {
            string lostTest = Status == ERobotStatus.Lost ? $" {Status.ToString().ToUpper()}" : string.Empty;
            return $"{position}{lostTest}";
        }
    }
}