using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    internal class ScoreBoard
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
            internal set
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
            if (this.TopResults.Count == 0)
            {
                string emptyMessage = "The scoreboard is empty!";

                return emptyMessage;
            }
            else
            {
                StringBuilder scoreBoard = new StringBuilder();
                Result currentResult = null;

                for (int index = 0; index < topResults.Count; index++)
                {
                    currentResult = topResults[index];
                    scoreBoard.Append(string.Format("{0}. {1} --> {2} moves", index + 1,
                        currentResult.PlayerName, currentResult.MovesCount));
                }

                return scoreBoard.ToString();
            }
        }

        public bool IsInScoreboard(int result)
        {
            if (topResults.Count < this.topResults.Capacity)
            {
                return true;
            }

            if (result < topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        public void AddResult(int movesCount, string playerName)
        {
            Result result = new Result(movesCount, playerName);

            if (this.TopResults.Count == this.TopResults.Capacity)
            {
                this.TopResults[topResults.Count - 1] = result;
            }
            else
            {
                this.TopResults.Add(result);
            }

            topResults.Sort();
        }
    }
}