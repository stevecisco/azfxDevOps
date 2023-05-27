using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Rows : List<Row>
    {
        public Rows()
        {
            while (this.Count < 9) { this.Add(new Row(this.Count)); }
        }
    }
}
