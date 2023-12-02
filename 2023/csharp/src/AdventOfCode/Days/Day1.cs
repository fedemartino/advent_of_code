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
            //return Solve1(input);
            return "";
        }
        protected override string InternalSolve2(string[] input)
        {
            return Solve2(input);
        }
        private string Solve1(string[] input)
        {
            int total = 0;
            foreach (string line in input)
            {
                char[] chars = line.ToCharArray();
                var numbers = from c in chars
                where Char.IsNumber(c)
                select c.ToString();
                int res = Convert.ToInt32(numbers.ElementAt(0) + numbers.ElementAt(numbers.Count()-1)); 
                //Console.WriteLine(res);
                total += res;

            }   
            return total.ToString();
        }
        private string Solve2(string[] input)
        {
            Dictionary<string, string> validWords = new Dictionary<string, string>(){
                {"1", "1"},
                {"2", "2"},
                {"3", "3"},
                {"4", "4"},
                {"5", "5"},
                {"6", "6"},
                {"7", "7"},
                {"8", "8"},
                {"9", "9"},
                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine", "9"}
            };
            int total = 0;
            foreach (string line in input)
            {
                List<string> numbers = new List<string>();
            
                for (int i = 0; i < line.Length; i++)
                {
                    for (int j = 1; j <= Math.Min(5, line.Length-i); j++)
                    {
                        var word = line[i..(i+j)];
                        if (validWords.Keys.Contains(word))
                        {
                            //Console.WriteLine(word);
                            numbers.Add(validWords[word]);
                            //i += j-1;
                            break;
                        }
                    }
                }
                var stringNumber = numbers.ElementAt(0) +  numbers.ElementAt(numbers.Count()-1);
                Console.WriteLine(stringNumber);
                total += int.Parse(stringNumber);
            }   
            return total.ToString();
        }
    }
}