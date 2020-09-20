using Kifreak.MartianRobots.Console.Expressions.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;
using System.Linq;

namespace Kifreak.MartianRobots.Console.Expressions.Parsers
{
    public class GridParser : IDataParser
    {
        public object Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new GridSizeException();
            }

            string[] grids = text.Split(' ');
            if (grids.Length != 2)
            {
                throw new GridSizeException();
            }
            int.TryParse(grids.FirstOrDefault(), out int x);
            int.TryParse(grids.LastOrDefault(), out int y);
            return new Grid(x, y);
        }
    }
}