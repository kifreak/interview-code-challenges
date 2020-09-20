using Kifreak.MartianRobots.Console.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

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
            ICommandFactory commandFactory = FindRequestCommand(args.Length > 0 ? args[0] : string.Empty);
            return commandFactory == null ? new NotFoundCommand() : commandFactory.MakeCommand(args);
        }

        private ICommandFactory FindRequestCommand(string commandName)
        {
            return _availableCommands.FirstOrDefault(t => string.Equals(t.CommandName, commandName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}