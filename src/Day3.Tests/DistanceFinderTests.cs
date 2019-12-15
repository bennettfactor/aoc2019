using Xunit;

namespace Day3.Tests
{
    public class DistanceFinderTests
    {
        [Fact]
        public void Part1_Example()
        {
            var firstWirePath = "R8,U5,L5,D3".ToPath();
            var secondWirePath = "U7,R6,D4,L4".ToPath();

            var distance = DistanceFinder.FindMinManhattanDistance(firstWirePath, secondWirePath);

            Assert.Equal(6, distance);
        }

        [Fact]
        public void Part2_Example()
        {
            var firstWirePath = "R8,U5,L5,D3".ToPath();
            var secondWirePath = "U7,R6,D4,L4".ToPath();

            var distance = DistanceFinder.FindFewestSteps(firstWirePath, secondWirePath);

            Assert.Equal(30, distance);
        }
    }
}
