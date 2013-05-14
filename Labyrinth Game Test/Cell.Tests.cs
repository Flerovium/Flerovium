using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;

namespace Labyrinth_Game_Test
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CellWithNegativeRow()
        {
            Cell cell = new Cell(-1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CellWithNegativeCol()
        {
            Cell cell = new Cell(0, -1);
        }

        [TestMethod]
        public void CellIsEmptyTest()
        {
            Cell cell = new Cell(0, 0);
            bool actual = cell.IsEmpty();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CellIsNotEmptyTest()
        {
            Cell cell = new Cell(0, 0, CellType.Wall);
            bool actual = cell.IsEmpty();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CellSetTypeTest()
        {
            Cell cell = new Cell(0, 0);
            cell.Type = CellType.Wall;

            Assert.AreEqual(CellType.Wall,cell.Type);
        }

        [TestMethod]
        public void CellSetRowTest()
        {
            Cell cell = new Cell(0, 0);
            cell.Row = 5;

            Assert.AreEqual(5, cell.Row);
        }

        [TestMethod]
        public void CellSetColTest()
        {
            Cell cell = new Cell(0, 0);
            cell.Col = 5;

            Assert.AreEqual(5, cell.Col);
        }

        [TestMethod]
        public void CellWallToStringTest()
        {
            Cell cell = new Cell(0, 0, CellType.Wall);
            string actual = cell.ToString();

            Assert.AreEqual("#", actual);
        }

        [TestMethod]
        public void CellPlayerToStringTest()
        {
            Cell cell = new Cell(0, 0, CellType.Player);
            string actual = cell.ToString();

            Assert.AreEqual("*", actual);
        }

        [TestMethod]
        public void CellEmptyToStringTest()
        {
            Cell cell = new Cell(0, 0);
            string actual = cell.ToString();

            Assert.AreEqual("-", actual);
        }
    }
}
