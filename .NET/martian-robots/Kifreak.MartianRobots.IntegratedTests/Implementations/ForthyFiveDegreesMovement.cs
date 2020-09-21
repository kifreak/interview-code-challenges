using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Utils;

namespace Kifreak.MartianRobots.IntegratedTests.Implementations
{
    public class FortyFiveDegreesMovement : IRobotMovement
    {
        public int TurnLeft(int currentOrientation)
        {
            return MathUtils.Rotate(-45, currentOrientation);
        }

        public int TurnRight(int currentOrientation)
        {
            return MathUtils.Rotate(45, currentOrientation);
        }

        public Position MoveForwards(Position position)
        {
            RobotMoveFactory factory = new RobotMoveFactory();
            IMovementController movement = factory.CreateInstance(position.Orientation);
            return movement.GetNextPosition(position);
        }

    }
}