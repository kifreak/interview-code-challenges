using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class RobotManager
    {
        public IAvoidArea AvoidArea { get; }

        public GridSize Grid { get; }

        public List<IRobot> RobotEngines;
        public RobotManager(IAvoidArea avoidArea, GridSize grid)
        {
            AvoidArea = avoidArea;
            Grid = grid;
            RobotEngines = new List<IRobot>();
        }

        public void AddRobotEngines(IRobot robot)
        {
            RobotEngines.Add(robot);
        }
        
    }
}