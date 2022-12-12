using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day5 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            List<List<string>> crateList = new List<List<string>>();
            crateList.Add(new List<string>());
            foreach (string line in input)
            {
                if (line[0..2] == " 1")
                {
                    break;
                }
                for (int i = 0; i<line.Length;i+=4)
                {
                    if (crateList.Count < i/4+1)
                    {
                        crateList.Add(new List<string>());
                    }
                    string crateLetter = line[(i+1)..(i+2)];
                    if (crateLetter != " ")
                    {
                        crateList[i/4].Add(crateLetter);
                    }
                    
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