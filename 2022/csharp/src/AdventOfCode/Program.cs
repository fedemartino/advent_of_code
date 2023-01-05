using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool debugTests = false;
            string path = "../../../inputs";
            //debugTests = true;
            for (int i = 9; i <= 9; i++)
            {
                IPuzzle puzzle = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(string.Format("AdventOfCode.Day{0}", i)) as IPuzzle;
                if (debugTests)
                {
                    path = "../../../inputs.test";
                }
                string[] puzzleInput = InputReader.ReadInput(Path.Combine(path,string.Format("input{0}.txt", i.ToString("00")))); 
                string[] result = puzzle.Solve(puzzleInput);
                Console.WriteLine(string.Format("Day {0} result:", i));
                Console.WriteLine(string.Format("Part 1: {0}", result[0]));
                Console.WriteLine(string.Format("Part 2: {0}", result[1]));
                Console.WriteLine("\n");
            }
        }
    }
}
