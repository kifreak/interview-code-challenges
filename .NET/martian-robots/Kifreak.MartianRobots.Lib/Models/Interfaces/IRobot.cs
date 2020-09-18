using System.Net;

namespace Kifreak.MartianRobots.Lib.Models.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; set; }

        ERobotStatus Status { get; set; }
    }
}