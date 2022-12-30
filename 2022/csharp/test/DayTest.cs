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
        [InlineData(1, 1, "24000")]
        [InlineData(1, 2, "45000")]
        [InlineData(2, 1, "15")]
        [InlineData(2, 2, "12")]
        [InlineData(3, 1, "157")]
        [InlineData(3, 2, "70")]
        [InlineData(4, 1, "2")]
        [InlineData(4, 2, "4")]
        [InlineData(5, 1, "CMZ")]
        [InlineData(5, 2, "MCD")]
        [InlineData(6, 1, "7")]
        [InlineData(6, 2, "19")]
        [InlineData(7, 1, "95437")]
        [InlineData(7, 2, "24933642")]
        [InlineData(8, 1, "21")]
        [InlineData(8, 2, "1")]
        public void Test(int day, int part, string expected)
        {
            Assembly assem = typeof(IPuzzle).Assembly;
            string dayString = day.ToString("00");
            
            IPuzzle puzzle = assem.CreateInstance(string.Format("AdventOfCode.Day{0}", day)) as IPuzzle;
            string[] result = puzzle.Solve(InputReader.ReadInput(Path.Combine("../../../../../inputs.test",string.Format($"input{dayString}.txt"))));
            //Assert.Equal(expected, Int64.Parse(result[part-1]))
            Assert.Equal(expected, result[part-1]);  
        }
    }
}
