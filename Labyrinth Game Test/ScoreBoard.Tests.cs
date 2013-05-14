using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
using System.Collections.Generic;

namespace Labyrinth_Game_Test
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ScoreBoardSetNullResultsTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            scoreboard.TopResults = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ScoreBoardExceedCapacityResultsTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            Result result = null;
            List<Result> results = new List<Result>();

            for (int i = 0; i < scoreboard.TopResults.Capacity + 1; i++)
            {
                result = new Result(i, "Player" + i);
                results.Add(result);
            }

            scoreboard.TopResults = results;
        }

        [TestMethod]
        public void ScoreBoardSetResultsTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            Result result = null;
            List<Result> results = new List<Result>();

            for (int i = 0; i < scoreboard.TopResults.Capacity; i++)
            {
                result = new Result(i, "Player" + i);
                results.Add(result);
            }

            scoreboard.TopResults = results;
        }

        [TestMethod]
        public void ScoreBoardAddResultsTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            scoreboard.AddResult(5, "Player" + 5);
            scoreboard.AddResult(6, "Player" + 6);
            scoreboard.AddResult(2, "Player" + 2);
            scoreboard.AddResult(4, "Player" + 4);
            scoreboard.AddResult(7, "Player" + 7);
            scoreboard.AddResult(3, "Player" + 3);
            int actual = scoreboard.TopResults[1].MovesCount;

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void ScoreBoardNotAddedResultsTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            scoreboard.AddResult(5, "Player" + 5);
            scoreboard.AddResult(6, "Player" + 6);
            scoreboard.AddResult(2, "Player" + 2);
            scoreboard.AddResult(4, "Player" + 4);
            scoreboard.AddResult(7, "Player" + 7);
            scoreboard.AddResult(9, "Player" + 9);
            int actual = scoreboard.TopResults[4].MovesCount;

            Assert.AreEqual(7, actual);
        }

        [TestMethod]
        public void ScoreBoardEmptyToStringTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            string actual = scoreboard.ToString();

            Assert.AreEqual("Sorry, the scoreboard is empty.", actual);
        }

        [TestMethod]
        public void ScoreBoardToStringTest()
        {
            ScoreBoard scoreboard = new ScoreBoard(5);
            scoreboard.AddResult(5, "Player" + 5);
            scoreboard.AddResult(6, "Player" + 6);
            scoreboard.AddResult(2, "Player" + 2);
            scoreboard.AddResult(4, "Player" + 4);
            scoreboard.AddResult(7, "Player" + 7);
            string actual = scoreboard.ToString();
            string expected = "\n1. Player2 --> 2 moves\r\n2. Player4 --> 4 moves" +
                "\r\n3. Player5 --> 5 moves\r\n4. Player6 --> 6 moves\r\n5. Player7 --> 7 moves\r\n";

            Assert.AreEqual(expected, actual);
        }
    }
}