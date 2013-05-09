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
            int labyrinthSize = Labyrinth.LabyrinthSize;
            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    Cell cell = labyrinth.GetCell(row, col);
                    //Console.Write(cell.ValueChar + " ");
                    Console.Write(cell.ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
