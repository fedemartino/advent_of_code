using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day5 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            Regex regex = new Regex(@"[a-z]*-to-[a-z]* map:");
            foreach(var line in input)
            {
                if (regex.IsMatch(line))
                {
                    Console.WriteLine(line);
                }
            }
            return "";
        }
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
        
    }
}