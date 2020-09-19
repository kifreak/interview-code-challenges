using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Lib.Controller.Interfaces
{
    public interface INotAllowPosition
    {
        bool IsNotAllowPosition(Position nextPosition);

        void AddNotAllowedPosition(Position position);
    }
}