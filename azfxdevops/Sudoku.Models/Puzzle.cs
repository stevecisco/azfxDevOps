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

        public List<Column> Columns { get; set; }

        public List<Row> Rows { get; set; }

        public List<NineSquare> NineSquares { get; set; }


        private void InitPuzzle(List<Square> squares)
        {
            for (int colIndex = 0; colIndex < 9; colIndex++)
            {
                var colOfSquares = new Column(colIndex);
                Columns.Add(colOfSquares);
            }

            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
            {
                var rowOfSquares = new Row(rowIndex);
                Rows.Add(rowOfSquares);
            }

            for (int nsRowIndex = 0; nsRowIndex < 3; nsRowIndex++)
            {
                for (int nsColIndex = 0; nsColIndex < 3; nsColIndex++)
                {
                    var nineSquare = new NineSquare(nsRowIndex, nsColIndex);
                    NineSquares.Add(nineSquare);
                }
            }

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
                    rowOfSquares.Squares.Add(square);
                    columnOfSquares.Squares.Add(square);
                    nineSquare.Squares.Add(square);
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
            Columns = new List<Column>();
            Rows = new List<Row>();
            NineSquares = new List<NineSquare>();
            InitPuzzle(new List<Square>());
        }

        public Puzzle(List<Square> squares)
        {
            Squares = new List<Square>();
            Columns = new List<Column>();
            Rows = new List<Row>();
            NineSquares = new List<NineSquare>();
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
