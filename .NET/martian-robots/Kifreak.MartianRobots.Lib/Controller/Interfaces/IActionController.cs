namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IActionController
    {
        string Name { get; }

        void ExecuteAction(IRobot robot);
    }
}