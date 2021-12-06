using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day2 : IPuzzle
    {
        private Dictionary<string, int> _directions = new Dictionary<string, int>()
        {
            { "forward", 1 },
            { "backwards", -1 },
            { "up", -1 },
            { "down", 1 }
        };
        private Dictionary<string, int> vector = new Dictionary<string, int>()
        {
            { "forward", 0 },
            { "backwards", 0 },
            { "up", 0 },
            { "down", 0 }
        };

        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve(input);
            result[1] = InternalSolve(input);
            return result;
        }
        private string InternalSolve(string[] input)
        {
            foreach (string line in input)
            {
                string[] words = line.Split(' ');
                vector[words[0]] += _directions[words[0]]*int.Parse(words[1]);
            }
            return ((vector["forward"] + vector["backwards"]) * (vector["up"] + vector["down"])).ToString();

        }
        
    }
}