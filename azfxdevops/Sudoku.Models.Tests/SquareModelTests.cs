namespace Sudoku.Models.Tests
{
    [TestClass]
    public class SquareModelTests
    {

        [TestMethod]
        public void TestModelSquareAllowedDigits()
        {
            var model = new Square(0, 0);
            Assert.AreEqual("123456789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int> { 1 });
            Assert.AreEqual("23456789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 2 });
            Assert.AreEqual("3456789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 3 });
            Assert.AreEqual("456789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 4 });
            Assert.AreEqual("56789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 5 });
            Assert.AreEqual("6789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 6 });
            Assert.AreEqual("789", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 7 });
            Assert.AreEqual("89", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 8 });
            Assert.AreEqual("9", model.GetAllowedDigitsPacked());

            model.SetExcludedDigits(new List<int>{ 9 });
            Assert.ThrowsException<InvalidOperationException>(() => { var d = model.GetAllowedDigitsPacked(); });            
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