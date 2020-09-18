using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobotEngine
    {
        IRobot Robot { get; }
        void TurnLeft();
        void TurnRight();
        void MoveForwards();
    }
}