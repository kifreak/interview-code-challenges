using System.Linq;
using Kifreak.MartianRobots.Console.Expressions.Interfaces;
using Kifreak.MartianRobots.Lib.Exceptions;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Console.Expressions.Parsers
{
    public class InstructionParser : IDataParser
    {
        public object Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new InstructionException();
            }
            return new Instructions(text.ToCharArray().Select(c => c.ToString()).ToArray());
        }
    }
}