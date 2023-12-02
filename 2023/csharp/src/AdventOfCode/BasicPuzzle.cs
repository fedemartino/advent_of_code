namespace AdventOfCode
{
    public abstract class BasicPuzzle : IPuzzle
    {
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve1(input);
            result[1] = InternalSolve2(input);
            return result;
        }
        protected abstract string InternalSolve1(string[] input);
        protected abstract string InternalSolve2(string[] input);
    }
}