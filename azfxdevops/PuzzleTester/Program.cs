using Microsoft.VisualBasic;
using Sudoku.Models;

namespace PuzzleTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var squares = new List<Square>();
            squares.Add(new Square(0, 3, 8));
            squares.Add(new Square(0, 8, 9));
            squares.Add(new Square(1, 1, 1));
            squares.Add(new Square(1, 2, 9));
            squares.Add(new Square(1, 5, 5));
            squares.Add(new Square(1, 6, 8));
            squares.Add(new Square(1, 7, 3));
            squares.Add(new Square(2, 1, 4));
            squares.Add(new Square(2, 2, 3));
            squares.Add(new Square(2, 4, 1));
            squares.Add(new Square(2, 8, 7));
            squares.Add(new Square(3, 0, 4));
            squares.Add(new Square(3, 3, 1));
            squares.Add(new Square(3, 4, 5));
            squares.Add(new Square(3, 8, 3));
            squares.Add(new Square(4, 2, 2));
            squares.Add(new Square(4, 3, 7));
            squares.Add(new Square(4, 5, 4));
            squares.Add(new Square(4, 7, 1));
            squares.Add(new Square(5, 1, 8));
            squares.Add(new Square(5, 4, 9));
            squares.Add(new Square(5, 6, 6));
            squares.Add(new Square(6, 1, 7));
            squares.Add(new Square(6, 5, 6));
            squares.Add(new Square(6, 6, 3));
            squares.Add(new Square(7, 1, 3));
            squares.Add(new Square(7, 4, 7));
            squares.Add(new Square(7, 7, 8));
            squares.Add(new Square(8, 0, 9));
            squares.Add(new Square(8, 2, 4));
            squares.Add(new Square(8, 3, 5));
            squares.Add(new Square(8, 8, 1));

            var realPuzzle = new Puzzle(squares);

            int maxIterations = 100;

            Console.WriteLine($"Iteration 0 of {maxIterations} Solved {realPuzzle.GetNumberSolved()} of 81");
            Console.WriteLine(realPuzzle.GetAllowedDigitsFormatted());
            Console.WriteLine("\n\n");

            var results = realPuzzle.TrySolvePuzzle(0, maxIterations);
        }
    }
}