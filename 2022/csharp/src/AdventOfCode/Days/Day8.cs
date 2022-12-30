using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day8 : BasicPuzzle
    {

        protected override string InternalSolve1(string[] input)
        {
            int totalVisible = 0;

            for (int row = 1; row < input.Length-1;row++)
            {
                for (int col = 1; col< input[row].Length-1;col++)
                {
                    if (IsVisible(input, row, col))
                    {
                        totalVisible++;
                    }
                } 
            } 
            return (totalVisible + input.Length*2 + input[0].Length*2 - 4).ToString();
        }
        private bool IsVisible(string[] input, int rowNum, int colNum)
        {
            int currentTree = int.Parse(input[rowNum][colNum].ToString());
            string row = input[rowNum];
            string column = string.Concat(from rows in input select rows[colNum]);
            bool visible =
                (from tree in row[0..colNum]
                where int.Parse(tree.ToString()) < currentTree select tree).Count() == colNum
                || (from tree in row[(colNum+1)..]
                where int.Parse(tree.ToString()) < currentTree select tree).Count() == row[(colNum+1)..].Length
                || (from tree in column[0..rowNum]
                where int.Parse(tree.ToString()) < currentTree select tree).Count() == rowNum
                || (from tree in column[(rowNum+1)..]
                where int.Parse(tree.ToString()) < currentTree select tree).Count() == column[(rowNum+1)..].Length;

            return visible;
        }
        
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
    }
}