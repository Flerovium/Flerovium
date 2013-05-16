using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
using System.IO;


namespace Labyrinth_Game_Test
{
    [TestClass]
    public class ConsoleDrawerTests
    {
        [TestMethod]
        public void PrintWelcomeMessageTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();

            StringWriter stringWriter = new StringWriter();
            TextWriter  originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintWelcomeMessage();

            string actual = stringWriter.ToString();
            string expected = "\r\nWelcome to “Labirinth” game! You should try to escape from it."+
                "\r\nThe '*' is the player, the '#' are the walls of labyrinth."+
                " You should try to go through the '-' to some of the ends of the labyrinth."+
                "\r\nUse:\r\n- 't' to view the top scoreboard, \r\n- 'r' to start a new game\r\n- 'e' to quit\r\n";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintGoodbyeMessageTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            string expected = "\r\nGoodbye!\r\n";

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintGoodbyeMessage();

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintInvalidCommandMessageTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            string expected = "\r\nInvalid command! \r\nUse:\t\r\n- 't' to view the top scoreboard,"+
                "\t\r\n- 'r' to start a new game\t\r\n- 'e' to quit the game.\t\r\n- the arrows for the directions\r\n";

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintInvalidCommandMessage();

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintMovesCountMessageTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            string expected = "\r\nCongratulations! You escaped in 5 moves.\r\n";

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintMovesCountMessage(5);

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintEnterPlayerNameTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            string expected = "Please enter your name for the top scoreboard:\r\n";

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintEnterPlayerName();

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintEndOrNewGameTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            string expected = "If you want to continue, you can enter \"r\" for restart the game or \"e\" for exit.\r\n";

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            drawer.PrintEndOrNewGame();

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawTest()
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            Playfield testPlayfield = new Playfield();

            for (int i = 0; i < testPlayfield.labyrinthSize; i++)
            {
                for (int j = 0; j < testPlayfield.labyrinthSize; j++)
                {
                    if (((i == 3) && (j == 3)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Player);
                    }
                    else if (((i % 7 == 0) && (j % 7 == 0)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Wall);
                    }
                    else
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Empty);
                    }
                }
            }

            string expected = "\r\n" + testPlayfield.ToString();

            StringWriter stringWriter = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(stringWriter);
            drawer.Draw(testPlayfield);

            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
