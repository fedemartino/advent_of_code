using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day3 : IPuzzle
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
            string gammaRateString = "";
            for (int i = 0; i < input[0].Length; i++)
            {
                if (MostCommonBit(input, i) == 0)
                {
                    gammaRateString += "0";
                }
                else
                {
                    gammaRateString += "1";
                }
            }
            uint gammaRate = Convert.ToUInt32(gammaRateString, 2);
            Console.WriteLine(gammaRateString);
            uint all = Convert.ToUInt32(new string('1',input[0].Length), 2);
            uint epsilonRate = ~gammaRate & all;
            return (epsilonRate*gammaRate).ToString();
        }
        private string InternalSolve2(string[] input)
        {
            string[] oxygen = SolverRecursive(input, 0, true);
            string[] co2 = SolverRecursive(input, 0, false);
            //return Convert.ToInt32(oxygen[0],2).ToString();
            return (Convert.ToInt32(co2[0],2) * Convert.ToInt32(oxygen[0],2)).ToString();
        }
        private string[] SolverRecursive(string[] input, int index, bool mostCommon)
        {
            if (input.Length == 1)
            {
                return input;
            }
            else 
            {
                int commonBit = MostCommonBit(input, index);
                List<string> result = new List<string>();
                foreach(string s in input)
                {
                    
                    if (mostCommon && (int.Parse(s[index].ToString())==commonBit))
                    {
                        result.Add(s);
                    }
                    else if (!mostCommon && (int.Parse(s[index].ToString()) != commonBit))
                    {
                        result.Add(s);
                    }
                }
                return SolverRecursive(result.ToArray(), index + 1, mostCommon);
            }
        }
        private int MostCommonBit(string[] input, int index)
        {
            int[] digitCount = new int[]{0,0};
            foreach (string line in input)
            {
                digitCount[Convert.ToInt16(line[index].ToString())] +=1;
            }
            if (digitCount[0] > digitCount[1])
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        
    }
}