using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class Day5 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            int instruction = 0;
            List<List<string>> crateList = BuildCrateList(input, out instruction); 
            
            for (int i = instruction; i< input.Length; i++)
            {
                string[] instructionParts = input[i].Split(" ");
                int ammount = int.Parse(instructionParts[1]);
                int origin = int.Parse(instructionParts[3]);
                int destination = int.Parse(instructionParts[5]);
                for (int j = 0; j<ammount;j++)
                {
                    string lastItem = crateList[origin-1][0];
                    crateList[destination-1].Insert(0, lastItem);
                    crateList[origin-1].RemoveAt(0);
                }
            }
            return GetTopCrateList(crateList);
        }
        protected override string InternalSolve2(string[] input)
        {
            int instruction = 0;
            List<List<string>> crateList = BuildCrateList(input, out instruction); 
            
            for (int i = instruction; i< input.Length; i++)
            {
                string[] instructionParts = input[i].Split(" ");
                int ammount = int.Parse(instructionParts[1]);
                int origin = int.Parse(instructionParts[3]);
                int destination = int.Parse(instructionParts[5]);

                crateList[destination-1].InsertRange(0, crateList[origin-1].GetRange(0, ammount));
                crateList[origin-1].RemoveRange(0, ammount);
            }
            return GetTopCrateList(crateList);
        }
        private List<List<string>> BuildCrateList(string[] input, out int firstIntstruction)
        {
            List<List<string>> crateList = new List<List<string>>();
            crateList.Add(new List<string>());
            firstIntstruction = 0;
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
                firstIntstruction++;
            }
            firstIntstruction+=2;
            return crateList;
        }
        private string GetTopCrateList(List<List<string>> crateList)
        {
            StringBuilder result = new StringBuilder();
            foreach (List<string> crateStack in crateList)
            {
                result.Append(crateStack[0]);
            }
            return result.ToString();
        }
    }
}