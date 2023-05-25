namespace Sudoku.Models
{
    public class Square
    {
        public event EventHandler<int> DigitSet;

        private bool[] _excludedDigits = new bool[9] { false, false, false, false, false, false, false, false, false};
        public void SetExcludedDigit(int digit)
        {
            if (digit < 1 || digit > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
            _excludedDigits[digit - 1] = true;
        }

        public bool GetExcludedDigitValue(int digit)
        {
            if (digit < 1 || digit > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
            return _excludedDigits[digit - 1];
        }


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

        protected virtual void OnDigitSet(int digit)
        {
            EventHandler<int> handler = DigitSet;
            if (handler != null)
            {
                handler(this, digit);
            }
        }

        public void Initialize(Square other)
        {
            if (other == null) return;
            if (other.Digit != null)
            {
                Digit = other.Digit;
            }
        }

        private int _digit;
        public int Digit
        {
            get => _digit;
            set
            {
                if (value < 1 || value > 9) throw new InvalidOperationException("Only digits 1 through 9 are allowed");
                _digit = value;
                for (int i = 0; i < 9; i++)
                {
                    if (i != (_digit - 1)) _excludedDigits[i] = true;
                }
                OnDigitSet(_digit);
            }
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

        private void CheckFOrDigitBasedOnExclusions()
        {
            List<int> allowedDigits = GetAllowedDigits();
            if (allowedDigits.Count == 1)
            {
                Digit = allowedDigits[0];
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