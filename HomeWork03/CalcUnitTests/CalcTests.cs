using System;
using Xunit;
using HomeWork03;
namespace CalcUnitTests
{
    public class CalcTests
    {
        [Fact]
        public void TestAdd()
        {
            // arrange
            int a = 2;
            int b = 2;
            int expected = 4;
            Calc Calculator = new Calc(a, b);

            // act
            int actual =  Calculator.Add(a, b);

            // assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestSubtract()
        {
            // arrange
            int a = 5;
            int b = 6;
            int expected = 1;
            Calc Calculator = new Calc(a, b);

            // act
            int actual = Calculator.Subtract(a, b);

            // assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestDivide()
        {
            // arrange
            int a = 5;
            int b = 5;
            int expected = 1;
            Calc Calculator = new Calc(a, b);

            // act
            int actual = Calculator.Divide(a, b);

            // assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestMultiply()
        {
            // arrange
            int a = 5;
            int b = 5;
            int expected = 25;
            Calc Calculator = new Calc(a, b);

            // act
            int actual = Calculator.Multiply(a, b);

            // assert
            Assert.Equal(expected, actual);

        }
    }
}
