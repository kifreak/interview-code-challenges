using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotEngine: IRobotEngine
    {
        public RobotEngine(IRobot robot)
        {
            Robot = robot;
        }
        public IRobot Robot { get; }

        public void TurnLeft()
        {
            MoveOrientation(-90);
        }

        public void TurnRight()
        {
            MoveOrientation(90);
        }

        public void MoveForwards()
        {
            RobotMoveFactory factory = new RobotMoveFactory();
            IMovementController movement = factory.CreateInstance(Robot.CurrentPosition.Orientation);
            movement.Move(Robot);
        }
        
        private void MoveOrientation(int degrees)
        {
            int currentPosition = Robot.CurrentPosition.Orientation + degrees;
            currentPosition = currentPosition < 0 ? 
                270 : currentPosition > 270 ? 
                    0 : currentPosition;
            Robot.CurrentPosition.Orientation = currentPosition;
        }
    }
}