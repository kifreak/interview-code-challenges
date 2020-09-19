using System.Collections.Generic;
using Kifreak.MartianRobots.Console.CommandFactory;

namespace Kifreak.MartianRobots.Console.Commands
{
    public static class AvailableCommands
    {
        public static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new HelpCommand()
            };
        }
    }
}