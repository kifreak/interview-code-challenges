using Kifreak.MartianRobots.Lib.Exceptions;

namespace Kifreak.MartianRobots.Lib.Models
{
    public class Position
    {
        private int _x;
        private int _y;
        private int _orientation;

        public Position(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
      
        public int X 
        {
            get => _x;
            set => _x = IsValidCoordinate(value) ? value : throw new PositionException("x");
        }
        public int Y {
            get => _y;
            set => _y = IsValidCoordinate(value) ? value : throw new PositionException("y");
        }
        public int Orientation
        {
            get => _orientation;
            set => _orientation = IsValidOrientation(value) ? value : throw new PositionException("Orientation");
        }
        
        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }
        private bool IsValidCoordinate(int coordinate)
        {
            return coordinate >= 0 && coordinate <= 50;
        }

        private bool IsValidOrientation(int orientation)
        {
            return orientation >= 0 && orientation < 360;
        }

    }
}