using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotManager
    {
        private readonly IActionFactory _actionFactory;
        
        public Grid Grid { get; }

        public List<IRobot> Robots;
        
        public RobotManager(Grid grid,IActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
            Grid = grid;
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
                actionController.ExecuteAction(robot);
            }
        }
        
    }
}