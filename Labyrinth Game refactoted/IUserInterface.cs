using System;
using System.Linq;

namespace Labyrinth
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnRestartPressed;

        event EventHandler OnExitPressed;

        event EventHandler OnTopScorePressed;

        void ProcessInput();
    }
}
