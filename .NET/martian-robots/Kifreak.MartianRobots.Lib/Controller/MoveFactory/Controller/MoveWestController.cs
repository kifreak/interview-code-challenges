﻿using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller
{
    public class MoveWestController : IMovementController
    {
        public string Name => "West";
        public int Orientation => 270;

        public Position GetNextPosition(Position position)
        {
            return new Position(position.X - 1, position.Y, position.Orientation);
        }
    }
}