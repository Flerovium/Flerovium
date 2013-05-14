using System;
using System.Linq;

namespace Labyrinth
{
    public interface IDrawerInterface
    {
        void PrintWelcomeMessage();
        void Draw(object obj);
        void PrintEnterPlayerName();
        void PrintEndOrNewGame();
        void PrintGoodbyeMessage();
        void PrintMovesCountMessage(int moves);
    }
}
