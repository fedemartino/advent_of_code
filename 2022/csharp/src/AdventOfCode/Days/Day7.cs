using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day7 : BasicPuzzle
    {
        Directory currentDirectory;
        Directory root;
        Dictionary<string, Directory> allDirectories;
        protected override string InternalSolve1(string[] input)
        {
            allDirectories = new Dictionary<string, Directory>();
            root = new Directory();
            root.Name = "/";
            currentDirectory = root;
            BuildStructure(root, input[1..]);
            ComputeSizes(root);
            int totalSize = 0;
            foreach (Directory d in allDirectories.Values)
            {
                if (d.Size <= 100000)
                {
                    totalSize+=d.Size;
                }
            }
            return totalSize.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            int currentBest = 70000000;
            int spaceRequiered = 30000000 - (70000000-root.Size);
            foreach (Directory d in allDirectories.Values)
            {
                if (d.Size <= currentBest && d.Size >= spaceRequiered)
                {
                    currentBest=d.Size;
                }
            }
            return currentBest.ToString();
        }
        private void ComputeSizes(Directory dir)
        {
            int totalSize = 0;
            foreach (Directory d in dir.Directories.Values)
            {
                ComputeSizes(d);
                totalSize+=d.Size;
            }
            foreach (File f in dir.Files.Values)
            {
                totalSize+= f.Size;
            }
            dir.Size = totalSize;
        }
        private void BuildStructure(Directory dir, string[] input)
        {
            for (int i=0;i <input.Length;i++)
            {
                if (input[i][0]=='$')
                {
                    ProcessCommand(input[i][2..]);
                }
                else
                {
                    string[] commandParts = input[i].Split(' ');
                    if (commandParts[0] == "dir")
                    {
                        string dirName = currentDirectory.Name+commandParts[1];
                        if (allDirectories.ContainsKey(dirName))
                        {
                            var d = allDirectories[dirName];
                            currentDirectory.Directories[dirName] = d;
                            d.Parent = currentDirectory;
                        }
                        else
                        {
                            var d = new Directory();
                            d.Name = dirName;
                            d.Parent = currentDirectory;
                            currentDirectory.Directories[dirName] = d;
                            allDirectories[dirName] = d;
                        }
                    }
                    else
                    {
                        var f = new File();
                        f.Name = commandParts[1];
                        f.Size = int.Parse(commandParts[0]);
                        currentDirectory.Files[f.Name] = f;
                    }
                }
            }
        }
        private void ProcessCommand(string command)
        {
            if (command[0..2]=="cd")
            {
                string command2 = command[3..];
                if (command2 == ".." && currentDirectory.Name != "/")
                {
                    currentDirectory = currentDirectory.Parent;
                }
                else if (command2 == "/")
                {
                    currentDirectory = root;
                }
                else 
                {
                    var newDir = (from dir in currentDirectory.Directories.Values
                                        where dir.Name == currentDirectory.Name+command2
                                        select dir).FirstOrDefault<Directory>();
                    if (newDir != null)
                    {
                        currentDirectory = newDir;
                    }
                     
                }
            }
        }
        
        internal class Directory
        {
            public int Size {get;set;}
            public Directory Parent {get;set;}
            public Dictionary<string, Directory> Directories {get;set;}
            public Dictionary<string, File> Files {get;set;}
            public string Name {get;set;}
            public Directory()
            {
                this.Directories = new Dictionary<string, Directory>();
                this.Files = new Dictionary<string, File>();
                this.Parent = null;
            }
        }
        internal class File
        {
            public string Name {get;set;}
            public int Size {get;set;}
        }
    }
}