using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 2; i++)
            {
                IPuzzle puzzle = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(string.Format("AdventOfCode.Day{0}", i)) as IPuzzle;
                string[] result = puzzle.Solve(InputReader.ReadInput(Path.Combine("../../..",string.Format("input{0}.txt", i))));
                Console.WriteLine(string.Format("Day {0} result:", i));
                Console.WriteLine(string.Format("Part 1: {0}", result[0]));
                Console.WriteLine(string.Format("Part 2: {0}", result[1]));
                Console.WriteLine("\n");
            }
        }
    }
}
