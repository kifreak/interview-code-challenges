using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveWestController : IMovementController
    {
        public string Name => "West";
        public Position GetNextPosition(Position position)
        {
            return new Position(position.X-1, position.Y, position.Orientation);
        }
    }
}