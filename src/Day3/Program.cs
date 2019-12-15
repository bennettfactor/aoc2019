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
            var distance = DistanceFinder.FindDistance(paths[0], paths[1]);
            Console.WriteLine($"Distance: {distance}");

            // Part 2
            // TODO: Part 2

            Console.ReadLine();
        }
    }
}
