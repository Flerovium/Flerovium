namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// represents the functionality of the game labyrinth
    /// </summary>
    public class Labyrinth
    {
        public const int LabyrinthSize = 7;
        private readonly int LabyrintStartRow = 3;
        private readonly int LabyrinthStartCol = 3;
        private Cell currentCell;
        private Cell[,] labyrinth;

        public Labyrinth(Random random)
        {
            this.GenerateLabyrinth(random);
            this.CurrentCell = this.labyrinth[this.LabyrintStartRow, this.LabyrintStartRow];
        }

        internal Cell CurrentCell 
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

        internal Cell GetCell(int row, int col)
        {
            return this.labyrinth[row, col];
        }

        /// <summary>
        /// moving the player to neighboring cell if possible
        /// </summary>
        internal bool TryMove(Cell cell, Direction direction)
        {
            int newRow;
            int newCol;
            this.FindNewCellCoordinates(cell.Row, cell.Col, direction, out newRow, out newCol);

            if (newRow < 0 || newCol < 0 || newRow >= this.labyrinth.GetLength(0) || newCol >= this.labyrinth.GetLength(1))
            {
                return false;
            }

            if (!this.labyrinth[newRow, newCol].IsEmpty())
            {
                return false;
            }

            this.labyrinth[newRow, newCol].Type = CellType.Player;
            this.labyrinth[cell.Row, cell.Col].Type = CellType.Empty;
            this.CurrentCell = this.labyrinth[newRow, newCol];

            return true;
        }

        private void FindNewCellCoordinates(int row, int col, Direction direction, out int newRow, out int newCol)
        {
            newRow = row;
            newCol = col;

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

        private void Move(Cell cell, Direction direction, Queue<Cell> cellsOrder, HashSet<Cell> visitedCells)
        {
            int newRow;
            int newCol;

            this.FindNewCellCoordinates(cell.Row, cell.Col, direction, out newRow, out newCol);

            if (newRow < 0 || newCol < 0 || newRow >= this.labyrinth.GetLength(0) || newCol >= this.labyrinth.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(this.labyrinth[newRow, newCol]))
            {
                return;
            }

            if (this.labyrinth[newRow, newCol].IsEmpty())
            {
                cellsOrder.Enqueue(this.labyrinth[newRow, newCol]);
            }
        }

        private bool ExitFound(Cell cell)
        {
            bool exitFound = false;

            if (cell.Row == LabyrinthSize - 1 || cell.Col == LabyrinthSize - 1 || cell.Row == 0 || cell.Col == 0)
            {
                exitFound = true;
            }

            return exitFound;
        }

        private bool ExitPathExists()
        {
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = this.labyrinth[this.LabyrintStartRow, this.LabyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();

            bool pathExists = false;
            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (this.ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                this.Move(currentCell, Direction.Down, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Up, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Left, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return pathExists;
        }

        private void GenerateLabyrinth(Random rand)
        {
            this.labyrinth = new Cell[LabyrinthSize, LabyrinthSize];

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int col = 0; col < LabyrinthSize; col++)
                {
                    int cellRandomValue = rand.Next(0, 2);
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

            this.labyrinth[this.LabyrintStartRow, this.LabyrinthStartCol].Type = CellType.Player;

            bool exitPathExists = this.ExitPathExists();

            if (!exitPathExists)
            {
                this.GenerateLabyrinth(rand);
            }
        }
    }
}
