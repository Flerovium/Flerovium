using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Game
    {
        public Game(Random rand, ScoreBoard ladder)
        {
            Labyrinth labyrinth = new Labyrinth(rand);
            Drawer.PrintWelcomeMessage();
            int movesCount = 0;
            string input = "";

            while (!IsGameOver(labyrinth) && input != "restart")
            {
                Drawer.PrintLabyrinth(labyrinth);
                input = UserInput.GetInput();
                ProccessInput(input, labyrinth, ref movesCount, ladder);
            }

            if (input != "restart")
            {
                Console.WriteLine("Congratulations! You escaped in {0} moves.", movesCount);
                if (ladder.IsInScoreboard(movesCount))
                {
                    Console.WriteLine(MenuMessages.EnterPlayerName);
                    string name = Console.ReadLine();
                    //ladder.AddResultInLadder(movesCount, name);
                    ladder.AddResult(movesCount, name);
                }
            }
            Console.WriteLine();
        }

        private bool IsGameOver(Labyrinth labyrinth)
        {
            bool isGameOver = false;
            int currentRow = labyrinth.CurrentCell.Row;
            int currentCol = labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Labyrinth.LabyrinthSize - 1 ||
                currentCol == Labyrinth.LabyrinthSize - 1)
            {
                isGameOver = true;
            }
            return isGameOver;
        }

        private bool TryMove(string direction, Labyrinth labyrinth)
        {
            bool moveDone = false;
            switch (direction)
            {
                case "u":
                    moveDone =
                        labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Up);
                    break;
                case "d":
                    moveDone =
                        labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Down);
                    break;
                case "l":
                    moveDone =
                        labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Left);
                    break;
                case "r":
                    moveDone =
                        labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Right);
                    break;
                default:
                    Console.WriteLine(MenuMessages.InvalidMove);
                    break;
            }
            if (moveDone == false)
            {
                Console.WriteLine(MenuMessages.InvalidMove);
            }
            return moveDone;
        }

        private void ProccessInput(string input, Labyrinth labyrinth,
            ref int movesCount, ScoreBoard ladder)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    //fallthrough
                    bool moveDone =
                        TryMove(inputToLower, labyrinth);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    break;
                case "top":
                    //ladder.PrintLadder();
                    Console.WriteLine(ladder.ToString());
                    break;
                case "exit":
                    Console.WriteLine(MenuMessages.Goodbye);
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    //string errorMessage = MenuMessages.InvalidCommand;
                    Console.WriteLine(MenuMessages.InvalidCommand);
                    break;
            }
        }
    }
}