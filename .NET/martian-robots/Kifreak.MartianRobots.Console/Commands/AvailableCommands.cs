using Kifreak.MartianRobots.Console.CommandFactory;
using System.Collections.Generic;

namespace Kifreak.MartianRobots.Console.Commands
{
    public static class AvailableCommands
    {
        public static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new HelpCommand(),
                new ManualRobotControllerCommand()
            };
        }
    }
}