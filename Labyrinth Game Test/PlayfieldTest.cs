using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
using System.Collections.Generic;

namespace Labyrinth_Game_Test
{
    [TestClass]
    public class PlayfieldTest
    {
        [TestMethod]
        public void StartRowTest()
        {
            Playfield playfield1 = new Playfield();
            Playfield playfield2 = new Playfield();
            Playfield playfield3 = new Playfield();

            Assert.AreEqual(playfield1.labyrintStartRow, 3);
            Assert.AreEqual(playfield2.labyrintStartRow, 3);
            Assert.AreEqual(playfield3.labyrintStartRow, 3);
        }

        [TestMethod]
        public void StartColTest()
        {
            Playfield playfield1 = new Playfield();
            Playfield playfield2 = new Playfield();
            Playfield playfield3 = new Playfield();

            Assert.AreEqual(playfield1.labyrinthStartCol, 3);
            Assert.AreEqual(playfield2.labyrinthStartCol, 3);
            Assert.AreEqual(playfield3.labyrinthStartCol, 3);
        }
    }
}
