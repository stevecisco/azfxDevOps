namespace Sudoku.Models
{
    public class Square
    {
        public bool OneExcluded { get; set; }
        public bool TwoExcluded { get; set; }
        public bool ThreeExcluded { get; set; }
        public bool FourExcluded { get; set; }
        public bool FiveExcluded { get; set; }
        public bool SixExcluded { get; set; }
        public bool SevenExcluded { get; set; }
        public bool EightExcluded { get; set; }
        public bool NineExcluded { get; set; }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public Square(int rowIndex, int colIndex) 
        {
            if (rowIndex < 0) throw new ArgumentOutOfRangeException(nameof(rowIndex));
            if (colIndex < 0) throw new ArgumentOutOfRangeException(nameof(colIndex));
            if (rowIndex > 8) throw new ArgumentOutOfRangeException(nameof(rowIndex));
            if (colIndex > 8) throw new ArgumentOutOfRangeException(nameof(ColIndex));

            RowIndex = rowIndex;
            ColIndex = colIndex;
        }

        public void Initialize(Square other)
        {
            if (other == null) return;
            if (other.Digit != null)
            {
                Digit = other.Digit;
            }
            else
            {
                OneExcluded = other.OneExcluded;
                TwoExcluded = other.TwoExcluded;
                ThreeExcluded = other.ThreeExcluded;
                FourExcluded = other.FourExcluded;
                FiveExcluded = other.FiveExcluded;
                SixExcluded = other.SixExcluded;
                SevenExcluded = other.SevenExcluded;
                EightExcluded = other.EightExcluded;
                NineExcluded = other.NineExcluded;
            }
        }

        private int? _digit;
        public int? Digit
        {
            get => _digit;
            set
            {
                if (value < 1 || value > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
                _digit = value;
                OneExcluded = _digit != 1;
                TwoExcluded = _digit != 2;
                ThreeExcluded = _digit != 3;
                FourExcluded = _digit != 4;
                FiveExcluded = _digit != 5;
                SixExcluded = _digit != 6;
                SevenExcluded = _digit != 7;
                EightExcluded = _digit != 8;
                NineExcluded = _digit != 9;
            }
        }

        public string GetAllowedDigits(int? internalRow)
        {
            if (internalRow.HasValue)
            {
                if (internalRow < 0 || internalRow > 2) throw new ArgumentOutOfRangeException(nameof(internalRow));
            }
            var output = string.Empty;
            
            if (internalRow == null || internalRow == 0) 
            {
                output += OneExcluded ? "   " : " 1 ";
                output += TwoExcluded ? "   " : " 2 ";
                output += ThreeExcluded ? "   " : " 3 ";
                if (internalRow == null)
                {
                    output += "\n";
                }
            }

            if (internalRow == null || internalRow == 1)
            {
                output += FourExcluded ? "   " : " 4 ";
                output += FiveExcluded ? "   " : " 5 ";
                output += SixExcluded ? "   " : " 6 ";
                if (internalRow == null)
                {
                    output += "\n";
                }
            }
            if (internalRow == null || internalRow == 2)
            {
                output += SevenExcluded ? "   " : " 7 ";
                output += EightExcluded ? "   " : " 8 ";
                output += NineExcluded ? "   " : " 9 ";
            }
            if (OneExcluded && TwoExcluded && ThreeExcluded && FourExcluded && FiveExcluded && SixExcluded && SevenExcluded && EightExcluded && NineExcluded)
            {
                throw new InvalidOperationException("ERROR: All the numbers can't be excluded");
            }
            return output;
        }


    }
}