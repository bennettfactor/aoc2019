using Day3.Extensions;
using Day3.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Day3
{
    public static class PathExtensions
    {
        public static Movement ToMove(this string s)
            => new Movement(s[0].ToDirection(), int.Parse(s[1..]));

        public static Direction ToDirection(this char c)
            => c switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new InvalidOperationException("Invalid movement direction."),
            };

        public static Path ToPath(this string line)
            => new Path(line.Split(',').Select(m => m.ToMove()));

        public static IEnumerable<Path> ToPaths(this IEnumerable<string> lines)
            => lines.Select(l => l.ToPath());

        public static IEnumerable<Location> GetLocationsFromCentralPort(this Path path)
        {
            var locationsTraversed = ImmutableList.Create<Location>();

            var currentLocation = Location.CentralPort;

            foreach (var move in path.Moves)
            {
                var (locations, finalLocation) = currentLocation.Apply(move);
                currentLocation = finalLocation;
                locationsTraversed = locationsTraversed.AddRange(locations);
            }

            return locationsTraversed;
        }
    }
}
