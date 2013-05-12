using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Game
    {
        private Labyrinth labyrinth;
        private ScoreBoard scoreboard;
        private IUserInterface keyboard;

        public Game(int scoreboardSize)
        {
            Labyrinth labyrinth = new Labyrinth();
            this.labyrinth = labyrinth;
            this.scoreboard = new ScoreBoard(scoreboardSize);
            this.keyboard = new KeyboardInterface();
        }

        public void RunGame ()
        {
            
            Drawer.PrintWelcomeMessage();
            int movesCount = 0;
            string input = "";

            while (!IsGameOver() && input != "restart")
            {
                Drawer.PrintLabyrinth(this.labyrinth);
                this.keyboard.ProcessInput();
                //ProccessInput(input, this.labyrinth, ref movesCount, scoreboard);
            }

            if (input != "restart")
            {
                Console.WriteLine("Congratulations! You escaped in {0} moves.", movesCount);
                if (scoreboard.IsInScoreboard(movesCount))
                {
                    Console.WriteLine(MenuMessages.EnterPlayerName);
                    string name = Console.ReadLine();
                    //ladder.AddResultInLadder(movesCount, name);
                    scoreboard.AddResult(movesCount, name);
                }
            }
            Console.WriteLine();
        }

        

        private bool IsGameOver()
        {
            bool isGameOver = false;
            int currentRow = this.labyrinth.CurrentCell.Row;
            int currentCol = this.labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == this.labyrinth.labyrinthSize - 1 ||
                currentCol == this.labyrinth.labyrinthSize - 1)
            {
                isGameOver = true;
            }
            return isGameOver;
        }

        private bool TryMove(string direction)
        {
            bool moveDone = false;
            switch (direction)
            {
                case "u":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);
                    break;
                case "d":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Down);
                    break;
                case "l":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);
                    break;
                case "r":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Right);
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

        private void ProccessInput(string input, Labyrinth labyrinth, ref int movesCount, ScoreBoard ladder)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    //fallthrough
                    bool moveDone = TryMove(inputToLower);
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