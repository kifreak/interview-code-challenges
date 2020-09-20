using Kifreak.MartianRobots.Console.ViewModel;
using Kifreak.MartianRobots.Lib.Controller.Interfaces;
using System;

namespace Kifreak.MartianRobots.Console.Helpers
{
    public static class ConsoleHelper
    {
        public static void Error(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void NormalLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public static void Normal(string message)
        {
            System.Console.Write(message);
        }

        public static void InfoLine(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.Write(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Blue(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.Write(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void BlueLine(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void JumpLine(int numberOfLinesToJump)
        {
            for (var i = 0; i < numberOfLinesToJump; i++)
            {
                System.Console.WriteLine();
            }
        }

        public static void LineSeparator()
        {
            System.Console.WriteLine("==========================================================================================");
        }
    }

    public static class StringExtensions
    {
        public static string ToPrint(this IRobot robot)
        {
            string positionString =
                $"{robot.CurrentPosition.X} {robot.CurrentPosition.Y} {(EOrientation)robot.CurrentPosition.Orientation}";
            return robot.ToString(positionString);
        }
    }
}