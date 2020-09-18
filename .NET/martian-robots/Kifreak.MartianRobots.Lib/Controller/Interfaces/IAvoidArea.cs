using Kifreak.MartianRobots.Lib.Models;
using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface IAvoidArea
    {
        bool IsAvoidArea(Position nextPosition);

        void AddAvoidArea(Position position);
    }
}