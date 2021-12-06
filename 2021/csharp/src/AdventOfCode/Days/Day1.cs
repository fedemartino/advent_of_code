using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day1 : IPuzzle
    {
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve(input, 1);
            result[1] = InternalSolve(input, 3);
            return result;
        }
        private string InternalSolve(string[] input, int groupSize)
        {
            int increases = 0;
            for (int i = 1; i <= input.Length - groupSize; i++)
            {
                if (GetGroupingValue(input, groupSize, i) > GetGroupingValue(input, groupSize, i-1))
                {
                    increases++;
                }
            }
            return increases.ToString();

        }
        private int GetGroupingValue(string[] input, int groupSize, int startIndex)
        {
            int value = 0;
            for (int i = startIndex; i < startIndex + groupSize; i++)
            {
                value += int.Parse(input[i]);
            }
            return value;
        }
        
    }
}