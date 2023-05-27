namespace Sudoku.Models
{
    public class Column : SquareContainerBase
    {
        public int ColIndex { get; set; }

        public Column(int colIndex) : base($"COL-{colIndex}")
        {
            ColIndex = colIndex;
        }
    }
}
