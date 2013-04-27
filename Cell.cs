using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Cell
    {
        //Use enum CellType instead
        //public const char CELL_EMPTY_VALUE = '-';
        //public const char CELL_WALL_VALUE = 'X';
        //Create fields
        private int row;
        private int col;
        private CellType type;

        public Cell(int row, int col)//better using fields
        {
            this.row = row;
            this.col = col;
            this.type = CellType.Empty;
        }

        public Cell(int row, int col, CellType type) 
        {
            this.row = row;
            this.col = col;
            this.type = type;
        }
        
        //public int Row { get; set; }
        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }

        //public int Col { get; set; }
        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                this.col = value;
            }
        }

        //public char ValueChar { get; set; } 
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

        //public Cell(int row, int col, char value)
        //{
        //    this.Row = row;
        //    this.Col = col;
        //    this.ValueChar = value;
        //}

        public bool IsEmpty()
        {
            //if(this.ValueChar == CELL_EMPTY_VALUE)
            if (this.Type == CellType.Empty)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string wall = null;

            if (this.Type == CellType.Wall)
            {
                wall = "#";

                return wall;
            }
            else if (this.type == CellType.Player)
            {
                wall = "*";

                return wall;
            }

            wall = "-";

            return wall;
        }
    }
}