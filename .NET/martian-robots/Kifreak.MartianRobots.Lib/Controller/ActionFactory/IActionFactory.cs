using Kifreak.MartianRobots.Lib.Controller.ActionFactory.Actions;

namespace Kifreak.MartianRobots.Lib.Controller.ActionFactory
{
    public interface IActionFactory
    {
        IActionController CreateInstance(string name);
    }
}