namespace Sudoku.Models.Tests
{
    [TestClass]
    public class SquareModelTests
    {
        [TestMethod]
        public void TestModelSquareAllowedDigits()
        {
            var model = new Square(0, 0);
            Assert.AreEqual(" 1 2 3 \n 4 5 6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(1);
            Assert.AreEqual("   2 3 \n 4 5 6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(2);
            Assert.AreEqual("     3 \n 4 5 6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(3);
            Assert.AreEqual("       \n 4 5 6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(4);
            Assert.AreEqual("       \n   5 6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(5);
            Assert.AreEqual("       \n     6 \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(6);
            Assert.AreEqual("       \n       \n 7 8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(7);
            Assert.AreEqual("       \n       \n   8 9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(8);
            Assert.AreEqual("       \n       \n     9 ", model.GetAllowedDigits(null));

            model.SetExcludedDigit(9);
            Assert.ThrowsException<InvalidOperationException>(() => { var d = model.GetAllowedDigits(null); });            
        }

        [TestMethod]
        public void TestModelColRowIndexes()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var model = new Square(row, col);
                    Assert.IsNotNull(model);
                }
            }

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var model = new Square(-1, 0); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var model = new Square(0, -1); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var model = new Square(9, 0); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var model = new Square(0, 9); });

        }
    }
}