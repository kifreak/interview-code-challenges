using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; }
        ERobotStatus Status { get; }
        IRobotMovement Movement { get; set; }
        Instructions Instructions { get; }
        void TurnLeft();
        void TurnRight();
        Position GetNextPosition();
        void MoveTo(Position position);
        void LostRobot();
        string ToString(string position);
        
    }
}