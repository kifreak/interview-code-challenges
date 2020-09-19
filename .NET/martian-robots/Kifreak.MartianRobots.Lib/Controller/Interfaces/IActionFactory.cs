namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IActionFactory
    {
        IActionController CreateInstance(string name);
    }
}