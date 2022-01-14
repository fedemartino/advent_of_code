using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day8 : IPuzzle
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
            int total = 0;
            int[] uniqueSets = {2,3,4,7};
            foreach(string line in input)
            {
                int splitString = line.IndexOf(" | ");
                string[] input2 = line[(splitString+3)..].Split(" ");
                total += input2.Count(x => uniqueSets.Contains(x.Length));
            }
            return total.ToString();
        }
        private string InternalSolve2(string[] input)
        {
            int total = 0;
            
            foreach(string line in input)
            {
                Dictionary<string, int> unscrambledLetters = GetNumberFromLetters(line);
                int splitString = line.IndexOf(" | ");
                string[] scrambledWords = line[(splitString+3)..].Split(" ");
                string value = "";
                foreach (string word in scrambledWords)
                {
                    if (word != "")
                    {
                        value += unscrambledLetters[String.Concat(word.OrderBy(c=> c))];
                    }
                    
                }
                total += int.Parse(value);
            }
            return total.ToString();
        }   
        /// <summary>
        /// Returns true if a contains all of b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool Contains(string a, string b)
        {
            bool containsAll = true;
            foreach (char c1 in b.ToCharArray())
            {
                bool containsC = false;
                foreach (char c2 in a.ToCharArray())
                {
                    if (c2 == c1)
                    {
                        containsC = true;
                    }
                }
                containsAll = containsAll && containsC;
            }
            return containsAll;
        } 
        /// <summary>
        /// returns string resulting from a - b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private string Substract(string a, string b)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c1 in a.ToCharArray())
            {
                bool keep = true;
                foreach (char c2 in b.ToCharArray())
                {
                    if (c2 == c1)
                    {
                        keep = false;
                    }
                }
                if (keep)
                {
                    builder.Append(c1);
                }
            }
            return builder.ToString();
        }
        private Dictionary<string, int> GetNumberFromLetters(string input)
        {

            int splitString = input.IndexOf(" | ");
            string[] scrambledWords = input[..splitString].Split(" ");
            string[] unscrambledWords = new string[10];
            unscrambledWords[1] = String.Concat((from word in scrambledWords where word.Length == 2 select word).FirstOrDefault<string>().OrderBy(c=> c));
            unscrambledWords[4] = String.Concat((from word in scrambledWords where word.Length == 4 select word).FirstOrDefault<string>().OrderBy(c=> c));
            unscrambledWords[7] = String.Concat((from word in scrambledWords where word.Length == 3 select word).FirstOrDefault<string>().OrderBy(c=> c));
            unscrambledWords[8] = String.Concat((from word in scrambledWords where word.Length == 7 select word).FirstOrDefault<string>().OrderBy(c=> c));
            string[] remaining = (from word in scrambledWords where word.Length != 7 
                                    & word.Length != 3
                                    & word.Length != 4 
                                    & word.Length != 2 
                                    select word).ToArray<string>();
            foreach (string word in remaining)
            {
                if (word.Length == 6)
                {
                    if (Contains(word, unscrambledWords[4]))
                    {
                        unscrambledWords[9] = String.Concat(word.OrderBy(c=> c));
                    }
                    else if (Contains(word, unscrambledWords[1]))
                    {
                        unscrambledWords[0] = String.Concat(word.OrderBy(c=> c));
                    }
                    else
                    {
                        unscrambledWords[6] = String.Concat(word.OrderBy(c=> c));
                    }

                }
                else //length == 5
                {
                    if (Contains(word, unscrambledWords[1]))
                    {
                        unscrambledWords[3] = String.Concat(word.OrderBy(c=> c));
                    }
                    else if (Contains(word, Substract(unscrambledWords[8], unscrambledWords[4])))//????
                    {
                        unscrambledWords[2] = String.Concat(word.OrderBy(c=> c));
                    }
                    else
                    {
                        unscrambledWords[5] = String.Concat(word.OrderBy(c=> c));
                    }
                }
            }
            return ConvertArrayToDic(unscrambledWords);
        }  

        private Dictionary<string, int> ConvertArrayToDic(string[] array)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < array.Length; i++)
            {
                result.Add(array[i], i);
            }
            return result;
        }  
    }
}