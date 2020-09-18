using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveSouthController : IMovementController
    {
        public string Name => "South";

        public Position GetNextPosition(Position position)
        {
            return new Position(position.X, position.Y -1, position.Orientation);
        }
    }
}