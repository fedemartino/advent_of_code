using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
namespace AdventOfCode
{
    public class Day3 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            var total =0;
            var matrix = GetMatrix(input);
            var partNumberDict = new Dictionary<int, int>();
            for (int i = 1; i < matrix.Length-1; i++)
            {
                bool hasAdjacentSymbol = false;
                var numberString = "0";
                //Console.WriteLine("Row: " + i);
                //Console.WriteLine(matrix[i].Length);
                for (int j = 1; j < matrix[i].Length-1; j++)
                {
                    if (char.IsNumber(matrix[i][j]))
                    {
                        numberString += matrix[i][j];
                        hasAdjacentSymbol = hasAdjacentSymbol || SpotHasAdjacentSymbol(matrix, i, j);
                        //Console.WriteLine($"New Number string: {numberString}");
                    }
                    else 
                    {
                        if (numberString != "0")
                        {
                            //Console.WriteLine($"Number string: {numberString}");
                        }
                        var number = Convert.ToInt32(numberString);
                        if (hasAdjacentSymbol )//&& !partNumberDict.ContainsKey(number))
                        {
                            if (numberString != "0")
                                Console.WriteLine($"Number string: {numberString}");
                            total += Convert.ToInt32(numberString);
                            //partNumberDict.Add(number, 1);
                        }
                        numberString = "0";
                        hasAdjacentSymbol = false;
                    }
                                      
                }
                if (hasAdjacentSymbol )//&& !partNumberDict.ContainsKey(number))
                {
                    if (numberString != "0")
                        Console.WriteLine($"Number string: {numberString}");
                    total += Convert.ToInt32(numberString);
                    //partNumberDict.Add(number, 1);
                }
            }
            return total.ToString();
        }

        private bool SpotHasAdjacentSymbol(char[][] matrix, int i, int j)
        {
            for(int k = i-1; k <= i+1; k++)
            {
                for(int l = j-1; l <= j+1; l++)
                {
                    try
                    {
                        var value = matrix[k][l];
                        if (value != '.' && (!char.IsNumber(value)))
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine($"i:{i}, j:{j}, k:{k}, l:{l}");
                        Console.WriteLine($"Matrix dimensions: {matrix.Length}x{matrix[0].Length}");
                    }
                    
                }
            }
            return false;
        }

        protected override string InternalSolve2(string[] input)
        {
            
            return "".ToString();
        }
        private char[][] GetMatrix(string[] input)
        {
            var matrix = new char[input.Length+2][];
            string padding = new string('.',input[0].Length+2);
            matrix[0] = padding.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                var paddedInput = "." + input[i] + "."; 
                matrix[i+1] = paddedInput.ToCharArray();
            }
            matrix[input.Length+1] = padding.ToCharArray();
            return matrix;
        }
    }
}