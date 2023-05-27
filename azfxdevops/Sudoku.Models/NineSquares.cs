using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class NineSquares : List<NineSquare>
    {
        public NineSquares()
        {
            for (int nsRowIndex = 0; nsRowIndex < 3; nsRowIndex++)
            {
                for (int nsColIndex = 0; nsColIndex < 3; nsColIndex++)
                {
                    this.Add(new NineSquare(nsRowIndex, nsColIndex));
                }
            }
        }
    }
}
