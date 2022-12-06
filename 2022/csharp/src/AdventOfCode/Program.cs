using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool debugTests = false;
            //debugTests = true;
            for (int i = 8; i <= 8; i++)
            {
                IPuzzle puzzle = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(string.Format("AdventOfCode.Day{0}", i)) as IPuzzle;
                string[] puzzleInput = InputReader.ReadInput(Path.Combine("./inputs",string.Format("input{0}.txt", i.ToString("00"))));       
                if (debugTests)
                {
                    puzzleInput = InputReader.ReadInput(Path.Combine("./inputs.test",string.Format("input{0}.txt", i.ToString("00"))));
                }
                string[] result = puzzle.Solve(puzzleInput);
                Console.WriteLine(string.Format("Day {0} result:", i));
                Console.WriteLine(string.Format("Part 1: {0}", result[0]));
                Console.WriteLine(string.Format("Part 2: {0}", result[1]));
                Console.WriteLine("\n");
            }
        }
    }
}
