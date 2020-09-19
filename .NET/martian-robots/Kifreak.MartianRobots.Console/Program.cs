using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kifreak.MartianRobots.Console.CommandFactory;
using Kifreak.MartianRobots.Console.Commands;
using Kifreak.MartianRobots.Console.Helpers;

namespace Kifreak.MartianRobots.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleHelper.NormalLine("Welcome to Martian Robots controller");
            CommandParser parser = new CommandParser(AvailableCommands.GetAvailableCommands());
            ICommand command = parser.ParseCommand(args);
            if (!command.Validate())
            {
                ConsoleHelper.Error("Command not valid. Please check help page");
            }
            await command.Execute();
        }

   
    }
}
