using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
using System.Linq;
using System.IO;

namespace Labyrinth_Game_Test
{
    [TestClass]
    public class KeyboardInterfaceTests
    {
        bool passed = false;

        [TestMethod]
        public void ProcessInputDownArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnDownPressed += keyboardReader_OnDownPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false));
            Assert.AreEqual(true, passed);
            passed = false;
        }

        [TestMethod]
        public void ProcessInputOnLeftArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnLeftPressed += keyboardReader_OnLeftPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false));

            Assert.AreEqual(true, passed);
        }

        [TestMethod]
        public void ProcessInputOnRightArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnRightPressed += keyboardReader_OnRightPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.RightArrow, false, false, false));

            Assert.AreEqual(true, passed);
        }

        [TestMethod]
        public void ProcessInputOnUpArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnUpPressed += keyboardReader_OnUpPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false));

            Assert.AreEqual(true, passed);
        }

        [TestMethod]
        public void ProcessInputOnRestartArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnRestartPressed += keyboardReader_OnRestartPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.R, false, false, false));

            Assert.AreEqual(true, passed);
        }

        [TestMethod]
        public void ProcessInputOnTopScoreArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnTopScorePressed += keyboardReader_OnTopScorePressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.T, false, false, false));

            Assert.AreEqual(true, passed);
        }
        [TestMethod]
        public void ProcessInputOnExitArrowTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();
            keyboardReader.OnExitPressed += keyboardReader_OnExitPressed;

            passed = false;
            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false));

            Assert.AreEqual(true, passed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInputInvalidInputTest()
        {
            int currentMoves = 0;
            KeyboardInterface keyboardReader = new KeyboardInterface();

            keyboardReader.ProcessInput(0, out currentMoves, new ConsoleKeyInfo(' ', ConsoleKey.J, false, false, false));
        }

        [TestMethod]
        public void ReadPlayerNameTest()
        {
            KeyboardInterface consoleReader = new KeyboardInterface();
            string expected = "Ivancho";

            StringReader stringReader = new StringReader(expected);
            TextReader originalInput = Console.In;
            Console.SetIn(stringReader);

            string actual = consoleReader.ReadPlayerName();
            Assert.AreEqual(expected, actual);
        }

        
        private void keyboardReader_OnLeftPressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnDownPressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnRightPressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnUpPressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnRestartPressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnTopScorePressed(object sender, EventArgs e)
        {
            passed = true;
        }

        private void keyboardReader_OnExitPressed(object sender, EventArgs e)
        {
            passed = true;
        }
    }
}
