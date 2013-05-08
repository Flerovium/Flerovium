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
    }
}
