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
        /* protected override string InternalSolve1(string[] input)
        {
            int totalVisible = 0;
            string[] rowResult = new string[input.Length];
            string[] columnResult = new string[input[0].Length];
            string[] columns = new string[input[0].Length];
            for (int i = 0; i < input.Length;i++)
            {
                columns[i] = string.Concat(from rows in input select rows[i]);
            }
            int x = 0;
            foreach (string row in input)
            {
                rowResult[x] = TotalVisibleInArray(row);
                x++;
            }
            x = 0;
            foreach (string column in columns)
            {
                columnResult[x] = TotalVisibleInArray(column);
                x++;
            }
            var res = "";
            for (int i = 0; i < rowResult.Length;i++)
            {
                for (int j = 0; j < columnResult[i].Length;j++)
                {
                    if (columnResult[j][i] == '1' || rowResult[i][j]=='1')
                    {
                        res += "1";
                        totalVisible++;
                    }
                    else {
                        res+="0";
                    }
                } 
                res+="\r\n";
            } 
            return totalVisible.ToString();
        } */
        private string TotalVisibleInArray(string array)
        {
            StringBuilder result = new StringBuilder();
            result.Append("1");
            int i = 1;
            while (i<array.Length-1)
            {
                if (int.Parse(array[i-1].ToString()) < int.Parse(array[i].ToString()))
                {
                    result.Append("1");
                    i++;
                }
                else
                {
                    break;
                }
            }
            int j = array.Length - 2;
            StringBuilder result2 = new StringBuilder();
            while (j>i)
            {
                if (int.Parse(array[j+1].ToString()) < int.Parse(array[j].ToString()))
                {
                    result2.Insert(0,"1");
                    j--;
                }
                else
                {
                    result2.Append("1");
                    break;
                }
            }
            result.Append(new String('0', array.Length - result.Length - result2.Length));
            result.Append(result2.ToString());
            var res = result.ToString();
            return res;
            //ult.Append(new String('0', array.Length - result.Length - result2.Length)).Append(result2.ToString()).ToString();
        }
        /* private int TotalVisibleInArray(string array)
        {
            int total = 0;
            int i = 1;
            while (i<array.Length-1)
            {
                if (int.Parse(array[i-1].ToString()) < int.Parse(array[i].ToString()))
                {
                    total++;
                    i++;
                }
                else
                {
                    break;
                }
            }
            int j = array.Length - 2;
            while (j>i)
            {
                if (int.Parse(array[j+1].ToString()) < int.Parse(array[j].ToString()))
                {
                    total++;
                    j--;
                }
                else
                {
                    break;
                }
            }
            return total;
        } */
        
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
    }
}