using System;
using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Console.Commands;

namespace Kifreak.MartianRobots.Console.CommandFactory
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> _availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            _availableCommands = availableCommands;
        }

        internal ICommand ParseCommand(string[] args)
        {
            ICommandFactory commandFactory = FindRequestCommand(args.Length > 0?args[0]:string.Empty);
            if (commandFactory == null)
            {
                return new NotFoundCommand();
            }
            
            return commandFactory.MakeCommand(args);
        }

        private ICommandFactory FindRequestCommand(string commandName)
        {
            return _availableCommands.FirstOrDefault(t => string.Equals(t.CommandName, commandName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}