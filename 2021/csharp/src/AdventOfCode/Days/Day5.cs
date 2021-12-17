using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day5 : IPuzzle
    {
        Dictionary<(int, int), int> ventMap = new Dictionary<(int, int), int>();
        int counter = 0;
        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            ventMap = new Dictionary<(int, int), int>();
            counter = 0;
            result[0] = InternalSolve1(input);
            result[1] = InternalSolve2(input);
            return result;
        }
        private string InternalSolve1(string[] input)
        {
            foreach (string line in input)
            {
                (int, int)[] c = GetCoordinates(line);

                if (c[0].Item1 == c[1].Item1 || c[0].Item2 == c[1].Item2)
                {
                    int dirX = GetDirection(c[0].Item1, c[1].Item1);
                    int dirY = GetDirection(c[0].Item2, c[1].Item2);
                    for (int x = c[0].Item1; dirX*(c[1].Item1-x)>=0; x += dirX)
                    {
                        for (int y = c[0].Item2; dirY*(c[1].Item2-y)>=0; y += dirY)
                        {
                            if (ventMap.ContainsKey((x,y)))
                            {
                                if (ventMap[(x,y)] == 1)
                                {
                                    counter++;
                                }
                                ventMap[(x,y)] += 1;
                            }
                            else
                            {
                                ventMap[(x,y)] = 1;
                            }
                        }
                    }
                }
            }
            //PrintVentDiagram(ventMap);
            return counter.ToString();
        }
        private string InternalSolve2(string[] input)
        {
            foreach (string line in input)
            {
                (int, int)[] c = GetCoordinates(line);

                if (Math.Abs(c[0].Item1 - c[1].Item1) == Math.Abs(c[0].Item2 - c[1].Item2))
                {
                    int x = c[0].Item1;
                    int y = c[0].Item2;
                    int dist = Math.Abs(c[0].Item1 - c[1].Item1);
                    int dirX = GetDirection(c[0].Item1, c[1].Item1);
                    int dirY = GetDirection(c[0].Item2, c[1].Item2);
                    for (int i = 0; i <= dist; i++)
                    {
                        int x1 = x + i * dirX;
                        int y1 = y + i * dirY;
                        if (ventMap.ContainsKey((x1,y1)))
                        {
                            if (ventMap[(x1,y1)] == 1)
                            {
                                counter++;
                            }
                            ventMap[(x1,y1)] += 1;
                        }
                        else
                        {
                            ventMap[(x1,y1)] = 1;
                        }
                    }
                }
            }
            return counter.ToString();
        }

        private void PrintVentDiagram(Dictionary<(int,int), int> ventMap)
        {
            int maxX = 0;
            int maxY = 0;
            foreach ((int, int) key in ventMap.Keys)
            {
                if (key.Item1 > maxX)
                {
                    maxX = key.Item1;
                }
                if (key.Item2 > maxY)
                {
                    maxY = key.Item2;
                }
            }
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if (ventMap.ContainsKey((x,y)))
                    {
                        Console.Write(ventMap[(x,y)].ToString());
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
        }
        private int GetDirection(int from, int to)
        {
            if (to < from)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        private (int, int)[] GetCoordinates(string input)
        {
            List<(int,int)> coordinates =  new List<(int, int)>();
            int firstPair = input.IndexOf(" -> ");
            int lastPair = firstPair + " -> ".Length;

            string[] coordinatePair = input[0..firstPair].Split(",");
            (int, int) startPoint = (int.Parse(coordinatePair[0]), int.Parse(coordinatePair[1]));
            

            coordinatePair = input[lastPair..].Split(",");
            (int, int) endPoint = (int.Parse(coordinatePair[0]), int.Parse(coordinatePair[1]));

            /*if (startPoint.Item1 > endPoint.Item1 || ((startPoint.Item1 == endPoint.Item1) && (startPoint.Item2 > endPoint.Item2)))
            {
                coordinates.Add(endPoint);
                coordinates.Add(startPoint);
            }
            else*/
            {
                coordinates.Add(startPoint);
                coordinates.Add(endPoint);
            }
            return coordinates.ToArray();
        }
        
    }
}