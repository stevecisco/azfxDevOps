using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Column
    {
        public List<Square> Squares { get; set; }

        public int ColIndex { get; set; }

        public Column(int colIndex)
        {
            Squares = new List<Square>();
            ColIndex = colIndex;
        }
    }
}
