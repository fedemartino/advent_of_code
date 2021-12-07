using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day4 : IPuzzle
    {
        private class Board 
        {
            public bool IsWinner {get;set;}
            private (int, bool)[][] _board;
            public Board(string[] rows)
            {
                _board = new (int, bool)[rows.Length][];
                for (int i = 0; i < rows.Length; i++)
                {
                    _board[i] = new (int, bool)[rows.Length];
                    string rowString = rows[i];
                    for (int j = 0; j < rows.Length; j++)
                    {
                        string number = rowString[..2];
                        rowString = rowString.Length > 2 ? rowString.Substring(3) : "";
                        
                        _board[i][j] = (int.Parse(number), false);
                    }
                }
            }
            public int GetTotal()
            {
                int total = 0;
                for (int i = 0; i < _board.Length; i++)
                {
                    for (int j = 0; j < _board.Length; j++)
                    {
                        if(!_board[i][j].Item2)
                        {
                            total += _board[i][j].Item1;
                        }
                    }
                }
                return total;
            }
            public void AddNumber(int number)
            {
                for (int i = 0; i < _board.Length; i++)
                {
                    for (int j = 0; j < _board.Length; j++)
                    {
                        if (_board[i][j].Item1 == number)
                        {
                            _board[i][j] = (_board[i][j].Item1, true);
                            this.IsWinner = CheckWin(i,j);
                        }
                    }
                }
            }
            private bool CheckWin(int x, int y)
            {
                bool rowWinner = true;
                bool colWinner = true;
                for (int i = 0; i < _board.Length; i++)
                {
                    rowWinner = rowWinner && (_board[x][i].Item2);
                    colWinner = colWinner && (_board[i][y].Item2);
                }
                return colWinner || rowWinner;
            }
        }
        List<Board> BoardList = new List<Board>();

        public string[] Solve(string[] input)
        {
            string[] result = new string[] {"",""};
            result[0] = InternalSolve1(input);
            result[1] = InternalSolve2(input);
            return result;
        }
        string[][] winningBoard;
        private string InternalSolve1(string[] input)
        {
            BuildBoards(input);
            string[] numbers = input[0].Split(',');

            bool winner = false;
            int nextNumber = 0;
            int currentNumber = 0;
            while (!winner)
            {
                foreach (Board b in BoardList)
                {
                    currentNumber = int.Parse(numbers[nextNumber]);
                    b.AddNumber(currentNumber);
                    if (b.IsWinner)
                    {
                        return (b.GetTotal() * currentNumber).ToString();
                    }
                }
                nextNumber++;   
            }
            return currentNumber.ToString();
            /*    currentNumber = numbers[nextNumber];
                nextNumber++;
                winner = CheckNumber(currentNumber);
            }
            int total = 0;
            for (int i = 0; i < winningBoard.Length; i++)
            {
                for (int j = 0; j < winningBoard[i].Length; j++)
                {
                    if (winningBoard[i][j] != "x")
                    {
                        total += int.Parse(winningBoard[i][j]);
                    }
                }
            }
            return (total * int.Parse(currentNumber)).ToString();*/
        }
        private string InternalSolve2(string[] input)
        {
            return "";
        }
        
        /*private bool CheckNumber(string number)
        {
            bool winner = false;
            foreach (string[][] board in BoardList)
            {
                if (CheckBoard(board, number))
                {
                    winner = true;
                    winningBoard = board;
                    break;
                }
            }
            return winner;
        }
        private bool CheckBoard(string[][] board, string number)
        {
            bool winner = false;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == number)
                    {
                        board[i][j] = "x";
                        winner = CheckWinner(board, i,j);
                    }
                }
            }
            return winner;
        }
        private bool CheckWinner(string[][] board, int x, int y)
        {
            bool rowWinner = true;
            bool colWinner = true;
            for (int i = 0; i < board.Length; i++)
            {
                rowWinner = rowWinner && (board[x][i] == "x");
                colWinner = colWinner && (board[i][y] == "x");
            }
            return colWinner || rowWinner;
        }*/
        private void BuildBoards(string[] input)
        {
            List<string[]> rows = new List<string[]>();
            int last = 2;
            for (int i = 2; i<input.Length; i++)
            {
                if (input[i].Length == 0)
                {
                    BoardList.Add(new Board(input[last..i]));
                    last = i+1;
                    /*List<string> rowList = new List<string>();
                    string rowString = input[i];
                    while (rowString.Length > 0)
                    {
                        string number = rowString[..2];
                        rowString = rowString.Length > 2 ? rowString.Substring(3) : "";
                        rowList.Add(number.TrimStart());
                    }
                    string[] boardLine = rowList.ToArray();
                    rows.Add(boardLine);
                    */
                }
                /*else 
                {
                    this.BoardList.Add(rows.ToArray());
                    rows = new List<string[]>();
                }*/
            }
            BoardList.Add(new Board(input[last..]));
        }
        
    }
}