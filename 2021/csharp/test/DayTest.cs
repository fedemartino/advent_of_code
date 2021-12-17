using System;
using Xunit;
using AdventOfCode;
using System.IO;
using System.Reflection;
namespace test
{
    public class DayTests
    {
        
        [Theory]
        [InlineData(1, 1, 7)]
        [InlineData(1, 2, 5)]
        [InlineData(2, 1, 150)]
        [InlineData(2, 2, 900)]
        [InlineData(3, 1, 198)]
        [InlineData(3, 2, 230)]
        [InlineData(4, 1, 4512)]
        [InlineData(4, 2, 1924)]
        [InlineData(5, 1, 5)]
        [InlineData(5, 2, 12)]
        [InlineData(6, 1, 5934)]
        [InlineData(6, 2, 26984457539)]
        public void Test(int day, int part, Int64 expected)
        {
            Assembly assem = typeof(IPuzzle).Assembly;
            string dayString = day.ToString("00");
            
            IPuzzle puzzle = assem.CreateInstance(string.Format("AdventOfCode.Day{0}", day)) as IPuzzle;
            string[] result = puzzle.Solve(InputReader.ReadInput(Path.Combine("../../..",string.Format($"input{dayString}_{part}.txt"))));
            Assert.Equal(expected, Int64.Parse(result[part-1]));  
        }
    }
}
