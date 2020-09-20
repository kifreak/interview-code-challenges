using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IMovementController
    {
        string Name { get; }

        Position GetNextPosition(Position position);
    }
}