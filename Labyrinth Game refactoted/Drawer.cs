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
            Console.WriteLine();
            Console.WriteLine(MenuMessages.Welcome);
        }
 
        public static void Draw(object obj)
        {
            Console.WriteLine();
            Console.WriteLine(obj.ToString());
        }
    }
}
