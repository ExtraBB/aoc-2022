using Microsoft.Diagnostics.Tracing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    public record Location(int X, int Y);

    public class Day9 : IDay
    {
        public string Part1(string filePath)
        {
            (Location head, Location tail) locations = (new Location(0, 0), new Location(0, 0));

            HashSet<Location> seen = new HashSet<Location>() { new Location(locations.tail.X, locations.tail.Y) };

            foreach(string instruction in File.ReadLines(filePath))
            {
                var split = instruction.Split(' ');
                int steps = int.Parse(split[1]);
                switch (split[0]) 
                {
                    case "U": locations = MoveSteps(locations.head, locations.tail, 0, -1, steps, seen); break;
                    case "D": locations = MoveSteps(locations.head, locations.tail, 0, 1, steps, seen); break;
                    case "L": locations = MoveSteps(locations.head, locations.tail, -1, 0, steps, seen); break;
                    case "R": locations = MoveSteps(locations.head, locations.tail, 1, 0, steps, seen); break;
                }
            }

            return seen.Count.ToString();
        }

        private (Location head, Location tail) MoveSteps(Location head, Location tail, int dx, int dy, int steps, HashSet<Location> seen)
        {
            for (int i = 0; i < steps; i++)
            {
                Location prevHead = head;
                head = new Location(head.X + dx, head.Y + dy);

                int xDist = Math.Abs(head.X - tail.X);
                int yDist = Math.Abs(head.Y - tail.Y);
                int totalDist = xDist + yDist;
                if (xDist > 0 & yDist > 0)
                {
                    if (totalDist > 2)
                    {
                        tail = prevHead;
                    }
                }
                else if (totalDist > 1)
                {
                    tail = prevHead;
                }

                seen.Add(tail);
            }

            return (head, tail);
        } 

        public string Part2(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
