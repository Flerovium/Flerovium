using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public static class UserInput
    {
        public static string GetInput()
        {
            Console.Write(MenuMessages.EnterMove);
            string inputLine = Console.ReadLine();
            return inputLine;
        }

    }
}
