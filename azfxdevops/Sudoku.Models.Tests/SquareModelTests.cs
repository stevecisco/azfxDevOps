namespace Sudoku.Models.Tests
{
    [TestClass]
    public class SquareModelTests
    {
        [TestMethod]
        public void TestModelSquareAllowedDigits()
        {
            var model = new Square(0, 0);
            Assert.AreEqual("123\n456\n789", model.GetAllowedDigits(null));

            model.OneExcluded = true;
            Assert.AreEqual(" 23\n456\n789", model.GetAllowedDigits(null));

            model.TwoExcluded = true;
            Assert.AreEqual("  3\n456\n789", model.GetAllowedDigits(null));

            model.ThreeExcluded = true;
            Assert.AreEqual("   \n456\n789", model.GetAllowedDigits(null));

            model.FourExcluded = true;
            Assert.AreEqual("   \n 56\n789", model.GetAllowedDigits(null));

            model.FiveExcluded = true;
            Assert.AreEqual("   \n  6\n789", model.GetAllowedDigits(null));

            model.SixExcluded = true;
            Assert.AreEqual("   \n   \n789", model.GetAllowedDigits(null));

            model.SevenExcluded = true;
            Assert.AreEqual("   \n   \n 89", model.GetAllowedDigits(null));

            model.EightExcluded = true;
            Assert.AreEqual("   \n   \n  9", model.GetAllowedDigits(null));

            model.NineExcluded = true;
            Assert.ThrowsException<InvalidOperationException>(() => { var d = model.GetAllowedDigits; });            
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