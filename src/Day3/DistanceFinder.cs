using Day3.Calculators;
using Day3.Extensions;
using Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class DistanceFinder
    {
        public static int FindMinManhattanDistance(Path wireOne, Path wireTwo)
        {
            var wireOneLocations = new HashSet<Location>(wireOne.GetLocationsFrom(Location.CentralPort).Select(l => l.Location));
            var wireTwoLocations = new HashSet<Location>(wireTwo.GetLocationsFrom(Location.CentralPort).Select(l => l.Location));

            var intersections = wireOneLocations
                .Intersect(wireTwoLocations)
                .ThatAreNotCentralPort();

            var minDistance = int.MaxValue;
            foreach (var intersection in intersections)
            {
                minDistance = Math.Min(minDistance, ManhattanDistance.FindDistance(Location.CentralPort, intersection));
            }

            return minDistance;
        }

        public static int FindFewestSteps(Path wireOne, Path wireTwo)
        {
            var wireOneLocations = wireOne.GetMinStepLocationsFrom(Location.CentralPort);
            var wireTwoLocations = wireTwo.GetMinStepLocationsFrom(Location.CentralPort);

            var intersections = wireOneLocations.Keys.Intersect(wireTwoLocations.Keys);

            int minSteps = int.MaxValue;
            foreach (var intersection in intersections)
            {
                minSteps = Math.Min(minSteps, wireOneLocations[intersection] + wireTwoLocations[intersection]);
            }

            return minSteps;
        }
    }
}
