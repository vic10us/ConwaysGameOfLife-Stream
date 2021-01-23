using System;
using System.Collections.Generic;
using System.Text;

namespace Conway.Library
{
    public class Board
    {
        public readonly Cell[,] Cells;
        public readonly int CellSize;
        public int Columns => Cells.GetLength(0);
        public int Rows => Cells.GetLength(1);
        public int Width => Columns * CellSize;
        public int Height => Rows * CellSize;

        public Board(int width, int height, int cellSize, bool wrap = true)
        {
            
        }
    }
}
