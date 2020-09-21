using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class Robot : IRobot
    {
        public Position CurrentPosition { get; private set; }
        public ERobotStatus Status { get; private set; }
        public Instructions Instructions { get; }

        private IRobotMovement _movement;

        public Robot(Position startPosition,
            IRobotMovement movement,
            Instructions instructions)
        {
            CurrentPosition = startPosition ?? throw new RobotBuildException(nameof(Position));
            Status = ERobotStatus.Ok;
            SetRobotMovement(movement);
            Instructions = instructions ?? throw new RobotBuildException(nameof(Instructions));
        }

        public void TurnLeft()
        {
            CurrentPosition.Orientation =
                _movement.TurnLeft(CurrentPosition.Orientation);
        }

        public void TurnRight()
        {
            CurrentPosition.Orientation = _movement.TurnRight(CurrentPosition.Orientation);
        }

        public Position GetNextPosition()
        {
            return _movement.MoveForwards(CurrentPosition);
        }

        public void LostRobot()
        {
            Status = ERobotStatus.Lost;
        }

        public void SetRobotMovement(IRobotMovement movement)
        {
            _movement = movement ?? throw new RobotBuildException(nameof(IRobotMovement));
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