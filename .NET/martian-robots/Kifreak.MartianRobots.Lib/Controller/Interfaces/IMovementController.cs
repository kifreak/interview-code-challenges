using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IMovementController
    {
        string Name { get; }
        void Move(IRobot robot);
    }
}