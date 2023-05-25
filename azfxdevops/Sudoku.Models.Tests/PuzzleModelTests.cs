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
        }
    }
}
