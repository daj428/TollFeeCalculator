using TollFeeCalculator;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class TollCalculatorTests
    {
        [TestMethod]
        public void GetTollFee_GetSomething_Returnd()
        {
            //ARRANGE
            var expectedResult = 13;
            var car = new Car();
            var dates = new DateTime[] { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT

            Assert.AreEqual(expectedResult, result);
        }
    }
}