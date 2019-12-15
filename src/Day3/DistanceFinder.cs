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
            var wireOneLocations = wireOne.GetLocationsFrom(Location.CentralPort);
            var wireTwoLocations = wireTwo.GetLocationsFrom(Location.CentralPort);

            var minStepLocations1 = wireOneLocations
                .Where(l => !l.Location.Equals(Location.CentralPort))
                .GroupBy(l => l.Location)
                .ToDictionary(grp => grp.Key, grp => grp.Min(vl => vl.StepCount));

            var minStepLocations2 = wireTwoLocations
                .Where(l => !l.Location.Equals(Location.CentralPort))
                .GroupBy(l => l.Location)
                .ToDictionary(grp => grp.Key, grp => grp.Min(vl => vl.StepCount));

            var intersectLocations = minStepLocations1.Keys.Intersect(minStepLocations2.Keys);

            int minSteps = int.MaxValue;
            foreach (var intersection in intersectLocations)
            {
                minSteps = Math.Min(minSteps, minStepLocations1[intersection] + minStepLocations2[intersection]);
            }

            return minSteps;
        }
    }
}
