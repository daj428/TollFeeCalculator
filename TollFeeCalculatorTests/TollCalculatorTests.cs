using TollFeeCalculator;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class TollCalculatorTests
    {
        [TestMethod]
        public void GetTollFee_CarRegularWeekdayAtEightFourteen_MidFeeReturned()
        {
            //ARRANGE
            var expectedResult = 13;
            var car = new Car();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_DiplomatNoFee_ZeroFeeReturned()
        {
            //ARRANGE
            var expectedResult = 0;
            var diplomat = new Diplomat();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(diplomat, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_EmergencyNoFee_ZeroFeeReturned()
        {
            //ARRANGE
            var expectedResult = 0;
            var emergency = new Emergency();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(emergency, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_ForeignNoFee_ZeroFeeReturned()
        {
            //ARRANGE
            var expectedResult = 0;
            var foreign = new Foreign();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(foreign, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_MilitaryNoFee_ZeroFeeReturned()
        {
            //ARRANGE
            var expectedResult = 0;
            var military = new Military();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(military, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_TractorNoFee_ZeroFeeReturned()
        {
            //ARRANGE
            var expectedResult = 0;
            var tractor = new Tractor();
            var dates = new List<DateTime> { new DateTime(2013, 04, 16, 08, 14, 0) };
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(tractor, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_DatesIsNull_Minus1Returned()
        {
            //ARRANGE
            var expectedResult = -1;
            var car = new Car();
            var tollCalculator = new TollCalculator();

            //ACT
            var result = tollCalculator.GetTollFee(car, null);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_DatesIsEmpty_Minus1Returned()
        {
            //ARRANGE
            var expectedResult = -1;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime>();

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_VehicleIsEmpty_Minus1Returned()
        {
            //ARRANGE
            var expectedResult = -1;
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime>();

            //ACT
            var result = tollCalculator.GetTollFee(null, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_DatesIsNotSameDay_Minus1Returned()
        {
            //ARRANGE
            var expectedResult = -1;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 10, 0, 0),
                new DateTime(2013, 04, 16, 11, 0, 0),
                new DateTime(2013, 04, 16, 12, 0, 0),
                new DateTime(2013, 04, 17, 09, 0, 0) };

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}