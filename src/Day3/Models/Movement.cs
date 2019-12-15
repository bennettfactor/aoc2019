namespace Day3.Models
{
    public class Movement
    {
        public Movement(Direction direction, int units)
        {
            Direction = direction;
            Units = units;
        }

        public Direction Direction { get; }

        public int Units { get; }
    }
}
