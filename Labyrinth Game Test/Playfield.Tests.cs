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

        [TestMethod]
        public void MakeMoveUpTest()
        {
            Playfield testPlayfield = new Playfield();

            for (int i = 0; i < testPlayfield.labyrinthSize; i++)
            {
                for (int j = 0; j < testPlayfield.labyrinthSize; j++)
                {
                    if (!((i == 3) && (j == 3)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Empty);
                    }
                }
            }

            testPlayfield.MakeMove(testPlayfield.Labyrinth[3, 3], Direction.Up);
            Assert.AreEqual(testPlayfield.Labyrinth[2, 3].Type, CellType.Player);
        }

        [TestMethod]
        public void MakeMoveLeftTest()
        {
            Playfield testPlayfield = new Playfield();

            for (int i = 0; i < testPlayfield.labyrinthSize; i++)
            {
                for (int j = 0; j < testPlayfield.labyrinthSize; j++)
                {
                    if (!((i == 3) && (j == 3)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Empty);
                    }
                }
            }

            testPlayfield.MakeMove(testPlayfield.Labyrinth[3, 3], Direction.Left);
            Assert.AreEqual(testPlayfield.Labyrinth[3, 2].Type, CellType.Player);
        }

        [TestMethod]
        public void MakeMoveRightTest()
        {
            Playfield testPlayfield = new Playfield();

            for (int i = 0; i < testPlayfield.labyrinthSize; i++)
            {
                for (int j = 0; j < testPlayfield.labyrinthSize; j++)
                {
                    if (!((i == 3) && (j == 3)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Empty);
                    }
                }
            }

            testPlayfield.MakeMove(testPlayfield.Labyrinth[3, 3], Direction.Right);
            Assert.AreEqual(testPlayfield.Labyrinth[3, 4].Type, CellType.Player);
        }

        [TestMethod]
        public void MakeMoveDownTest()
        {
            Playfield testPlayfield = new Playfield();

            for (int i = 0; i < testPlayfield.labyrinthSize; i++)
            {
                for (int j = 0; j < testPlayfield.labyrinthSize; j++)
                {
                    if (!((i == 3) && (j == 3)))
                    {
                        testPlayfield.Labyrinth[i, j] = new Cell(i, j, CellType.Empty);
                    }
                }
            }

            testPlayfield.MakeMove(testPlayfield.Labyrinth[3, 3], Direction.Down);
            Assert.AreEqual(testPlayfield.Labyrinth[4, 3].Type, CellType.Player);
        }
    }
}
