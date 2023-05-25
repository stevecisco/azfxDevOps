using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class NineSquare
    {
        public List<Square> Squares { get; set; }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }


        public NineSquare(int rowIndex, int colIndex)
        {
            Squares = new List<Square>();
            RowIndex = rowIndex;
            ColIndex = colIndex;

        }
    }
}
