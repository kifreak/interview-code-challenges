﻿using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using Kifreak.MartianRobots.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kifreak.MartianRobots.Lib.Controller
{
    public class NotAllowPosition : INotAllowPosition
    {
        private readonly List<Position> _notAllow;

        public NotAllowPosition()
        {
            _notAllow = new List<Position>();
        }

        public bool IsNotAllowPosition(Position nextPosition)
        {
            return _notAllow.Any(position =>
                position.X == nextPosition.X && position.Y == nextPosition.Y);
        }

        public void AddNotAllowedPosition(Position position)
        {
            _notAllow.Add(position);
        }
    }
}