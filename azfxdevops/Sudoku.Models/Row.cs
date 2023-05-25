namespace Sudoku.Models
{
    public class Row : List<Square>
    {
        public int RowIndex { get; set; }

        public Row(int rowIndex)
        {
            RowIndex = rowIndex;
        }

        public new void Add(Square square)
        {
            base.Add(square);
            square.DigitSet += Square_DigitSet;
        }

        private void Square_DigitSet(object? sender, int e)
        {
            if (sender != null)
            {
                var sourceSquare = (Square)sender;
                foreach (var sq in this)
                {
                    if (!((sq.RowIndex == sourceSquare.RowIndex) && (sq.ColIndex == sourceSquare.ColIndex)))
                    {
                        sq.SetExcludedDigit(e);
                    }
                }
            }
        }

    }
}
