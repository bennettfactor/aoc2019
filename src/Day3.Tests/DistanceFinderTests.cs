using Xunit;

namespace Day3.Tests
{
    public class DistanceFinderTests
    {
        [Fact]
        public void FirstExample()
        {
            var firstWirePath = "R8,U5,L5,D3".ToPath();
            var secondWirePath = "U7,R6,D4,L4".ToPath();

            var distance = DistanceFinder.FindDistance(firstWirePath, secondWirePath);

            Assert.Equal(6, distance);
        }
    }
}
