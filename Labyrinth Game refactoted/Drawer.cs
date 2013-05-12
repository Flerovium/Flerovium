using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public static class Drawer
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine(MenuMessages.Welcome);
        }
 
        public static void PrintLabyrinth(Labyrinth labyrinth)
        {
            Console.WriteLine(labyrinth.ToString());
        }
    }
}
