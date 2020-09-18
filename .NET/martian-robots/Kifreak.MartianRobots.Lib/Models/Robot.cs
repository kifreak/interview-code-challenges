﻿using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Models
{
    public class Robot: IRobot
    {
        public Robot(Position position)
        {
            CurrentPosition = position;
            Status = ERobotStatus.Ok;
        }

        public Position CurrentPosition { get; set; }
        public ERobotStatus Status { get; set; }

        public override string ToString()
        {
            return CurrentPosition.ToString();
        }
    }
}