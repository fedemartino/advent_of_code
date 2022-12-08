using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day4 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            int totalOverlap = 0;
            foreach (string pair in input)
            {
                var parArray = pair.Split(",");
                var firstPair = GetPairStartEnd(parArray[0]);
                var secondPair = GetPairStartEnd(parArray[1]);
                if ((firstPair.Item1 <= secondPair.Item1 && firstPair.Item2 >= secondPair.Item2) || 
                    (secondPair.Item1<= firstPair.Item1 && secondPair.Item2 >= firstPair.Item2))
                {
                    totalOverlap++;
                }
            }
            return totalOverlap.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
        private (int, int) GetPairStartEnd(string pair)
        {
            string[] startEnd = pair.Split("-");
            return (int.Parse(startEnd[0]), int.Parse(startEnd[1]));
        }
    }
}