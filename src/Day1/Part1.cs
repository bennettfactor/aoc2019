using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    public class Part1
    {
        public async Task Solve()
        {
            var lines = await File.ReadAllLinesAsync("input.txt");
            var solution = lines
                .Select(l => int.Parse(l))
                .Select(n => n / 3 - 2)
                .Sum();

            Console.WriteLine($"Solution: {solution}");
            Console.ReadLine();
        }
    }
}
