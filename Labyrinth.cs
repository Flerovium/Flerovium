using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Labyrinth
    {
        public const int LABYRINTH_SIZE = 7;
        
        //initial player's position
        private readonly int LabyrintStartRow = 3;
        private readonly int LabyrinthStartCol = 3;

        private Cell[,] labyrinth;
        public Cell currentCell;
        
        public Labyrinth(Random random)
        {
            GenerateLabyrinth(random);
            currentCell = labyrinth[LabyrintStartRow, LabyrintStartRow];
        }

        public Cell GetCell(int row, int col)
        {
            return labyrinth[row, col];
        }

        public bool TryMove(Cell cell, Direction direction)
        {
            int newRow;
            int newCol;
            FindNewCellCoordinates(cell.Row, cell.Col, direction, out newRow, out newCol);

            if (newRow < 0 || newCol < 0 || newRow >= labyrinth.GetLength(0) || newCol >= labyrinth.GetLength(1))
            {
                return false;
            }

            if (!labyrinth[newRow, newCol].IsEmpty())
            {
                return false;
            }

            this.labyrinth[newRow, newCol].Type = CellType.Player;
            this.labyrinth[cell.Row, cell.Col].Type = CellType.Empty;
            this.currentCell = labyrinth[newRow, newCol];
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

        private void premestvane(Cell cell, Direction direction, Queue<Cell> cellsOrder, HashSet<Cell> visitedCells)
        {
            int newRow;
            int newCol;
            FindNewCellCoordinates(cell.Row, cell.Col, direction, out newRow, out newCol);

            if (newRow < 0 || newCol < 0 || newRow >= labyrinth.GetLength(0) || newCol >= labyrinth.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(labyrinth[newRow,newCol]))
            {
                return;
            }

            if (labyrinth[newRow, newCol].IsEmpty())
            { 
                cellsOrder.Enqueue(labyrinth[newRow, newCol]);
            }
        }

        private bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            
            if (cell.Row == LABYRINTH_SIZE - 1 || cell.Col == LABYRINTH_SIZE - 1 || cell.Row == 0 || cell.Col == 0)
            {
                exitFound = true;
            }

            return exitFound;
        }

        private bool ExitPathExists()
        {
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = labyrinth[LabyrintStartRow, LabyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();
            bool pathExists = false;

            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                premestvane(currentCell, Direction.Down, cellsOrder, visitedCells);
                premestvane(currentCell, Direction.Up, cellsOrder, visitedCells);
                premestvane(currentCell, Direction.Left, cellsOrder, visitedCells);
                premestvane(currentCell, Direction.Right, cellsOrder, visitedCells);
            }
            return pathExists;
        }

        private void GenerateLabyrinth(Random random)
        {
            this.labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];

            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LABYRINTH_SIZE; col++)
                {
                    int cellRandomValue = random.Next(0, 2);
                    CellType charValue;
                    if (cellRandomValue == 0)
                    {
                        charValue = CellType.Empty;
                    }
                    else
                    {
                        charValue = CellType.Wall;
                    }

                    this.labyrinth[row,col] = new Cell(row, col, charValue);
                }
            }

            this.labyrinth[LabyrintStartRow, LabyrinthStartCol].Type = CellType.Player;
            bool exitPathExists = ExitPathExists();

            if (!exitPathExists)
            {
                GenerateLabyrinth(random);
            }
        }
    }
}
