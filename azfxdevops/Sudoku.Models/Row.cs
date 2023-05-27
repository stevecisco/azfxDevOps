namespace Sudoku.Models
{
    public class Row : SquareContainerBase
    {
        public int RowIndex { get; set; }

        public Row(int rowIndex) : base($"ROW-{rowIndex}")
        {
            RowIndex = rowIndex;
        }
    }
}
