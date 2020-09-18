using Kifreak.MartianRobots.Lib.Models.Interfaces;

namespace Kifreak.MartianRobots.Lib.Models
{
    public class Robot: IRobot
    {
        public Robot(IPosition position)
        {
            CurrentPosition = position;
        }

        public IPosition CurrentPosition { get; }

        public override string ToString()
        {
            return CurrentPosition.ToString();
        }
    }
}