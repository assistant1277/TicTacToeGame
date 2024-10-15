using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Model;

namespace TicTacToeGame.Sevice
{
    public class GameService
    {
        private Board board;
        private Player player1;
        private Player player2;

        public GameService(Player p1, Player p2)
        {
            board = new Board();
            player1 = p1;
            player2 = p2;
        }

        public bool PlayerMove(Player player, int row, int col)
        {
            return board.SetMove(row, col, player.Symbol);
        }

        public bool CheckWin(Player player)
        {
            char symbol = player.Symbol;
            char[,] b = board.GetBoard();

            for (int i = 0; i < 3; i++)
            {
                if ((b[i, 0] == symbol && b[i, 1] == symbol && b[i, 2] == symbol) || (b[0, i] == symbol && b[1, i] == symbol && b[2, i] == symbol))
                {
                    return true;
                }
            }

            if ((b[0, 0] == symbol && b[1, 1] == symbol && b[2, 2] == symbol) || (b[0, 2] == symbol && b[1, 1] == symbol && b[2, 0] == symbol))
            {
                return true;
            }
            return false;
        }

        public bool IsBoardFull()
        {
            return board.IsBoardFull();
        }

        public char[,] GetBoard()
        {
            return board.GetBoard();
        }

        public void ResetBoard()
        {
            board.InitializeBoard();
        }
    }
}