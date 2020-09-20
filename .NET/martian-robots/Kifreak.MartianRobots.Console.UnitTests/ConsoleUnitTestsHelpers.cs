using Kifreak.MartianRobots.Console.Expressions.Interfaces;

namespace Kifreak.MartianRobots.Console.UnitTests
{
    public static class ConsoleUnitTestsHelpers {
        public static TReturn DataParser<TParser,TReturn>(string line) where TParser : IDataParser, new() where TReturn : class
        {
            IDataParser dataParser = new TParser();
            return dataParser.Parse(line) as TReturn; 
        }
    }
}