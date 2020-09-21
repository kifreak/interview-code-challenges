using System;
using System.Collections.Generic;
using System.Linq;
using Kifreak.MartianRobots.Lib.Controller.MoveFactory.Controller;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{
    public class RobotMoveFactory : IRobotMoveFactory
    {
        private readonly List<IMovementController> _allMovements;
        public RobotMoveFactory()
        {
            Type targetType = typeof(IMovementController);
            IEnumerable<Type> typeList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterfaces().Contains(targetType));

            _allMovements = typeList.Select(type => Activator.CreateInstance(type) as IMovementController).ToList();
        }
        public IMovementController CreateInstance(int orientation)
        {
            return _allMovements.FirstOrDefault(action => action.Orientation == orientation) ?? new NoMoveController();
        }
    }
}