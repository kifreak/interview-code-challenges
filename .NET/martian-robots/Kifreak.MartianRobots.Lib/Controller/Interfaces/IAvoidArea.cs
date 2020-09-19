using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IAvoidArea
    {
        bool IsAvoidArea(Position nextPosition);

        void AddAvoidArea(Position position);
    }
}