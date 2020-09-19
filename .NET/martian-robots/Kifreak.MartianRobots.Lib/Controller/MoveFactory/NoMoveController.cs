using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class NoMoveController : IMovementController
    {
        public string Name => "Nowhere";
        public Position GetNextPosition(Position position)
        {
            return position;
        }

    }
}