using System;
using System.Linq;

namespace Labyrinth
{
    public class Game
    {
        private Labyrinth labyrinth;
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
            this.drawer = new ConsoleDrawer();
        }
        
        public void RunGame()
        {
            this.Drawer.PrintWelcomeMessage();
            int movesCount = 0;
            
            while (!IsGameOver())
            {
                this.Drawer.Draw(this.Labyrinth);
                this.keyboard.ProcessInput(this.Moves, out movesCount);
                this.Moves = movesCount;
                //Console.Clear();
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
            this.keyboard.ProcessInput(this.Moves, out movesCount);
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
            this.Drawer.PrintGoodbyeMessage();
            Environment.Exit(0);
        }
        
        internal void ShowTopScore()
        {
            this.Drawer.Draw(this.Scoreboard.ToString());
        }
    }
}