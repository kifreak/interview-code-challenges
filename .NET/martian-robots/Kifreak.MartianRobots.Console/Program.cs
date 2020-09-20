using Kifreak.MartianRobots.Console.CommandFactory;
using Kifreak.MartianRobots.Console.Commands;
using Kifreak.MartianRobots.Console.Helpers;
using System.Threading.Tasks;

namespace Kifreak.MartianRobots.Console
{
    internal class Program
    {
        private static async Task Main(string[] args)
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