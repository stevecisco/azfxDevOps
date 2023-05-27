using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Columns : List<Column>
    {
        public Columns()
        {
            while (this.Count < 9) { this.Add(new Column(this.Count)); }
        }
    }
}
