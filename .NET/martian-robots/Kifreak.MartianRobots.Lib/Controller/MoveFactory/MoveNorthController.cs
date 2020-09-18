using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveNorthController : IMovementController
    {
        public string Name => "North";

        public void Move(IRobot robot)
        {
            robot.CurrentPosition.Y++;
        }
    }
}