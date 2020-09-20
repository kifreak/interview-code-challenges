using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public class MoveSouthController : IMovementController
    {
        public string Name => "South";
        public int Orientation => 180;

        public Position GetNextPosition(Position position)
        {
            return new Position(position.X, position.Y - 1, position.Orientation);
        }
    }
}