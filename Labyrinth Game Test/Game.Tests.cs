using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
using System.IO;

namespace Labyrinth_Game_Test
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void ConstructorTest()
        {
            Game newGame = new Game(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorNegativeTest()
        {
            Game newGame = new Game(-5);
        }
    }
}