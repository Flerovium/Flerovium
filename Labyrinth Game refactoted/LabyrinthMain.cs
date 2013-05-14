using System;
using System.Linq;

namespace Labyrinth
{
    public class LabyrinthMain
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
                game.ShowTopScores();
            };

            game.Run();
        }
    }
}