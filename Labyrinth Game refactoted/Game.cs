using System;
using System.Linq;

namespace Labyrinth
{
    public class Game
    {
        private Playfield labyrinth;
        private ScoreBoard scoreboard;
        private IUserInterface keyboard;
        private IDrawerInterface drawer;
        private int moves;

        #region Properties
        
        public IDrawerInterface Drawer
        {
            get
            {
                return this.drawer;
            }
            set
            {
                this.drawer = value;
            }
        }
        
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
        
        public Playfield Labyrinth
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
            this.labyrinth = new Playfield();
            this.scoreboard = new ScoreBoard(scoreboardSize);
            this.keyboard = new KeyboardInterface();
            this.moves = 0;
            this.drawer = new ConsoleDrawer();
        }
        
        public void Run()
        {
            this.Drawer.PrintWelcomeMessage();
            int movesCount = 0;
            
            while (!IsGameOver())
            {
                this.Drawer.Draw(this.Labyrinth);
                try
                {
                    this.keyboard.ProcessInput(this.Moves, out movesCount);
                    this.Moves = movesCount;
                }
                catch (ArgumentException)
                {
                    this.Drawer.PrintInvalidCommandMessage();
                }
            }
            
            this.Drawer.Draw(this.Labyrinth);
            this.Drawer.PrintMovesCountMessage(this.Moves);

            if (scoreboard.IsInScoreboard(this.Moves))
            {
                this.Drawer.PrintEnterPlayerName();
                string name = this.Keyboard.ReadPlayerName();
                scoreboard.AddResult(this.Moves, name);
            }

            this.Drawer.PrintEndOrNewGame();
            try
            {
                this.keyboard.ProcessInput(this.Moves, out movesCount);
            }
            catch (ArgumentException)
            {
                this.Drawer.PrintInvalidCommandMessage();
            }
        }
        
        private bool IsGameOver()
        {
            bool isGameOver = false;
            int currentRow = this.Labyrinth.CurrentCell.Row;
            int currentCol = this.Labyrinth.CurrentCell.Col;

            if (currentRow == 0 || currentCol == 0 || currentRow == this.Labyrinth.labyrinthSize - 1 ||
                currentCol == this.Labyrinth.labyrinthSize - 1)
            {
                isGameOver = true;
            }
            
            return isGameOver;
        }
        
        public void MoveLeft()
        {
            this.Labyrinth.MakeMove(this.Labyrinth.CurrentCell, Direction.Left);
        }

        public void MoveRight()
        {
            this.Labyrinth.MakeMove(this.Labyrinth.CurrentCell, Direction.Right);
        }

        public void MoveUp()
        {
            this.Labyrinth.MakeMove(this.Labyrinth.CurrentCell, Direction.Up);
        }

        public void MoveDown()
        {
            this.Labyrinth.MakeMove(this.Labyrinth.CurrentCell, Direction.Down);
        }

        public void GameRestart()
        {
            this.Labyrinth = new Playfield();
            this.Moves = 0;
            this.Run();
        }

        public void Exit()
        {
            this.Drawer.PrintGoodbyeMessage();
            Environment.Exit(0);
        }

        public void ShowTopScores()
        {
            this.Drawer.Draw(this.Scoreboard);
        }
    }
}