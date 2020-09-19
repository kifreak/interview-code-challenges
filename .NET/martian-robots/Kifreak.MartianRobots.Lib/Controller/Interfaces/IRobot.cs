using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; }
        ERobotStatus Status { get; }
        IRobotMovement Movement { get; set; }
        Instructions Instructions { get; }
        Grid Grid { get; }

        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}