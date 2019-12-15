using Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3.Extensions
{
    public static class LocationExtensions
    {
        public static Location ApplyMove(this Location location, Movement move)
            => move.Direction switch
            {
                Direction.Up => new Location(location.X, location.Y + move.Units),
                Direction.Down => new Location(location.X, location.Y - move.Units),
                Direction.Left => new Location(location.X - move.Units, location.Y),
                Direction.Right => new Location(location.X + move.Units, location.Y),
                _ => throw new ArgumentException("Invalid move."),
            };

        public static (IEnumerable<VisitedLocation> locations, VisitedLocation finalLocation) Apply(this VisitedLocation location, Movement move)
        {
            var visitedLocations = new List<VisitedLocation>();

            var newLocation = location.Location.ApplyMove(move);

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
            => locations.Where(location => !IsCentralPort(location));

        public static bool IsCentralPort(Location location) 
            => location.Equals(Location.CentralPort);

        public static IEnumerable<VisitedLocation> ThatAreNotCentralPort(this IEnumerable<VisitedLocation> locations) 
            => locations.Where(location => !IsCentralPort(location.Location));
    }
}
