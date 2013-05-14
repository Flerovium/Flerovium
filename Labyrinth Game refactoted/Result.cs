using System;
using System.Linq;

namespace Labyrinth
{
    public class Result : IComparable<Result>
    {
        private readonly int movesCount; 
        private readonly string playerName;

        public Result(int movesCount, string playerName)
        {
            this.movesCount = movesCount;
            this.playerName = playerName;
        }

        public int MovesCount 
        {
            get
            {
                return this.movesCount;
            }
        }

        public string PlayerName 
        {
            get
            {
                return this.playerName;
            }
        }

        public int CompareTo(Result other)
        {
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}