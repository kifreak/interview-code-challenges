using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class MoveEastController : IMovementController
    {
        public string Name => "East";

        public void Move(IRobot robot)
        {
            robot.CurrentPosition.X++;
        }
    }
}