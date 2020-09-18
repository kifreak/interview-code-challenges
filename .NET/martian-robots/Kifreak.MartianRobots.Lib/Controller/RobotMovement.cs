using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotMovement : IRobotMovement
    {
        public int TurnLeft(int currentOrientation)
        {
            return GetNextOrientation(-90, currentOrientation);
        }

        public int TurnRight(int currentOrientation)
        {
            return GetNextOrientation(90, currentOrientation);
        }

        public Position MoveForwards(Position position)
        {
            RobotMoveFactory factory = new RobotMoveFactory();
            IMovementController movement = factory.CreateInstance(position.Orientation);
            return movement.GetNextPosition(position);
        }

        private int GetNextOrientation(int degrees, int currentOrientation)
        {

            int nextOrientation = currentOrientation + degrees;
            nextOrientation = nextOrientation < 0 ? 270 : nextOrientation > 270 ? 0 : nextOrientation;
            return nextOrientation;
        }
    }
}