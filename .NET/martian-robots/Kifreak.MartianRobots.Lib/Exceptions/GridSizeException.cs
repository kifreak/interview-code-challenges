using System;

namespace Kifreak.MartianRobots.Lib.Exceptions
{
    public class GridSizeException : Exception
    {
        public GridSizeException() : base("The grid size is not valid.")
        {
        }
    }
}