using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class AvoidArea: IAvoidArea
    {
        private readonly List<Position> _avoidArea;

        public AvoidArea()
        {
            _avoidArea = new List<Position>();
        }
        public bool IsAvoidArea(Position nextPosition)
        {
            return _avoidArea.Any(position => position.X == nextPosition.X && position.Y == nextPosition.Y);
        }

        public void AddAvoidArea(Position position)
        {
            _avoidArea.Add(position);
        }
    }
}