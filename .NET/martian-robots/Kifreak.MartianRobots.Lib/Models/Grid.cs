﻿using Kifreak.MartianRobots.Lib.Exceptions;

namespace Kifreak.MartianRobots.Lib.Models
{
    public class Grid
    {
        private int _x;
        private int _y;

        public Grid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {
            get => _x;
            private set => _x = value <= 50 && value > 0 ? value : throw new GridSizeException();
        }

        public int Y {
            get => _y;
            private set => _y = value <= 50 && value > 0 ? value : throw new GridSizeException();
        }
    }
}