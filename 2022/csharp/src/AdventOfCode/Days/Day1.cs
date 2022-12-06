using System.Collections.Generic;
using System;

namespace AdventOfCode
{
    public class Day1 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            int max = 0;
            int current = 0;
            foreach (string s in input)
            {
                if (s == "")
                {
                    if (current > max)
                    max=current;
                    current = 0;
                }
                else
                {
                    current += Convert.ToInt32(s);
                }
            }
            return max.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
    }
}