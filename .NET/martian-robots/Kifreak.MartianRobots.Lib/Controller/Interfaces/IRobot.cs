using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; }
        ERobotStatus Status { get; }
        IRobotMovement Movement { get; }
        IAvoidArea AvoidArea { get; }
        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}