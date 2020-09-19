using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; }
        ERobotStatus Status { get; }
        IRobotMovement Movement { get; set; }
        Instructions Instructions { get; }
        IAvoidArea AvoidArea { get; }

        void TurnLeft();
        void TurnRight();
        void MoveForward();


    }
}