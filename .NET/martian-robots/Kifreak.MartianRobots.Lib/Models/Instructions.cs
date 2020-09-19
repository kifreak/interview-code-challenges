﻿using Kifreak.MartianRobots.Lib.Exceptions;

namespace Kifreak.MartianRobots.Lib.Models
{
    public class Instructions
    {
        private string[] _actions;
        public string[] Actions {
            get => _actions;
            set => _actions = ActionsIsValid(value) ? value : throw new InstructionException();
        }

        public Instructions(string[] actions)
        {
            SetActions(actions);
        }

        private void SetActions(string[] actions)
        {
            if (actions != null)
            {
                Actions = actions;
            }
        }
        private bool ActionsIsValid(string[] actions)
        {
            return !(actions == null || actions.Length > 100);
        }
    }
}