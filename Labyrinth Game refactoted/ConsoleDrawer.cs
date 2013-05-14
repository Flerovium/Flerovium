using System;
using System.Linq;

namespace Labyrinth
{
    public class ConsoleDrawer : IDrawerInterface
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine(MenuMessages.Welcome);
        }

        public void PrintGoodbyeMessage()
        {
            Console.WriteLine(MenuMessages.Goodbye);
        }

        public void PrintInvalidCommandMessage()
        {
            Console.WriteLine(MenuMessages.InvalidCommand);
        }

        public void PrintMovesCountMessage(int moves)
        {
            Console.WriteLine(string.Format(MenuMessages.ShowMovesCount, moves));
        }

        public void PrintEnterPlayerName()
        {
            Console.WriteLine(MenuMessages.EnterPlayerName);
        }

        public void PrintEndOrNewGame()
        {
            Console.WriteLine(MenuMessages.EndOrNewGame);
        }
 
        public void Draw(object obj)
        {
            Console.WriteLine();
            Console.WriteLine(obj.ToString());
        }
    }
}