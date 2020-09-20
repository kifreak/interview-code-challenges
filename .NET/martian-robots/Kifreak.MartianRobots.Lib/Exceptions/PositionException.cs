using System;

namespace Kifreak.MartianRobots.Lib.Exceptions
{
    public class PositionException : Exception
    {
        public PositionException(string position) :
            base($"The {position} position is not valid.")
        {
        }

        public PositionException() : base("Position not valid.")
        {
        }
    }
}