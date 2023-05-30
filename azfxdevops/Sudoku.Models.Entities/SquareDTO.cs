namespace Sudoku.Models.Entities
{
    public class SquareDTO
    {
        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public int? Digit { get; set; }

        public List<int> ExcludedDigits { get; set; }

        public SquareDTO()
        {
            ExcludedDigits = new List<int>();
        }

        public SquareDTO(int rowIndex, int colIndex, int? digit, List<int>? excludedDigits)
        {
            ExcludedDigits = new List<int>();
            RowIndex = rowIndex;
            ColIndex = colIndex;
            Digit = digit;
            if (excludedDigits != null && excludedDigits.Count > 0)
            {
                ExcludedDigits.AddRange(excludedDigits.Where(d => (d >= 1) && (d <= 9)).Distinct());
            }
        }
    }
}
