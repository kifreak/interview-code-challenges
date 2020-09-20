using System;
using Kifreak.MartianRobots.Console.Expressions.Interfaces;
using Kifreak.MartianRobots.Console.ViewModel;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Console.Expressions.Parsers
{
    public class PositionParser : IDataParser
    {
        public object Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new PositionException();
            }

            string[] positions = text.Split(' ');
            if (positions.Length != 3)
            {
                throw new PositionException();
            }
            bool isX = int.TryParse(positions[0], out int x);
            bool isY = int.TryParse(positions[1], out int y);
            bool isZ = Enum.TryParse(positions[2], out EOrientation orientation);
            if (!isX || !isY || !isZ)
            {
                throw new PositionException();
            }
            return new Position(x, y, (int)orientation);
        }
    }
}