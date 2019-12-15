using System;

namespace Day3.Models
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString() => $"X: {X}, Y: {Y}";

        public static Location CentralPort => new Location(0, 0);
    }
}
