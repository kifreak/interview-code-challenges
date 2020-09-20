using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public class MoveNorthController : IMovementController
    {
        public string Name => "North";
        public int Orientation => 0;

        public Position GetNextPosition(Position position)
        {
            return new Position(position.X, position.Y + 1, position.Orientation);
        }
    }
}