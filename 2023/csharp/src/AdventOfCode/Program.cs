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
            string secondaryinput = "_2";
            secondaryinput = "";
            for (int i = 2; i <= 2; i++)
            {
                IPuzzle puzzle = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(string.Format("AdventOfCode.Day{0}", i)) as IPuzzle;
                if (debugTests)
                {
                    path = "../../../inputs.test";
                }
                string[] puzzleInput = InputReader.ReadInput(
                    Path.Combine(
                        path,string.Format($"input{i.ToString("00")}{secondaryinput}.txt")
                    )
                ); 
                string[] result = puzzle.Solve(puzzleInput);
                Console.WriteLine(string.Format("Day {0} result:", i));
                Console.WriteLine(string.Format("Part 1: {0}", result[0]));
                Console.WriteLine(string.Format("Part 2: {0}", result[1]));
                Console.WriteLine("\n");
            }
        }
    }
}
