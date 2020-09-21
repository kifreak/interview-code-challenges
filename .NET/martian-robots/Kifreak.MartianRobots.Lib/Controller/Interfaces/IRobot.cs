using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; }

        ERobotStatus Status { get; }
        
        Instructions Instructions { get; }

        void TurnLeft();

        void TurnRight();

        Position GetNextPosition();

        void MoveTo(Position position);

        void LostRobot();

        void SetRobotMovement(IRobotMovement movement);

        string ToString(string position);
    }
}