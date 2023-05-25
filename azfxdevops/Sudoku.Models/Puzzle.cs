using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Puzzle
    {
        public List<Square> Squares { get; set; }

        private void InitPuzzle(List<Square> squares)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var square = new Square(row, col);
                    Squares.Add(square);
                }
            }

            foreach (var square in squares)
            {
                var puzzleSquare = Squares.FirstOrDefault(s => s.RowIndex == square.RowIndex && s.ColIndex == square.ColIndex);
                if (puzzleSquare != null)
                {
                    puzzleSquare.Initialize(square);
                }
            }
        }

        public Puzzle()
        {
            Squares = new List<Square>();
            InitPuzzle(new List<Square>());
        }

        public Puzzle(List<Square> squares)
        {
            Squares = new List<Square>();
            InitPuzzle(squares);
        }


        public string GetAllowedDigits()
        {
            var output = string.Empty;
            var horizontalSeparator = new string('-', 95) + "\n";
            var doubleHorizontalSeparator = new string('=', 95) + "\n";
            for (int row = 0; row < 9; row++)
            {
                if ((row == 0) || (row == 3) || (row == 6))
                {
                    output += doubleHorizontalSeparator;
                }
                else
                {
                    output += horizontalSeparator;
                }

                for (int internalRow = 0; internalRow < 3; internalRow++)
                {
                    var lineOutput = String.Empty;
                    for (int col = 0; col < 9; col++)
                    {
                        var square = Squares.First(s => s.ColIndex == col && s.RowIndex == row);

                        lineOutput += square.GetAllowedDigits(internalRow);
                        if (col == 0)
                        {
                            lineOutput = "||" + lineOutput + "|";
                        }
                        else if (col < 8)
                        {
                            lineOutput += "|";
                            if ((col == 2) || (col == 5))
                            {
                                lineOutput += "|";
                            }
                        }
                    }
                    output += lineOutput + "||" + "\n";
                }
            }
            output += doubleHorizontalSeparator;
            return output;
        }
    }
}
