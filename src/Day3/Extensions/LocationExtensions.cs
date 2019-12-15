using Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3.Extensions
{
    public static class LocationExtensions
    {
        public static (IEnumerable<VisitedLocation> locations, VisitedLocation finalLocation) Apply(this VisitedLocation location, Movement move)
        {
            var visitedLocations = new List<VisitedLocation>();

            var newLocation = move.Direction switch
            {
                Direction.Up => new Location(location.Location.X, location.Location.Y + move.Units),
                Direction.Down => new Location(location.Location.X, location.Location.Y - move.Units),
                Direction.Left => new Location(location.Location.X - move.Units, location.Location.Y),
                Direction.Right => new Location(location.Location.X + move.Units, location.Location.Y),
                _ => throw new ArgumentException("Invalid move."),
            };

            var xOffset = newLocation.X - location.Location.X;
            var yOffset = newLocation.Y - location.Location.Y;

            for (int i = 1; i <= Math.Abs(xOffset); i++)
            {
                visitedLocations.Add(new VisitedLocation(new Location(location.Location.X + i * (xOffset > 0 ? 1 : -1), location.Location.Y), location.StepCount + i));
            }

            for (int i = 1; i <= Math.Abs(yOffset); i++)
            {
                visitedLocations.Add(new VisitedLocation(new Location(location.Location.X, location.Location.Y + i * (yOffset > 0 ? 1 : -1)), location.StepCount + i));
            }

            return (visitedLocations, visitedLocations.Last());
        }

        public static IEnumerable<Location> ThatAreNotCentralPort(this IEnumerable<Location> locations)
        {
            foreach (var location in locations)
            {
                if (!IsCentralPort(location))
                {
                    yield return location;
                }
            }
        }

        public static bool IsCentralPort(Location location) => location.Equals(Location.CentralPort);

        public static IEnumerable<VisitedLocation> ThatAreNotCentralPort(this IEnumerable<VisitedLocation> locations)
        {
            foreach (var location in locations)
            {
                if (!IsCentralPort(location.Location))
                {
                    yield return location;
                }
            }
        }
    }
}
