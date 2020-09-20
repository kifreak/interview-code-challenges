using System.Collections.Generic;
using Kifreak.MartianRobots.Lib.Models;

namespace Kifreak.MartianRobots.Console.ViewModel
{
    public class EntryData
    {
        public List<Position> Positions { get; set;}
        public List<Instructions> Instructions { get; set; }
        public Grid Grid { get; set; }

        public EntryData()
        {
            Positions = new List<Position>();
            Instructions = new List<Instructions>();
        }

        public bool IsValid()
        {
            return Grid != null && Positions.Count > 0 && Positions.Count == Instructions.Count;
        }
    }
}