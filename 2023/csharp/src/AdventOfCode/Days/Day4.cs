using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode
{
    public class Day4 : BasicPuzzle
    {
        protected override string InternalSolve1(string[] input)
        {
            var totalPoints = 0;
            foreach (var card in input)
            {
                var cardNumber = card.Split(':')[0];
                var cardPlays = card.Split(':')[1];
                var winningNumbers = cardPlays.Split('|')[0].Trim().Split(' ');
                var playerNumbers = cardPlays.Split('|')[1].Trim().Split(' ');

                totalPoints += GetPoints(winningNumbers, playerNumbers);
            }
            return totalPoints.ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            var cardInstances = new int[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                cardInstances[i] = 1;
            }
            var totalPoints = 0;
            for(int i = 0; i < input.Length; i++)
            {
                var card = input[i];
                var cardNumber = card.Split(':')[0];
                var cardPlays = card.Split(':')[1];
                var winningNumbers = cardPlays.Split('|')[0].Trim().Split(' ').Where(c=> c != "");
                var playerNumbers = cardPlays.Split('|')[1].Trim().Split(' ').Where(c=> c != "");

                var wins = GetNumberOfWins(winningNumbers, playerNumbers);
                for (int j = i+1; j <= Math.Min(i+wins, input.Length-1); j++)
                {
                    cardInstances[j] += cardInstances[i];
                }
            }
            return cardInstances.Sum().ToString();
        }

        private int GetNumberOfWins(IEnumerable<string> winningNumbers, IEnumerable<string> playerNumbers)
        {
            var numberOfWins = (from p in playerNumbers.Where(c=> c != "")
                               where winningNumbers.Where(c=> c != "").Contains(p)
                               select p).Count();
            return numberOfWins;
        }

        private int GetPoints(string[] winningNumbers, string[] playerNumbers)
        {
            var numberOfWins = GetNumberOfWins(winningNumbers.Where(c=> c != ""), playerNumbers.Where(c=> c != ""));
            /*(from p in playerNumbers.Where(c=> c != "")
                               where winningNumbers.Where(c=> c != "").Contains(p)
                               select p).Count();*/
            var points = Math.Pow(2,numberOfWins-1);
            return (int)points;
        }
        
    }
}