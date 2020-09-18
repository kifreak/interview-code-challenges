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

        public List<RobotEngine> RobotEngines;
        public RobotManager(IAvoidArea avoidArea, GridSize grid)
        {
            AvoidArea = avoidArea;
            Grid = grid;
            RobotEngines = new List<RobotEngine>();
        }

        public void AddRobotEngines(IRobot robot,IRobotMovement movement )
        {
            RobotEngines.Add(new RobotEngine(
                robot,movement, AvoidArea
            ));
        }
        
    }
}