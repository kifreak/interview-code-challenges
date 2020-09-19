using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kifreak.MartianRobots.Console.CommandFactory;
using Kifreak.MartianRobots.Console.Helpers;

namespace Kifreak.MartianRobots.Console.Commands
{
    public class HelpCommand : ICommand, ICommandFactory
    {
        #region ICommand
        public string Topic { get; set; }
        private IEnumerable<ICommandFactory> _availableCommands;
        public Task Execute()
        {
            _availableCommands = AvailableCommands.GetAvailableCommands();
            if (string.IsNullOrEmpty(Topic))
            {
                ShowBasicHelp();
            }
            else
            {
                ShowSpecificHelp();
            }

            return Task.CompletedTask;
        }

        public bool Validate()
        {
            return true;
        }

        public void ShowBasicHelp()
        {
            ConsoleHelper.JumpLine(1);
            ConsoleHelper.NormalLine("Controler for robots in a flat Mars");
            ConsoleHelper.NormalLine( "Get more information about the command typing:");
            ConsoleHelper.InfoLine("help actionName");
            ConsoleHelper.JumpLine(1);
            
            foreach (var availableCommand in _availableCommands)
            {
                ConsoleHelper.LineSeparator();
                ConsoleHelper.Info($"{availableCommand.CommandName}: ");
                ConsoleHelper.NormalLine(availableCommand.Description);
            }
            ConsoleHelper.LineSeparator();
        }
        public void ShowSpecificHelp()
        {
            ICommandFactory command = _availableCommands.FirstOrDefault(
                t => t.CommandName.Equals(Topic, StringComparison.CurrentCultureIgnoreCase));
            if (command == null)
            {
                ConsoleHelper.Error("The introduced command doesn't exist.");
                return;
            }
            ConsoleHelper.LineSeparator();
            ConsoleHelper.Info($"{command.CommandName}: ");
            ConsoleHelper.NormalLine(command.Description);
            if (command.OptionsDescription == null || command.OptionsDescription.Count == 0)
            {
                ConsoleHelper.NormalLine("This command doesn't have parameters");
            }
            else
            {
                foreach (var option in command.OptionsDescription)
                {
                    ConsoleHelper.Blue($"   - {option.Key}: ");
                    ConsoleHelper.NormalLine($"{option.Value}");
                }
            }
        }
        #endregion


        #region ICommandFactory

        public string CommandName => "Help";
        public string Description => "Show this help page";
        public Dictionary<string, string> OptionsDescription => 
            new Dictionary<string, string>
            {
                {"Command", "Get more info about this command."}
            };
        public ICommand MakeCommand(string[] arguments)
        {
            return new HelpCommand
            {
                Topic = arguments.Length > 1 ? arguments[1] : string.Empty
            };
        }
        #endregion
    }
}