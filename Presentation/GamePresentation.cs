using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Controller;
using TicTacToeGame.Model;

namespace TicTacToeGame.Presentation
{
    public class GamePresentation
    {
        private static GameController gameController;

        public static void StartGame()
        {
            Console.WriteLine("***** Welcome to tic tac toe game *****\n");

            Console.Write("Enter name of player 1 [X] -> ");
            string player1Name = Console.ReadLine();
            Player player1 = new Player(player1Name, 'X');

            Console.Write("Enter name of player 2 [O] -> ");
            string player2Name = Console.ReadLine();
            Player player2 = new Player(player2Name, 'O');

            gameController = new GameController(player1, player2);

            bool playAgain = true;
            while (playAgain)
            {
                PlaySingleGame(player1, player2);
                playAgain = AskToPlayAgain();
                if (playAgain)
                {
                    gameController.ResetGame(); 
                }
            }

            Console.WriteLine("Thanks for playing tic tac toe game");
        }

        private static void PlaySingleGame(Player player1, Player player2)
        {
            bool isGameOver = false;
            Player currentPlayer = player1;

            while (!isGameOver)
            {
                DisplayBoard();
                Console.WriteLine($"{currentPlayer.Name} turn ({currentPlayer.Symbol})");

                int row = GetUserInput("Enter row (0,1,2) -> ");
                int col = GetUserInput("Enter column (0,1,2) -> ");

                if (!gameController.HandlePlayerMove(currentPlayer, row, col))
                {
                    Console.WriteLine("Invalid move try again");
                    continue;
                }

                if (gameController.CheckWinner(currentPlayer))
                {
                    DisplayBoard();
                    Console.WriteLine($"Congratulations {currentPlayer.Name} ({currentPlayer.Symbol}) wins");
                    isGameOver = true;
                }
                else if (gameController.IsBoardFull())
                {
                    DisplayBoard();
                    Console.WriteLine("It is draw");
                    isGameOver = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }
            }
        }

        private static void DisplayBoard()
        {
            char[,] board = gameController.GetBoard();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int GetUserInput(string message)
        {
            int input;
            while (true)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();

                //try to convert the input string into integer and out means input will store the result means
                //TryParse returns two things means whether the conversion was successful then means true or false and actual value converted from string if successful and by using out TryParse can return both of these pieces of information simultaneously and the boolean valid tells us if the conversion suceeded and input variable stores the actual integer value if the conversion is valid
                bool valid = int.TryParse(userInput, out input);
                if (valid && input >= 0 && input <= 2)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input enter number between 0-2");
                }
            }
        }

        private static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.Write("\nDo you want to play again press y for yes or n for no -> ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input enter yes(y) or no(n)");
                }
            }
        }
    }
}