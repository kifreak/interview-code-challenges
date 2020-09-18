namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobotMoveFactory
    {
        IMovementController CreateInstance(int orientation);
    }
}