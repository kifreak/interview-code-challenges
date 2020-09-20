using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kifreak.MartianRobots.Console.CommandFactory;
using Kifreak.MartianRobots.Console.Expressions;
using Kifreak.MartianRobots.Console.Helpers;
using Kifreak.MartianRobots.Lib.Controller;

namespace Kifreak.MartianRobots.Console.Commands
{
    public class ManualRobotControllerCommand : ICommand, ICommandFactory
    {
        public Task Execute()
        {
            ConsoleHelper.InfoLine("Please, insert all the instructions. Type a empty line when you finish.");
            InputDataExpression expression = new InputDataExpression();
            int emptyLineErrorCounter = 0;
            while (true)
            {
                string line = System.Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(line))
                {
                    if (expression.Entry.IsValid())
                    {
                        break;
                    }
                    ConsoleHelper.Error("There are not enough parameter to execute the robots. Please continue typing info.");
                    emptyLineErrorCounter++;
                    if (emptyLineErrorCounter > 4)
                    {
                        ConsoleHelper.Error("Finish program");
                        break;
                    }
                    continue;
                }

                try
                {
                    expression.InsertNewData(line);
                }
                catch (Exception ex)
                {
                    ConsoleHelper.Error($"{ex.Message} Please, try again");
                }
            }
            RobotManager manager = expression.GetRobotManager();
            manager.ExecuteAllRobots();
            manager.Robots.ForEach(robot => ConsoleHelper.NormalLine(robot.ToPrint()));
            return Task.CompletedTask;
        }

        public bool Validate()
        {
            return true;
        }

        public string CommandName => "";
        public string Description => "Control multiple robots in a flat Mars";
        public Dictionary<string, string> OptionsDescription => new Dictionary<string, string>();
        public ICommand MakeCommand(string[] arguments)
        {
            return new ManualRobotControllerCommand();
        }
    }
}