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
        [InlineData(1, 1, "142")]
        //[InlineData(1, 2, "45000")]
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
