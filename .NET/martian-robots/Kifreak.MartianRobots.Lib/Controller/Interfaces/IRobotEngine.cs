using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobotEngine
    {
        IRobot Robot { get; }
        IRobotMovement Movement { get; }
        IAvoidArea AvoidArea { get; }
        void TurnLeft();

        void TurnRight();
        void MoveForward();
    }
}