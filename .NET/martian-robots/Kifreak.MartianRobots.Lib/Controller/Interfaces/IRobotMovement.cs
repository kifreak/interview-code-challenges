using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IRobotMovement
    {
        int TurnLeft(int currentOrientation);

        int TurnRight(int currentOrientation);

        Position MoveForwards(Position position);
    }
}