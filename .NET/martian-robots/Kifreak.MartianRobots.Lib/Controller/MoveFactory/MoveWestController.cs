using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveWestController : IMovementController
    {
        public string Name => "West";

        public void Move(IRobot robot)
        {
            robot.CurrentPosition.X--;
        }
    }
}