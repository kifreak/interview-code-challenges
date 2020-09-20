using System;

namespace Kifreak.MartianRobots.Lib.Exceptions
{
    public class RobotBuildException : Exception
    {
        public RobotBuildException(string parameter) :
            base($"The parameter {parameter} is required for build a robot.")
        {
        }
    }
}