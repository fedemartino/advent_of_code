using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day6 : IPuzzle
    {
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve1(input);
            result[1] = InternalSolve2(input);
            return result;
        }
        private string InternalSolve1(string[] input, int days = 80)
        {
            List<int> lanterns = (from lantern in input[0].Split(",") select int.Parse(lantern)).ToList<int>();
            Int64[] currentState = new Int64[]{0,0,0,0,0,0,0,0,0};
            Int64 total = 0;
            foreach(int lantern in lanterns)
            {
                currentState[lantern] += 1;
            }
            for (int i = 0; i <days; i++)
            {
                total = 0;
                Int64 newLanterns = currentState[0];
                currentState[7] += newLanterns;
                for (int j = 0; j < 8; j++)
                {
                    currentState[j] = currentState[j+1];
                    total+= currentState[j];
                }
                currentState[8] = newLanterns;
                total+= newLanterns;
            }
            return total.ToString();
        }
        private string InternalSolve2(string[] input, int days = 256)
        {
            return InternalSolve1(input, days);
        }        
    }
}