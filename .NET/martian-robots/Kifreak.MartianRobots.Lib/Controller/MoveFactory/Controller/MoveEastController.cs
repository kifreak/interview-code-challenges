using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public class MoveEastController : IMovementController
    {
        public string Name => "East";
        public int Orientation => 90;

        public Position GetNextPosition(Position position)
        {
            return new Position(position.X + 1, position.Y, position.Orientation);
        }
    }
}