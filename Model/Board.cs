using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Model
{
    public class Board
    {
        //declares 2d array 3x3 grid of characters means to represent the tic tac toe board
        private char[,] board;

        public Board()
        {
            board = new char[3, 3];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }
        public bool SetMove(int row, int col, char symbol)
        {
            if (board[row, col] == '-')
            {
                board[row, col] = symbol;
                return true;
            }
            return false;
        }

        //this method returns the current state of board means 2d array
        public char[,] GetBoard()
        {
            return board;
        }

        public bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell == '-')
                    return false;
            }
            return true;
        }
    }
}