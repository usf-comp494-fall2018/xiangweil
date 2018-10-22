using System;
using Xunit;
using Midterm_project;

namespace TestCalc
{
    public class UnitTest1
    {
        [Fact]
        public void TestMean()
        {
            // arrange
            double[] numbers = { 2.5, 3.5 };
            double expected = 3;

            Calc data = new Calc(numbers);

            // act
            double actual = data.GetMean(numbers, 2);

            // assert
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMedian()
        {
            // arrange
            double[] numbers = { 2.5, 4, 5 };
            double expected = 4;

            Calc data = new Calc(numbers);

            // act
            double actual = data.GetMedian(numbers);

            // assert

            Assert.Equal(expected, actual);
        }
    }
}
