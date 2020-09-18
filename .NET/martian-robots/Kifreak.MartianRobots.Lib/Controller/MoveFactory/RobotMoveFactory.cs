using System;
using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.MoveFactory
{

    public class RobotMoveFactory: IRobotMoveFactory
    {
        private readonly Dictionary<int, Type> _instanceCreator = new Dictionary<int, Type>
        {
            { 0, typeof(MoveNorthController)},
            { 90, typeof(MoveEastController)},
            { 180, typeof(MoveSouthController)},
            { 270, typeof(MoveWestController)},
        };
        public IMovementController CreateInstance(int orientation)
        {
            return _instanceCreator.ContainsKey(orientation)
                ? Activator.CreateInstance(_instanceCreator[orientation]) as IMovementController
                : Activator.CreateInstance<NoMoveController>() as IMovementController;
        }
    }
}