using Day3.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            var paths = input
                .Split('\n')
                .Where(line => !string.IsNullOrEmpty(line))
                .ToPaths()
                .ToList();

            // Part 1
            var minManhattanDistance = DistanceFinder.FindMinManhattanDistance(paths[0], paths[1]);
            Console.WriteLine($"Min manhattan distance: {minManhattanDistance}");

            // Part 2
            var fewestSteps = DistanceFinder.FindFewestSteps(paths[0], paths[1]);
            Console.WriteLine($"Min steps: {fewestSteps}");

            Console.ReadLine();
        }
    }
}
