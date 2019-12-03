using System;
using System.IO;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = (await File.ReadAllLinesAsync("input.txt"))[0];

            var part1 = new Part1();
            var part1Solution = part1.Solve(input, 12, 2);
            Console.WriteLine("Part1: " + part1Solution);

            var part2 = new Part2();
            var part2Solution = part2.GetNounAndVerb(input, 19690720);
            Console.WriteLine("Part2: " + part2Solution);

            Console.ReadLine();
        }
    }
}
