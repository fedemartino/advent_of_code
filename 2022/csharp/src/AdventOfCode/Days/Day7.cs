using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day7 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            root = new Directory();
            BuildStructure(input[1..]);
            return "";
        }
        protected override string InternalSolve2(string[] input)
        {
            return "";
        }
        private void BuildStructure(string[] input)
        {
            
        }
        private void ProcessCommand(string command)
        {
            
        }
        Directory root;
        private class Directory
        {
            List<Directory> Directories {get;set;}
            List<File> Files {get;set;}
            public Directory()
            {
                this.Directories = new List<Directory>();
                this.Files = new List<File>();
            }
        }
        private class File
        {
            string Name {get;set;}
            int Size {get;set;}
        }
    }
}