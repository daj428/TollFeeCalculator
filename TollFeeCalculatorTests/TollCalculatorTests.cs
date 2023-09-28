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

        [TestMethod]
        public void GetTollFee_TwoPassagesSamehour_HighestFeeReturned()
        {
            //ARRANGE
            var expectedResult = 18;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 6, 45, 0),
                new DateTime(2013, 04, 16, 7, 15, 0) };

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_FivePassagesSamehourLowerToHigher_HighestFeeReturned()
        {
            //ARRANGE
            var expectedResult = 18;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 6, 22, 0),
                new DateTime(2013, 04, 16, 6, 27, 0),
                new DateTime(2013, 04, 16, 6, 45, 0),
                new DateTime(2013, 04, 16, 7, 15, 0),
                new DateTime(2013, 04, 16, 7, 18, 0)};

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_FivePassagesSamehourHigherToLower_HighestFeeReturned()
        {
            //ARRANGE
            var expectedResult = 18;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 16, 45, 0),
                new DateTime(2013, 04, 16, 16, 55, 0),
                new DateTime(2013, 04, 16, 17, 15, 0),
                new DateTime(2013, 04, 16, 17, 20, 0),
                new DateTime(2013, 04, 16, 17, 40, 0)};

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_FourPassagesButTwoPerHourInterval_HighestFeeReturnedPerHour()
        {
            //ARRANGE
            var expectedResult = 31;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 6, 27, 0),
                new DateTime(2013, 04, 16, 6, 45, 0),
                new DateTime(2013, 04, 16, 16, 55, 0),
                new DateTime(2013, 04, 16, 17, 15, 0)};

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_SeveralPassagesDifferentHourInterval_HighestFeeReturnedPerHour()
        {
            //ARRANGE
            var expectedResult = 57;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 6, 15, 0),
                new DateTime(2013, 04, 16, 6, 45, 0),
                new DateTime(2013, 04, 16, 6, 55, 0),
                new DateTime(2013, 04, 16, 7, 19, 0),
                new DateTime(2013, 04, 16, 12, 0, 0),
                new DateTime(2013, 04, 16, 16, 45, 0),
                new DateTime(2013, 04, 16, 17, 10, 0),
                new DateTime(2013, 04, 16, 17, 15, 0),
                new DateTime(2013, 04, 16, 22, 00, 0)
            };

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_PassagesBeforeSixOClockIsRemovedFromStartInterval_StartIntervalCalculatedFromFirstPassageWithFee()
        {
            //ARRANGE
            var expectedResult = 13;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 5, 30, 0),
                new DateTime(2013, 04, 16, 6, 15, 0),
                new DateTime(2013, 04, 16, 6, 45, 0)
            };

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetTollFee_PassagesForMoreThanMaximum_MaximumDailyFeeReturned()
        {
            //ARRANGE
            var expectedResult = 60;
            var car = new Car();
            var tollCalculator = new TollCalculator();
            var dates = new List<DateTime> {
                new DateTime(2013, 04, 16, 6, 30, 0),
                new DateTime(2013, 04, 16, 7, 31, 0),
                new DateTime(2013, 04, 16, 8, 32, 0),
                new DateTime(2013, 04, 16, 9, 33, 0),
                new DateTime(2013, 04, 16, 10, 34, 0),
                new DateTime(2013, 04, 16, 11, 35, 0),
                new DateTime(2013, 04, 16, 16, 36, 0),
                new DateTime(2013, 04, 16, 17, 37, 0),
                new DateTime(2013, 04, 16, 18, 38, 0),
            };

            //ACT
            var result = tollCalculator.GetTollFee(car, dates);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}