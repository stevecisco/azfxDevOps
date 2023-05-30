namespace Sudoku.Models
{
    public class Square
    {
        public event EventHandler<int> DigitSet;

        private bool[] _excludedDigits = new bool[9] { false, false, false, false, false, false, false, false, false };


        public string Identifier { get; private set; }

        public bool IsSolved { get => Digit > 0; }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public Square(int rowIndex, int colIndex, int? digit = null)
        {
            if (rowIndex < 0) throw new ArgumentOutOfRangeException(nameof(rowIndex));
            if (colIndex < 0) throw new ArgumentOutOfRangeException(nameof(colIndex));
            if (rowIndex > 8) throw new ArgumentOutOfRangeException(nameof(rowIndex));
            if (colIndex > 8) throw new ArgumentOutOfRangeException(nameof(colIndex));

            RowIndex = rowIndex;
            ColIndex = colIndex;
            if (digit != null)
            {
                Digit = digit.Value;
            }
            Identifier = $"SQ-R{rowIndex}C{colIndex}";
        }


        
        public void SetExcludedDigits(List<int> digits)
        {
            if (digits.Any(digit => ((digit < 1) || (digit > 9)))) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
            digits.ForEach(digit =>
            {
                if (!IsDigitExcluded(digit))
                {
                    _excludedDigits[digit - 1] = true;
                }
            });
            var allowedDigits = GetAllowedDigits();
            if (allowedDigits.Count == 1)
            {
                Digit = allowedDigits[0];
            }
        }

        public bool IsDigitExcluded(int digit)
        {
            if (digit < 1 || digit > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
            return _excludedDigits[digit - 1];
        }


        protected virtual void OnDigitSet(int digit)
        {
            EventHandler<int> handler = DigitSet;
            if (handler != null)
            {
                handler(this, digit);
            }
        }


        private int _digit;
        public int Digit
        {
            get => _digit;
            set
            {
                if (value < 1 || value > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
                var fireEvent = _digit != value;
                _digit = value;
                for (int i = 0; i < 9; i++)
                {
                    if (i != (_digit - 1)) _excludedDigits[i] = true;
                }
                if (fireEvent) OnDigitSet(_digit);
            }
        }


        public string GetAllowedDigitsPacked()
        {
            var digits = GetAllowedDigits();
            var tempDigits = string.Empty;
            digits.ForEach(d => tempDigits += d);
            if (string.IsNullOrEmpty(tempDigits)) throw new InvalidOperationException("Invalid model state no digits allowed");
            return tempDigits;
        }

        public List<int> GetAllowedDigits()
        {
            var allowedDigits = new List<int>();
            for (int i = 0; i < _excludedDigits.Length; i++)
            {
                if (!_excludedDigits[i]) allowedDigits.Add((i + 1));
            }
            return allowedDigits;
        }


        public string GetAllowedDigitsFormatted(int? internalRow)
        {
            if (internalRow.HasValue)
            {
                if (internalRow < 0 || internalRow > 2) throw new ArgumentOutOfRangeException(nameof(internalRow));
            }
            var output = string.Empty;
            
            if (internalRow == null || internalRow == 0) 
            {
                output += _excludedDigits[0] ? "   " : " 1 ";
                output += _excludedDigits[1] ? "   " : " 2 ";
                output += _excludedDigits[2] ? "   " : " 3 ";
                if (internalRow == null)
                {
                    output += "\n";
                }
            }

            if (internalRow == null || internalRow == 1)
            {
                output += _excludedDigits[3] ? "   " : " 4 ";
                output += _excludedDigits[4] ? "   " : " 5 ";
                output += _excludedDigits[5] ? "   " : " 6 ";
                if (internalRow == null)
                {
                    output += "\n";
                }
            }
            if (internalRow == null || internalRow == 2)
            {
                output += _excludedDigits[6] ? "   " : " 7 ";
                output += _excludedDigits[7] ? "   " : " 8 ";
                output += _excludedDigits[8] ? "   " : " 9 ";
            }
            if (_excludedDigits.All(d => d))
            {
                throw new InvalidOperationException("ERROR: All the numbers can't be excluded");
            }
            return output;
        }


    }
}