using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day9 : BasicPuzzle
    {
        Dictionary<string, (int, int)> directions = new Dictionary<string, (int, int)>(){
            {"R",(0,1)},
            {"U",(1,0)},
            {"L",(0,-1)},
            {"D",(-1,0)}
        };
        protected override string InternalSolve1(string[] input)
        {
            return MoveRope(input, 1).ToString();
        }
        protected override string InternalSolve2(string[] input)
        {
            return MoveRope(input, 9).ToString();
        }
        private int MoveRope(string[] input, int numberOfKnotts)
        {
            var h = (0,0);
            (int, int)[] knotts = new (int, int)[numberOfKnotts];
            for (int i = 0; i < knotts.Length; i++)
            {
                knotts[i] = (0,0);
            }
            Dictionary<(int, int), int> uniquePositions = new Dictionary<(int, int), int>();
            foreach (var instruction in input)
            {
                var inst = instruction.Split(' ');
                var d = directions[inst[0]];
                var distance = int.Parse(inst[1]);
                for (int i = 0; i<distance;i++)
                {
                    h = (h.Item1+d.Item1, h.Item2 + d.Item2);
                    var tempH = h;
                    var t = knotts[0];
                    for (int j = 0; j < knotts.Length; j++)
                    {
                        t = knotts[j];
                        t = MoveTailToHead(tempH,t);
                        knotts[j] = t;
                        tempH = t;
                    }
                    uniquePositions[t] = 1;
                }
            }
            return uniquePositions.Keys.Count;
        }
        private (int, int) MoveTailToHead((int,int) h, (int,int) t)
        {
            var d1 = h.Item1-t.Item1;
            var d2 = h.Item2-t.Item2;
            var vectorialDistance = Math.Abs(d1) + Math.Abs(d2);
            if (vectorialDistance >= 3 || (vectorialDistance == 2 && (t.Item1 == h.Item1 || t.Item2 == h.Item2)))
            {
                if (d1 != 0)
                {
                    t.Item1 += d1/Math.Abs(d1);
                }
                if (d2 != 0)
                {
                    t.Item2 += d2/Math.Abs(d2);
                }
                
            }
            return t;
        }
    }
}