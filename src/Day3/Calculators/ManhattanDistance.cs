using Day3.Models;
using System;

namespace Day3.Calculators
{
    public static class ManhattanDistance
    {
        public static int FindDistance(Location one, Location two) 
            => Math.Abs(one.X - two.X) + Math.Abs(one.Y - two.Y);
    }
}
