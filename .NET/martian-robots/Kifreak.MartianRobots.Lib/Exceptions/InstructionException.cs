using System;

namespace Kifreak.MartianRobots.Lib.Exceptions
{
    public class InstructionException : Exception
    {
        public InstructionException() : base("The instructions of the robot are not valid.")
        {

        }
    }
}