using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Puzzle
    {
        public List<Square> Squares { get; set; }

        public Columns Columns { get; set; }

        public Rows Rows { get; set; }

        public NineSquares NineSquares { get; set; }


        public Puzzle(List<Square> squares)
        {
            Squares = new List<Square>();
            Columns = new Columns();
            Rows = new Rows();
            NineSquares = new NineSquares();


            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
            {
                var rowOfSquares = Rows.First(r => r.RowIndex == rowIndex);
                for (int colIndex = 0; colIndex < 9; colIndex++)
                {
                    var columnOfSquares = Columns.First(c => c.ColIndex == colIndex);
                    var nsColIndex = colIndex / 3;
                    var nsRowIndex = rowIndex / 3;
                    var nineSquare = NineSquares.First(ns => ns.ColIndex == nsColIndex && ns.RowIndex == nsRowIndex);
                    var square = new Square(rowIndex, colIndex);
                    Squares.Add(square);
                    rowOfSquares.Add(square);
                    columnOfSquares.Add(square);
                    nineSquare.Add(square);
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



        public string GetAllowedDigitsFormatted()
        {
            var output = string.Empty;
            var hSeparator = new string('-', 95) + "\n";
            var dhSeparator = new string('=', 95) + "\n";
            var vSeparator = "|";
            var dvSeparator = "||";

            for (int row = 0; row < 9; row++)
            {
                output += row % 3 == 0 ? dhSeparator : hSeparator;

                for (int internalRow = 0; internalRow < 3; internalRow++)
                {
                    var lineOutput = dvSeparator;
                    for (int col = 0; col < 9; col++)
                    {
                        var square = Squares.First(s => s.ColIndex == col && s.RowIndex == row);
                        var squareInternalRow = square.GetAllowedDigitsFormatted(internalRow);
                        lineOutput += square.GetAllowedDigitsFormatted(internalRow);
                        lineOutput += (col + 1) % 3 == 0 ? dvSeparator : vSeparator;
                    }
                    output += lineOutput + "\n";
                }
            }
            output += dhSeparator;
            return output;
        }


        public bool IsPuzzleSolved()
        {
            var allSet = true;
            Squares.ForEach(sq => allSet &= sq.IsSolved);
            return allSet;
        }

        public int GetNumberSolved()
        {
            return Squares.Count(sq => sq.IsSolved);
        }

        public Tuple<bool,int> TrySolvePuzzle(int iteration, int maxIterations)
        {
            var startTime = DateTime.Now;
            var lastNumberSolved = 0;
            var currentNumberSolved = GetNumberSolved();
            while ((iteration < maxIterations) && (!IsPuzzleSolved()) && (lastNumberSolved != currentNumberSolved))
            {
                iteration += 1;
                lastNumberSolved = currentNumberSolved;
                Columns.ForEach(col =>
                {
                    col.CheckForMatchesAndReduce();
                });

                Rows.ForEach(row =>
                {
                    row.CheckForMatchesAndReduce();
                });

                NineSquares.ForEach(ns =>
                {
                    ns.CheckForMatchesAndReduce();
                });

                currentNumberSolved = GetNumberSolved();
                Console.WriteLine($"Iteration {iteration} of {maxIterations} Solved {currentNumberSolved} of 81");
                Console.WriteLine(GetAllowedDigitsFormatted());
                Console.WriteLine("\n\n");
            }
            var endTime = DateTime.Now;
            Console.WriteLine($"Attempt took {endTime.Subtract(startTime).TotalMilliseconds} milliseconds");
            return new Tuple<bool,int>(IsPuzzleSolved(), iteration);
            
        }

    }
}
