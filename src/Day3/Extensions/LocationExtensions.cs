using Day3.Models;
using System;
using System.Collections.Generic;

namespace Day3.Extensions
{
    public static class LocationExtensions
    {
        public static (IEnumerable<Location> locations, Location finalLocation) Apply(this Location location, Movement move)
        {
            var locations = new List<Location>();

            var newLocation = move.Direction switch
            {
                Direction.Up => new Location(location.X, location.Y + move.Units),
                Direction.Down => new Location(location.X, location.Y - move.Units),
                Direction.Left => new Location(location.X - move.Units, location.Y),
                Direction.Right => new Location(location.X + move.Units, location.Y),
                _ => throw new ArgumentException("Invalid move."),
            };

            var xOffset = newLocation.X - location.X;
            var yOffset = newLocation.Y - location.Y;

            for (int i = 1; i <= Math.Abs(xOffset); i++)
            {
                locations.Add(new Location(location.X + i * (xOffset > 0 ? 1 : -1), location.Y));
            }

            for (int i = 1; i <= Math.Abs(yOffset); i++)
            {
                locations.Add(new Location(location.X, location.Y + i * (yOffset > 0 ? 1 : -1)));
            }

            return (locations, newLocation);
        }
    }
}
