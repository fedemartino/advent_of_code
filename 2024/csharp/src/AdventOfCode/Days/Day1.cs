using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace AdventOfCode
{
    public class Day1 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            return Solve1(input);
            //return "";
        }
        protected override string InternalSolve2(string[] input)
        {
            return Solve2(input);
        }
        private string Solve1(string[] input)
        {
            int total = 0;
            var list1 = new List<int>();
            var list2 = new List<int>();
            foreach (string line in input)
            {
                string[] listValues = line.Split("   ");
                list1.Add(Convert.ToInt32(listValues[0]));
                list2.Add(Convert.ToInt32(listValues[1]));
            }   
            list1.Sort();
            list2.Sort();
            for (int i = 0; i < list1.Count; i++)
            {
                total += Math.Abs(list1[i] - list2[i]);
            }
            return total.ToString();
        }
        private string Solve2(string[] input)
        {
            return "";
        }
    }
}