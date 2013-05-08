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
    }
}