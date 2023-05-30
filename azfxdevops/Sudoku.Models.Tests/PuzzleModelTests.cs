using Sudoku.Models.Entities;

namespace Sudoku.Models.Tests
{
    [TestClass]
    public class PuzzleModelTests
    {
        [TestMethod]
        public void TestPuzzleAllowedDigits()
        {
            var puzzle = new Puzzle(new List<SquareDTO>());
            Console.WriteLine(puzzle.GetAllowedDigitsFormatted());
        }
    }
}
