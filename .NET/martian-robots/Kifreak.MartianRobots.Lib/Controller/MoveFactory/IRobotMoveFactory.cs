using Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public interface IRobotMoveFactory
    {
        IMovementController CreateInstance(int orientation);
    }
}