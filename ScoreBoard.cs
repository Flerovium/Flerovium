using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class ScoreBoard
    {
        //private const int TOP_RESULTS_CAPACITY = 5;
        private List<Result> topResults;

        //public ScoreBoard()initialize capacity
        public ScoreBoard(int topResultsCapacity)
        {
            topResults = new List<Result>();
            topResults.Capacity = topResultsCapacity;
            //topResults.Capacity = TOP_RESULTS_CAPACITY;
        }

        public List<Result> TopResults
        {
            get
            {
                return this.topResults;
            }
            set
            {
                this.topResults = value;
            }
        }

        //public void PrintLadder()
        public override string ToString()
        {
            //if (topResults.Count == 0)
            if (this.TopResults.Count == 0)
            {
               // Console.WriteLine(UserInputAndOutput.SCOREBOARD_EMPTY_MSG);
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
                        currentResult.PlayerName,currentResult.MovesCount));
                    //Console.WriteLine("{0}. {1} --> {2} moves", index + 1,
                    //    topResults[index].PlayerName, topResults[index].MovesCount);
                }

                return scoreBoard.ToString();
            }
        }

        //public bool ResultQualifiesInLadder(int result)
        public bool IsInScoreboard(int result)
        {
            //if (topResults.Count < TOP_RESULTS_CAPACITY )
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

        //public void AddResultInLadder(int movesCount, string playerName)
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
