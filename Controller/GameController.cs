using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Model;
using TicTacToeGame.Sevice;

namespace TicTacToeGame.Controller
{
    public class GameController
    {
        private GameService gameService;

        public GameController(Player player1, Player player2)
        {
            gameService = new GameService(player1, player2);
        }

        public bool HandlePlayerMove(Player player, int row, int col)
        {
            return gameService.PlayerMove(player, row, col);
        }

        public bool CheckWinner(Player player)
        {
            return gameService.CheckWin(player);
        }

        public bool IsBoardFull()
        {
            return gameService.IsBoardFull();
        }

        public char[,] GetBoard()
        {
            return gameService.GetBoard();
        }

        public void ResetGame()
        {
            gameService.ResetBoard();
        }
    }
}