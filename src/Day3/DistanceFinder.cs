using Day3.Calculators;
using Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class DistanceFinder
    {
        public static int FindDistance(Path wireOne, Path wireTwo)
        {
            var wireOneLocations = new HashSet<Location>(wireOne.GetLocationsFrom(Location.CentralPort));
            var wireTwoLocations = new HashSet<Location>(wireTwo.GetLocationsFrom(Location.CentralPort));

            var intersections = wireOneLocations
                .Intersect(wireTwoLocations)
                .Where(l => !l.Equals(Location.CentralPort));

            var minDistance = int.MaxValue;
            foreach (var intersection in intersections)
            {
                minDistance = Math.Min(minDistance, ManhattanDistance.FindDistance(Location.CentralPort, intersection));
            }

            return minDistance;
        }
    }
}
