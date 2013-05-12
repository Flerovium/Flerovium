using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth 
{
    public static class KeyboardInterface : IUserInterface
    {       
        public void ProcessInput()
        {            
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }
                
                else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs());
                    }
                }
                
                else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
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
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event  EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnRestartPressed;

        public event EventHandler OnExitPressed;

        public event EventHandler OnTopScorePressed;
    }
}
