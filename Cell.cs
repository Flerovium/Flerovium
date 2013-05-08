using System;
using System.Linq;

namespace Labyrinth
{
    public class Cell
    {
        private int row;
        private int col;
        private CellType type;

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.type = CellType.Empty;
        }

        public Cell(int row, int col, CellType type) 
        {
            this.Row = row;
            this.Col = col;
            this.type = type;
        }
        
        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cell Row is not allowed to be negative!");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cell Col is not allowed to be negative!");
                }

                this.col = value;
            }
        }

        public CellType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public bool IsEmpty()
        {
            if (this.Type == CellType.Empty)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string cellSymbol = null;

            if (this.Type == CellType.Wall)
            {
                cellSymbol = "#";

                return cellSymbol;
            }
            else if (this.type == CellType.Player)
            {
                cellSymbol = "*";

                return cellSymbol;
            }

            cellSymbol = "-";

            return cellSymbol;
        }
    }
}