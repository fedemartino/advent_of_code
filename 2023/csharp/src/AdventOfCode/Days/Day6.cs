using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day6 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            return FindDistinctStart(input[0], 4).ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            return FindDistinctStart(input[0], 14).ToString();
        }
        private int FindDistinctStart(string signal, int packetSize)
        {
            for (int i = 0; i<signal.Length;i++)
            {
                if ((from c in signal[i..(i+packetSize)] select c).Distinct<char>().Count() == packetSize)
                {
                    return i+packetSize;
                }
            }
            return 0;
        }
    }
}