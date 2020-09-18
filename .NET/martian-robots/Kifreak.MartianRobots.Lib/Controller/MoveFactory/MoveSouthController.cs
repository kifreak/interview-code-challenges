using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveSouthController : IMovementController
    {
        public string Name => "South";

        public void Move(IRobot robot)
        {
            robot.CurrentPosition.Y--;
        }
    }
}