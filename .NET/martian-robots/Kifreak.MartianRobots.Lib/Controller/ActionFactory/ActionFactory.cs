using System;
using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
{
    public class ActionFactory : IActionFactory
    {
        private readonly List<IActionController> _allActions;

        public ActionFactory()
        {
            Type targetType = typeof(IActionController);
            IEnumerable<Type> typeList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterfaces().Contains(targetType));

            _allActions = typeList.Select(type => Activator.CreateInstance(type) as IActionController).ToList();
        }

        public IActionController CreateInstance(string name)
        {
            return _allActions.FirstOrDefault(action => action.Name == name) ?? new NullAction();
        }
    }
}