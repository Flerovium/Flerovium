using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Playfield
    {
        public readonly int labyrinthSize = 7;
        private readonly int labyrintStartRow = 3;
        private readonly int labyrinthStartCol = 3;
        private Cell currentCell;
        private Cell[,] labyrinth;

        public Playfield()
        {
            this.GenerateLabyrinth();
            this.CurrentCell = this.labyrinth[this.labyrintStartRow, this.labyrintStartRow];
        }

        public Cell CurrentCell 
        {
            get
            {
                return this.currentCell;
            }

            set
            {
                this.currentCell = value;
            }
        }

        public Cell GetCell(int row, int col)
        {
            return this.labyrinth[row, col];
        }

        public void MakeMove(Cell cell, Direction direction)
        {
            int newRow;
            int newCol;

            this.FindNewCellCoordinates(cell, direction, out newRow, out newCol);

            if (newRow < 0 || newCol < 0 || newRow >= this.labyrinth.GetLength(0) || newCol >= this.labyrinth.GetLength(1))
            {
                return;
            }

            if (!this.labyrinth[newRow, newCol].IsEmpty())
            {
                return;
            }

            this.labyrinth[newRow, newCol].Type = CellType.Player;
            this.labyrinth[cell.Row, cell.Col].Type = CellType.Empty;
            this.CurrentCell = this.labyrinth[newRow, newCol];
        }

        public void FindNewCellCoordinates(Cell cell, Direction direction, out int newRow, out int newCol)
        {
            newRow = cell.Row;
            newCol = cell.Col;

            if (direction == Direction.Up)
            {
                newRow = newRow - 1;
            }
            else if (direction == Direction.Down)
            {
                newRow = newRow + 1;
            }
            else if (direction == Direction.Left)
            {
                newCol = newCol - 1;
            }
            else if (direction == Direction.Right)
            {
                newCol = newCol + 1;
            }
        }

        public bool IsPossibleDirection(int newRow, int newCol, HashSet<Cell> visitedCells)
        {
            bool isPossibleDirection = true;

            if (newRow < 0 || newCol < 0 || newRow >= this.labyrinth.GetLength(0) || newCol >= this.labyrinth.GetLength(1))
            {
                isPossibleDirection = false;
            }

            if (visitedCells.Contains(this.labyrinth[newRow, newCol]))
            {
                isPossibleDirection = false;
            }

            return isPossibleDirection;
        }

        public bool IsExitCell(Cell cell)
        {
            bool isExitCell = false;

            if (cell.Row == labyrinthSize - 1 || cell.Col == labyrinthSize - 1 || cell.Row == 0 || cell.Col == 0)
            {
                isExitCell = true;
            }

            return isExitCell;
        }

        public bool ExitPathExists()
        {
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = this.labyrinth[this.labyrintStartRow, this.labyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();
            List<Direction> directions = new List<Direction>()
            {
                Direction.Down,
                Direction.Up,
                Direction.Left,
                Direction.Right
            };
            bool pathExists = false;
            int newRow = 0;
            int newCol = 0;
            bool isPossibleCell = false;
            Cell newCell = null;

            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (this.IsExitCell(currentCell))
                {
                    pathExists = true;
                    break;
                }

                foreach (Direction direction in directions)
                {
                    FindNewCellCoordinates(currentCell, direction, out newRow, out newCol);
                    newCell = this.labyrinth[newRow, newCol];
                    isPossibleCell = this.IsPossibleDirection(newRow, newCol, visitedCells);
                    if (isPossibleCell && newCell.IsEmpty())
                    {
                        cellsOrder.Enqueue(newCell);
                    }
                }
            }

            return pathExists;
        }

        public void GenerateLabyrinth()
        {
            Random randomGenerator = new Random();

            this.labyrinth = new Cell[labyrinthSize, labyrinthSize];

            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    int cellRandomValue = randomGenerator.Next(0, 2);
                    CellType charValue;

                    if (cellRandomValue == 0)
                    {
                        charValue = CellType.Empty;
                    }
                    else
                    {
                        charValue = CellType.Wall;
                    }

                    this.labyrinth[row, col] = new Cell(row, col, charValue);
                }
            }

            this.labyrinth[this.labyrintStartRow, this.labyrinthStartCol].Type = CellType.Player;
            bool exitPathExists = this.ExitPathExists();

            if (!exitPathExists)
            {
                this.GenerateLabyrinth();
            }
        }

        public override string ToString()
        {
            StringBuilder buildLabyrint = new StringBuilder();
            int labyrinthSize = this.labyrinthSize;

            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    Cell cell = this.GetCell(row, col);
                    buildLabyrint.AppendFormat("{0} ", cell.ToString());
                }
                
                buildLabyrint.AppendFormat("\n");
            }

            return buildLabyrint.ToString();
        }
    }
}