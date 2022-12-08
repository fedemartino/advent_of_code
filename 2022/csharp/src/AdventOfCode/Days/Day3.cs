using System.Collections.Generic;
using System.Linq;
using System;
namespace AdventOfCode
{
    public class Day3 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            int totalPriority = 0;
            foreach(string ruckSack in input)
            {
                int halfPoint = ruckSack.Length/2;
                string firstHalf = ruckSack[0..halfPoint];
                string secondHalf = ruckSack[halfPoint..];
                IEnumerable<char> priorityItems =  
                                    (from ch in firstHalf  
                                    where secondHalf.Contains(ch)  
                                    select ch).Distinct();
                foreach (char c in priorityItems)
                {
                    
                    totalPriority += GetCharPriority(c);
                }
            }
            return totalPriority.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            int totalPriority = 0;
            for (int i =0;i <input.Count()-1; i+=3)
            {
                IEnumerable<char> priorityItems =  
                                    (from ch in input[i]  
                                    where input[i+1].Contains(ch) && input[i+2].Contains(ch)
                                    select ch).Distinct();
                foreach (char c in priorityItems)
                {
                    totalPriority += GetCharPriority(c);
                }
            }
            return totalPriority.ToString();
        }
        private int GetCharPriority(char c)
        {
            return (Convert.ToInt32(c) - 38) % 58;
        }
    }
}