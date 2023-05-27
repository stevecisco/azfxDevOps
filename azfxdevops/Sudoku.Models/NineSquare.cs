namespace Sudoku.Models
{
    public class NineSquare : SquareContainerBase
    {
        public int RowIndex { get; set; }

        public int ColIndex { get; set; }


        public NineSquare(int rowIndex, int colIndex) : base($"NS-R{rowIndex}C{colIndex}")
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
        }
    }
}
