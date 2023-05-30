using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Sudoku.Models;
using Sudoku.Models.Entities;

namespace PuzzleTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var squares = new List<SquareDTO>();
            squares.Add(new SquareDTO(0, 3, 8, null));
            squares.Add(new SquareDTO(0, 8, 9, null));
            squares.Add(new SquareDTO(1, 1, 1, null));
            squares.Add(new SquareDTO(1, 2, 9, null));
            squares.Add(new SquareDTO(1, 5, 5, null));
            squares.Add(new SquareDTO(1, 6, 8, null));
            squares.Add(new SquareDTO(1, 7, 3, null));
            squares.Add(new SquareDTO(2, 1, 4, null));
            squares.Add(new SquareDTO(2, 2, 3, null));
            squares.Add(new SquareDTO(2, 4, 1, null));
            squares.Add(new SquareDTO(2, 8, 7, null));
            squares.Add(new SquareDTO(3, 0, 4, null));
            squares.Add(new SquareDTO(3, 3, 1, null));
            squares.Add(new SquareDTO(3, 4, 5, null));
            squares.Add(new SquareDTO(3, 8, 3, null));
            squares.Add(new SquareDTO(4, 2, 2, null));
            squares.Add(new SquareDTO(4, 3, 7, null));
            squares.Add(new SquareDTO(4, 5, 4, null));
            squares.Add(new SquareDTO(4, 7, 1, null));
            squares.Add(new SquareDTO(5, 1, 8, null));
            squares.Add(new SquareDTO(5, 4, 9, null));
            squares.Add(new SquareDTO(5, 6, 6, null));
            squares.Add(new SquareDTO(6, 1, 7, null));
            squares.Add(new SquareDTO(6, 5, 6, null));
            squares.Add(new SquareDTO(6, 6, 3, null));
            squares.Add(new SquareDTO(7, 1, 3, null));
            squares.Add(new SquareDTO(7, 4, 7, null));
            squares.Add(new SquareDTO(7, 7, 8, null));
            squares.Add(new SquareDTO(8, 0, 9, null));
            squares.Add(new SquareDTO(8, 2, 4, null));
            squares.Add(new SquareDTO(8, 3, 5, null));
            squares.Add(new SquareDTO(8, 8, 1, null));

            var squaresJson = JsonConvert.SerializeObject(squares);
            var realPuzzle = new Puzzle(squares);

            int maxIterations = 100;

            Console.WriteLine($"Iteration 0 of {maxIterations} Solved {realPuzzle.GetNumberSolved()} of 81");
            Console.WriteLine(realPuzzle.GetAllowedDigitsFormatted());
            Console.WriteLine("\n\n");

            var results = realPuzzle.TrySolvePuzzle(0, maxIterations);
        }
    }
}