using System.Collections.Generic;
using System;

namespace AdventOfCode
{
    public class Day1 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            return SolveTopX(input, 1);
        }
        protected override string InternalSolve2(string[] input)
        {
            return SolveTopX(input, 3);
        }
        private string SolveTopX(string[] input, int topX=1)
        {
            int sum=0;
            List<int> elves = new List<int>();
            int current = 0;
            foreach (string s in input)
            {
                if (s == "")
                {
                    elves.Add(current);
                    current=0;
                }
                else
                {
                    current += Convert.ToInt32(s);
                }
            }
            elves.Add(current);
            elves.Sort();
            for (int i = 1; i<=topX;i++)
            {
                sum += elves[elves.Count - i];
            }
            return sum.ToString();
        }
    }
}