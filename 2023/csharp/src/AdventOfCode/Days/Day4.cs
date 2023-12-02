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
                if (FullOverlap(firstPair, secondPair))
                {
                    totalOverlap++;
                }
            }
            return totalOverlap.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            int totalOverlap = 0;
            foreach (string pair in input)
            {
                var parArray = pair.Split(",");
                var firstPair = GetPairStartEnd(parArray[0]);
                var secondPair = GetPairStartEnd(parArray[1]);
                if (Overlap(firstPair, secondPair))
                {
                    totalOverlap++;
                }
            }
            return totalOverlap.ToString();;
        }
        private (int, int) GetPairStartEnd(string pair)
        {
            string[] startEnd = pair.Split("-");
            return (int.Parse(startEnd[0]), int.Parse(startEnd[1]));
        }
        private bool FullOverlap((int, int) firstPair, (int, int) secondPair)
        {
            return (firstPair.Item1 <= secondPair.Item1 && firstPair.Item2 >= secondPair.Item2) || 
                    (secondPair.Item1<= firstPair.Item1 && secondPair.Item2 >= firstPair.Item2);
        }
        private bool Overlap((int, int) firstPair, (int, int) secondPair)
        {
            return (firstPair.Item1 >= secondPair.Item1 && firstPair.Item1 <= secondPair.Item2) || 
                    (firstPair.Item2 >= secondPair.Item1 && firstPair.Item2 <= secondPair.Item2) ||
                    (secondPair.Item1 >= firstPair.Item1 && secondPair.Item1 <= firstPair.Item2) || 
                    (secondPair.Item2 >= firstPair.Item1 && secondPair.Item2 <= firstPair.Item2);
        }
    }
}