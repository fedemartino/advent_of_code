using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day2 : IPuzzle
    {
        private Dictionary<string, int> _directions = new Dictionary<string, int>()
        {
            { "forward", 1 },
            { "up", -1 },
            { "down", 1 }
        };
        private Dictionary<string, int> vector = new Dictionary<string, int>()
        {
            { "forward", 0 },
            { "up", 0 },
            { "down", 0 }
        };
        private int aim = 0;
        private int depth = 0;
        private int horizontal = 0;
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve1(input);
            aim = 0;
            depth = 0;
            horizontal = 0;
            result[1] = InternalSolve2(input);
            return result;
        }
        private string InternalSolve1(string[] input)
        {
            foreach (string line in input)
            {
                string[] words = line.Split(' ');
                if (words[0] == "up")
                {
                    depth += int.Parse (words[1]) * -1;
                }
                else if (words[0] == "down")
                {
                    depth += int.Parse (words[1]);
                }
                else
                {
                    horizontal += int.Parse (words[1]);
                }
            }
            return (horizontal * depth).ToString();
        }
        private string InternalSolve2(string[] input)
        {
            foreach (string line in input)
            {
                string[] words = line.Split(' ');
                if (words[0] == "up")
                {
                    aim += int.Parse (words[1]) * -1;
                }
                else if (words[0] == "down")
                {
                    aim += int.Parse (words[1]);
                }
                else
                {
                    horizontal += int.Parse (words[1]);
                    depth += aim*int.Parse (words[1]);
                }
            }            
            return (horizontal * depth).ToString();

        }
        
    }
}