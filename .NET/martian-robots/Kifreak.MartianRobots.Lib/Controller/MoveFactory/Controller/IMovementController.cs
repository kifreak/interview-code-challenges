using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public interface IMovementController
    {
        string Name { get; }

        int Orientation { get; }

        Position GetNextPosition(Position position);
    }
}