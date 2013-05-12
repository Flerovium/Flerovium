using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{

    // smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    class LabTest
    {
        const int TOP_RESULTS_CAPACITY = 5;
        static void Main()
        {
            Game game = new Game(TOP_RESULTS_CAPACITY);

            game.Keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                game.MoveLeft();
            };

            game.Keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                game.MoveRight();
            };

            game.Keyboard.OnUpPressed += (sender, eventInfo) =>
            {
                game.MoveUp();
            };

            game.Keyboard.OnDownPressed += (sender, eventInfo) =>
            {
                game.MoveDown();
            };

            game.Keyboard.OnRestartPressed += (sender, eventInfo) =>
            {
                game.GameRestart();
            };

            game.Keyboard.OnExitPressed += (sender, eventInfo) =>
            {
                game.Exit();
            };

            game.Keyboard.OnTopScorePressed += (sender, eventInfo) =>
            {
                game.ShowTopScore();
            };

            game.RunGame();

        }
    }
}
