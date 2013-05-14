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
            this.Type = CellType.Empty;
        }

        public Cell(int row, int col, CellType type) 
        {
            this.Row = row;
            this.Col = col;
            this.Type = type;
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
            bool isEmpty = false;

            if (this.Type == CellType.Empty)
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        public override string ToString()
        {
            string cellSymbol = null;

            if (this.Type == CellType.Wall)
            {
                cellSymbol = "#";
            }
            else if (this.Type == CellType.Player)
            {
                cellSymbol = "*";
            }
            else
            {
                cellSymbol = "-";
            }
            
            return cellSymbol;
        }
    }
}