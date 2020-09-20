using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public class NoMoveController : IMovementController
    {
        public string Name => "Nowhere";
        public int Orientation => -1;

        public Position GetNextPosition(Position position)
        {
            return position;
        }
    }
}