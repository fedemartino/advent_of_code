using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day2 : BasicPuzzle
    {
        
        protected override string InternalSolve1(string[] input)
        {
            var totalColors = new Dictionary<string, int>()
            {
                {"red", 12},
                {"green", 13},
                {"blue", 14}
            };
            int idSum = 0;
            foreach (string line in input)
            {
                var games = line.Split(':');
                var gameNumber = Convert.ToInt32(games[0].Split(' ')[1]);
                //Console.WriteLine($"Game number {gameNumber}");
                var gameplays = games[1].Split(';');
                bool validGame = true;
                foreach (var gameplay in gameplays)
                {
                    //Console.WriteLine($"New Play");
                    var colorCombinations = gameplay.Split(',');
                    foreach (var colorCombination in colorCombinations)
                    {
                        //Console.WriteLine($"Color combination:{colorCombination.Trim()}");
                        var color = colorCombination.Trim().Split(' ')[1];
                        var colorNumber = Convert.ToInt32(colorCombination.Trim().Split(' ')[0]);
                        validGame = validGame && totalColors[color] >= colorNumber;
                    }
                }
                if (validGame)
                {
                    //Console.WriteLine($"Game {gameNumber} is Valid");
                    idSum += gameNumber;
                }
            }
            return idSum.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            
            int powerSum = 0;
            foreach (string line in input)
            {
                int gamePower = 1;
                var games = line.Split(':');
                var gameNumber = Convert.ToInt32(games[0].Split(' ')[1]);
                //Console.WriteLine($"Game number {gameNumber}");
                var gameplays = games[1].Split(';');
                
                var totalColors = new Dictionary<string, int>()
                {
                    {"red", 0},
                    {"green", 0},
                    {"blue", 0}
                };
                foreach (var gameplay in gameplays)
                {
                    //Console.WriteLine($"New Play");
                    var colorCombinations = gameplay.Split(',');
                    foreach (var colorCombination in colorCombinations)
                    {
                        //Console.WriteLine($"Color combination:{colorCombination.Trim()}");
                        var color = colorCombination.Trim().Split(' ')[1];
                        var colorNumber = Convert.ToInt32(colorCombination.Trim().Split(' ')[0]);
                        if (totalColors[color] < colorNumber)
                        {
                            totalColors[color] = colorNumber;
                        }
                    }
                }
                foreach (var color in totalColors.Keys)
                {
                    //Console.WriteLine($"Color {color} has {totalColors[color]}");
                    gamePower = gamePower*totalColors[color];
                }
                //Console.WriteLine($"Game power: {gamePower.ToString()}");
                powerSum += gamePower;
            }
            return powerSum.ToString();
        }
    }
}