using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    public class Part2
    {
        public async Task Solve()
        {
            var lines = await File.ReadAllLinesAsync("input.txt");
            var solution = lines
                .Select(l => int.Parse(l))
                .Select(CalculateTotalFuel)
                .Sum();

            Console.WriteLine($"Solution: {solution}");
            Console.ReadLine();
        }

        public static int CalculateTotalFuel(int mass)
        {
            int currentMass = mass;
            int totalFuel = 0;

            while ((currentMass = CalculateBaseFuel(currentMass)) > 0)
            {
                if (currentMass > 0)
                {
                    totalFuel += currentMass;
                }
            }

            return totalFuel;
        }

        public static int CalculateBaseFuel(int mass)
            => mass / 3 - 2;
    }
}
