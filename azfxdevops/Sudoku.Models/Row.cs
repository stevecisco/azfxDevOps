using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Row
    {
        public List<Square> Squares { get; set; }

        public int RowIndex { get; set; }

        public Row(int rowIndex)
        {
            Squares = new List<Square>();
            RowIndex = rowIndex;
        }
    }
}
