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
        private int moves;

        #region Properties
        public int Moves
        {
            get
            {
                return this.moves;
            }
            set
            {
                this.moves = value;
            }
        }

        public Labyrinth Labyrinth
        {
            get
            {
                return this.labyrinth;
            }
            set
            {
                this.labyrinth = value;
            }
        }

        public ScoreBoard Scoreboard
        {
            get
            {
                return this.scoreboard;
            }
            set
            {
                this.scoreboard = value;
            }
        }

        public IUserInterface Keyboard
        {
            get
            {
                return this.keyboard;
            }
            set
            {
                this.keyboard = value;
            }
        }
        #endregion

        public Game(int scoreboardSize)
        {
            this.labyrinth = new Labyrinth();
            this.scoreboard = new ScoreBoard(scoreboardSize);
            this.keyboard = new KeyboardInterface();
            this.moves = 0;
        }

        public void RunGame()
        {
            Drawer.PrintWelcomeMessage();
            int movesCount=0;
            //string input = "";

            while (!IsGameOver()) //&& input != "restart")
            {
                Drawer.Draw(this.labyrinth);
                //System.Threading.Thread.Sleep(500);
                this.keyboard.ProcessInput(this.Moves, out movesCount);
                this.Moves = movesCount;
                //ProccessInput(input, this.labyrinth, ref movesCount, scoreboard);
            }

            //if (input != "restart")
            //{
            Drawer.Draw(this.Labyrinth);
                Console.WriteLine("Congratulations! You escaped in {0} moves.", this.Moves);
                if (scoreboard.IsInScoreboard(this.Moves))
                {
                    Console.WriteLine(MenuMessages.EnterPlayerName);
                    string name = Console.ReadLine();
                    //ladder.AddResultInLadder(movesCount, name);
                    scoreboard.AddResult(this.Moves, name);
                    Console.WriteLine(MenuMessages.EndOrNewGame);
                    this.keyboard.ProcessInput(this.Moves, out movesCount);
                }
           // }
            Console.WriteLine();
        }

        private bool IsGameOver()
        {
            bool isGameOver = false;
            int currentRow = this.labyrinth.CurrentCell.Row;
            int currentCol = this.labyrinth.CurrentCell.Col;

            if (currentRow == 0 || currentCol == 0 || currentRow == this.labyrinth.labyrinthSize - 1 ||
                currentCol == this.labyrinth.labyrinthSize - 1)
            {
                isGameOver = true;
            }
            
            return isGameOver;
        }

        //private bool TryMove(string direction)
        //{
        //    bool moveDone = false;
        //    switch (direction)
        //    {
        //        case "u":
        //            moveDone =
        //                labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Up);
        //            break;
        //        case "d":
        //            moveDone =
        //                labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Down);
        //            break;
        //        case "l":
        //            moveDone =
        //                labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Left);
        //            break;
        //        case "r":
        //            moveDone =
        //                labyrinth.IsMovePossible(labyrinth.CurrentCell, Direction.Right);
        //            break;
        //        default:
        //            Console.WriteLine(MenuMessages.InvalidMove);
        //            break;
        //    }
        //    if (moveDone == false)
        //    {
        //        Console.WriteLine(MenuMessages.InvalidMove);
        //    }
        //    return moveDone;
        //}

        //private void ProccessInput(string input, Labyrinth labyrinth, ref int movesCount, ScoreBoard ladder)
        //{
        //    string inputToLower = input.ToLower();
        //    switch (inputToLower)
        //    {
        //        case "u":
        //        case "d":
        //        case "l":
        //        case "r":
        //            //fallthrough
        //            bool moveDone = TryMove(inputToLower);
        //            if (moveDone == true)
        //            {
        //                movesCount++;
        //            }
        //            break;
        //        case "top":
        //            //ladder.PrintLadder();
        //            Console.WriteLine(ladder.ToString());
        //            break;
        //        case "exit":
        //            Console.WriteLine(MenuMessages.Goodbye);
        //            Environment.Exit(0);
        //            break;
        //        case "restart":
        //            break;
        //        default:
        //            //string errorMessage = MenuMessages.InvalidCommand;
        //            Console.WriteLine(MenuMessages.InvalidCommand);
        //            break;
        //    }
        //}

        internal void MoveLeft()
        {
            this.labyrinth.MakeMove(labyrinth.CurrentCell, Direction.Left);
        }

        internal void MoveRight()
        {
            labyrinth.MakeMove(labyrinth.CurrentCell, Direction.Right);
        }

        internal void MoveUp()
        {
            labyrinth.MakeMove(labyrinth.CurrentCell, Direction.Up);
        }

        internal void MoveDown()
        {
            labyrinth.MakeMove(labyrinth.CurrentCell, Direction.Down);
        }

        internal void GameRestart()
        {
            this.labyrinth = new Labyrinth();
            this.Moves = 0;
            this.RunGame();
        }

        internal void Exit()
        {
            Console.WriteLine(MenuMessages.Goodbye);
            Environment.Exit(0);
        }

        internal void ShowTopScore()
        {
            Console.WriteLine(this.scoreboard.ToString());
        }
    }
}