namespace Day3.Models
{
    public class VisitedLocation
    {
        public VisitedLocation(Location location, int stepCount)
        {
            Location = location;
            StepCount = stepCount;
        }

        public int StepCount { get; }

        public Location Location { get; }
    }
}
