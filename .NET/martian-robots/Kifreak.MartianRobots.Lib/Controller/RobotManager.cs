using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using System.Collections.Generic;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotManager
    {
        private readonly IActionFactory _actionFactory;

        public Grid Grid { get; }

        public List<IRobot> Robots { get; }
        public INotAllowPosition NotAllowPosition { get; }

        public RobotManager(Grid grid, INotAllowPosition notAllowPosition, IActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
            Grid = grid;
            NotAllowPosition = notAllowPosition;
            Robots = new List<IRobot>();
        }

        public void AddRobot(IRobot robot)
        {
            Robots.Add(robot);
        }

        public void AddRobot(IEnumerable<IRobot> robots)
        {
            Robots.AddRange(robots);
        }

        public void ExecuteAllRobots()
        {
            Robots.ForEach(ExecuteRobot);
        }

        public void ExecuteRobot(IRobot robot)
        {
            if (robot.Instructions?.Actions == null)
            {
                return;
            }
            foreach (string action in robot.Instructions.Actions)
            {
                if (robot.Status == ERobotStatus.Lost)
                {
                    break;
                }
                IActionController actionController = _actionFactory.CreateInstance(action);
                actionController.ExecuteAction(robot, this);
            }
        }

        public bool IsPositionOffGrid(Position position)
        {
            return position.X > Grid.X || position.X < 0 || position.Y < 0 || position.Y > Grid.Y;
        }
    }
}