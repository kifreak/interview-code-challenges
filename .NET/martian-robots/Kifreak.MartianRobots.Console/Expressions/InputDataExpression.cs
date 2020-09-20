using Kifreak.MartianRobots.Console.Expressions.Interfaces;
using Kifreak.MartianRobots.Console.Expressions.Parsers;
using Kifreak.MartianRobots.Console.ViewModel;
using Kifreak.MartianRobots.Lib.Controller;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory;
using Kifreak.MartianRobots.Lib.Models;
using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory;

namespace Kifreak.MartianRobots.Console.Expressions
{
    public class InputDataExpression
    {
        public EntryData Entry { get; set; }
        private readonly IExpression _gridExpression;
        private readonly IExpression _positionExpression;
        private readonly IExpression _instructionExpression;

        public InputDataExpression()
        {
            Entry = new EntryData();
            _gridExpression = new Expression(new GridParser());
            _positionExpression = new Expression(new PositionParser());
            _instructionExpression = new Expression(new InstructionParser());
        }

        public void InsertNewData(string line)
        {
            if (Entry.Grid == null)
            {
                _gridExpression.Interpret(Entry, nameof(EntryData.Grid), line);
                return;
            }

            if (Entry.Positions.Count == Entry.Instructions.Count)
            {
                _positionExpression.Interpret(Entry, nameof(EntryData.Positions), line);
            }
            else
            {
                _instructionExpression.Interpret(Entry, nameof(EntryData.Instructions), line);
            }
        }

        public RobotManager GetRobotManager()
        {
            RobotManager robotManager = new RobotManager(Entry.Grid, new NotAllowPosition(), new ActionFactory());
            RobotMovement robotMovement = new RobotMovement(new RobotMoveFactory());
            IEnumerable<Robot> robots = Entry.Positions
                .Select((value, key) =>
                    new KeyValuePair<int, Position>(key, value))
                .Select(pair =>
                    new Robot(pair.Value, robotMovement,
                        Entry.Instructions[pair.Key]));
            robotManager.AddRobot(robots);
            return robotManager;
        }
    }
}