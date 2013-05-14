using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class ScoreBoard
    {
        private List<Result> topResults;

        public ScoreBoard(int topResultsCapacity)
        {
            topResults = new List<Result>();
            topResults.Capacity = topResultsCapacity;
        }

        public List<Result> TopResults
        {
            get
            {
                return this.topResults;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Top results can't be null!");
                }

                if (value.Count > this.TopResults.Capacity)
                {
                    throw new ArgumentException("Top results capacity is exceeded!");
                }

                this.topResults = value;
            }
        }

        public override string ToString()
        {
            string scoreBoardInfo = null;

            if (this.TopResults.Count == 0)
            {
                scoreBoardInfo = "\nThe scoreboard is empty!";
            }
            else
            {
                StringBuilder scoreBoard = new StringBuilder("\n");
                Result currentResult = null;

                for (int index = 0; index < topResults.Count; index++)
                {
                    currentResult = topResults[index];
                    scoreBoard.Append(string.Format("{0}. {1} --> {2} moves\n", index + 1,
                        currentResult.PlayerName, currentResult.MovesCount));
                }

                scoreBoardInfo = scoreBoard.ToString();
            }

            return scoreBoardInfo;
        }

        public bool IsInScoreboard(int result)
        {
            bool isInScoreboard = false;

            if (topResults.Count < this.topResults.Capacity)
            {
                isInScoreboard = true;
            }
            else if (result < topResults.Max().MovesCount)
            {
                isInScoreboard = true;
            }

            return isInScoreboard;
        }

        public void AddResult(int movesCount, string playerName)
        {
            Result result = new Result(movesCount, playerName);

            if (IsInScoreboard(movesCount))
            {
                if (this.TopResults.Count == this.TopResults.Capacity)
                {
                    this.TopResults[topResults.Count - 1] = result;
                }
                else
                {
                    this.TopResults.Add(result);
                }
            }

            topResults.Sort();
        }
    }
}