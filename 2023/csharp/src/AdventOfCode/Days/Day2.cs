using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day2 : BasicPuzzle
    {
        //A, X = Rock
        //B, Y = Paper
        //C, Z = Scissors
        protected Dictionary<string, int> values = new Dictionary<string, int>() 
        {
            {"A", 0},
            {"B", 1},
            {"C", 2},
            {"X", 0},
            {"Y", 1},
            {"Z", 2}
        };
        protected override string InternalSolve1(string[] input)
        {
            int totalScore = 0;
            foreach (string play in input)
            {
                string[] playCombo = play.Split(' ');
                string myPlay = playCombo[1];
                string elfPlay = playCombo[0];
                int elfValue = values[elfPlay];
                int myValue = values[myPlay];
                
                if (elfValue == myValue) //draw
                {
                    totalScore += myValue + 3;
                }
                else if ((myValue+1)%3==elfValue) //I loose because my value + 1 mod 3 equals the elf's choice. The choice above looses to the one below
                {
                    totalScore += myValue;
                }
                else //I win
                {
                    totalScore += myValue + 6;
                }
                totalScore += 1;
            }
            return totalScore.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            int totalScore = 0;
            foreach (string play in input)
            {
                string[] playCombo = play.Split(' ');
                string myPlay = playCombo[1];
                string elfPlay = playCombo[0];
                int elfValue = values[elfPlay];
                
                if(myPlay == "X") //loose
                {
                    totalScore += (((elfValue-1) % 3) + 3) % 3;
                }
                else if (myPlay == "Y") //draw
                {
                    totalScore += elfValue + 3;
                }
                else //win
                {
                    totalScore += (elfValue+1)%3 + 6;
                }
                
                totalScore += 1;
            }
            return totalScore.ToString();
        }
    }
}