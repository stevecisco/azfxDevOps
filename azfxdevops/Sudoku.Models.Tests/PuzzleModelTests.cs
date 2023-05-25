using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models.Tests
{
    [TestClass]
    public class PuzzleModelTests
    {
        [TestMethod]
        public void TestPuzzleAllowedDigits()
        {
            var puzzle = new Puzzle();
            Console.WriteLine(puzzle.GetAllowedDigits());

            var squares = new List<Square>();
            squares.Add(new Square(0, 3) { Digit = 8 });
            squares.Add(new Square(0, 8) { Digit = 9 });
            squares.Add(new Square(1, 1) { Digit = 1 });
            squares.Add(new Square(1, 2) { Digit = 9 });
            squares.Add(new Square(1, 5) { Digit = 5 });
            squares.Add(new Square(1, 6) { Digit = 8 });
            squares.Add(new Square(1, 7) { Digit = 3 });
            squares.Add(new Square(2, 1) { Digit = 4 });
            squares.Add(new Square(2, 2) { Digit = 3 });
            squares.Add(new Square(2, 4) { Digit = 1 });
            squares.Add(new Square(2, 8) { Digit = 7 });
            squares.Add(new Square(3, 0) { Digit = 4 });
            squares.Add(new Square(3, 3) { Digit = 1 });
            squares.Add(new Square(3, 4) { Digit = 5 });
            squares.Add(new Square(3, 8) { Digit = 3 });
            squares.Add(new Square(4, 2) { Digit = 2 });
            squares.Add(new Square(4, 3) { Digit = 7 });
            squares.Add(new Square(4, 5) { Digit = 4 });
            squares.Add(new Square(4, 7) { Digit = 1 });
            squares.Add(new Square(5, 1) { Digit = 8 });
            squares.Add(new Square(5, 4) { Digit = 9 });
            squares.Add(new Square(5, 6) { Digit = 6 });
            squares.Add(new Square(6, 1) { Digit = 7 });
            squares.Add(new Square(6, 5) { Digit = 6 });
            squares.Add(new Square(6, 6) { Digit = 3 });
            squares.Add(new Square(7, 1) { Digit = 3 });
            squares.Add(new Square(7, 4) { Digit = 7 });
            squares.Add(new Square(7, 7) { Digit = 8 });
            squares.Add(new Square(8, 0) { Digit = 9 });
            squares.Add(new Square(8, 2) { Digit = 4 });
            squares.Add(new Square(8, 3) { Digit = 5 });
            squares.Add(new Square(8, 8) { Digit = 1 });

            var realPuzzle = new Puzzle(squares);
            Console.WriteLine(realPuzzle.GetAllowedDigits());
        }
    }
}
