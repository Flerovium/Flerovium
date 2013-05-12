using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(int moves, out int currentMoves)
        {
            currentMoves = moves;
            var keyInfo = Console.ReadKey();
            // if (Console.KeyAvailable)
            //{
            if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (this.OnLeftPressed != null)
                {
                    this.OnLeftPressed(this, new EventArgs());
                    currentMoves++;
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if (this.OnRightPressed != null)
                {
                    this.OnRightPressed(this, new EventArgs());
                    currentMoves++;
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (this.OnUpPressed != null)
                {
                    this.OnUpPressed(this, new EventArgs());
                    currentMoves++;
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if (this.OnDownPressed != null)
                {
                    this.OnDownPressed(this, new EventArgs());
                    currentMoves++;
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.R))
            {
                if (this.OnRestartPressed != null)
                {
                    this.OnRestartPressed(this, new EventArgs());
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.T))
            {
                if (this.OnTopScorePressed != null)
                {
                    this.OnTopScorePressed(this, new EventArgs());
                }
            }
            else if (keyInfo.Key.Equals(ConsoleKey.E))
            {
                if (this.OnExitPressed != null)
                {
                    this.OnExitPressed(this, new EventArgs());
                }
            }
            else
            {
                Console.WriteLine(MenuMessages.InvalidCommand);
            }
            // }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnRestartPressed;

        public event EventHandler OnExitPressed;

        public event EventHandler OnTopScorePressed;
    }
}