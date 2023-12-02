using System.IO;

namespace AdventOfCode
{
    public static class InputReader
    {
        public static string[] ReadInput(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}