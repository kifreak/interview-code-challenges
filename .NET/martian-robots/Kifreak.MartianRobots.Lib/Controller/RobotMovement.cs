using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Utils;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotMovement : IRobotMovement
    {
        private readonly IRobotMoveFactory _factory;

        public RobotMovement(RobotMoveFactory factory)
        {
            _factory = factory;
        }

        public int TurnLeft(int currentOrientation)
        {
            return MathUtils.Rotate(-90, currentOrientation);
        }

        public int TurnRight(int currentOrientation)
        {
            return MathUtils.Rotate(90, currentOrientation);
        }

        public Position MoveForwards(Position position)
        {
            IMovementController movement = _factory.CreateInstance(position.Orientation);
            return movement.GetNextPosition(position);
        }

    }
}