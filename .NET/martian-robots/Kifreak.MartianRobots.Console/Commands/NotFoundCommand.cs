using Kifreak.MartianRobots.Console.CommandFactory;
using Kifreak.MartianRobots.Console.Helpers;
using System.Threading.Tasks;

namespace Kifreak.MartianRobots.Console.Commands
{
    public class NotFoundCommand : ICommand
    {
        public string CommandExecuted { get; set; }

        public Task Execute()
        {
            ConsoleHelper.Error($"Unknown option: {CommandExecuted}");
            ConsoleHelper.NormalLine("Usage: dotnet Kifreak.MartianRobots.Console.dll [commands]");
            ConsoleHelper.NormalLine("Help for more information");
            return Task.CompletedTask;
        }

        public bool Validate()
        {
            return true;
        }
    }
}