using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day7 : IPuzzle
    {
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve1(input);
            result[1] = InternalSolve2(input);
            return result;
        }
        private string InternalSolve1(string[] input)
        {
            List<int> positions = (from pos in input[0].Split(",") select int.Parse(pos)).ToList<int>();
            int max = positions.Max();
            (int, int) bestPair = (0,Int32.MaxValue);
            for (int i = 0; i <= max; i++)
            {
                int totalFuel = 0;
                foreach(int pos in positions)
                {
                    totalFuel += Math.Abs(pos-i);
                }
                if (totalFuel < bestPair.Item2)
                {
                    bestPair = (i,totalFuel);
                }
            }
            return bestPair.Item2.ToString();
        }
        private string InternalSolve2(string[] input)
        {
            List<int> positions = (from pos in input[0].Split(",") select int.Parse(pos)).ToList<int>();
            int max = positions.Max();
            (int, int) bestPair = (0,Int32.MaxValue);
            for (int i = 0; i <= max; i++)
            {
                int totalFuel = 0;
                foreach(int pos in positions)
                {
                    int dist = Math.Abs(pos-i);
                    totalFuel += (dist * (dist+1))/2;
                }
                if (totalFuel < bestPair.Item2)
                {
                    bestPair = (i,totalFuel);
                }
            }
            return bestPair.Item2.ToString();
        }        
    }
}