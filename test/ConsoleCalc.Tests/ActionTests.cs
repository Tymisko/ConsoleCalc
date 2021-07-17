using System.Collections.Generic;
using Xunit;

namespace ConsoleCalc.Tests
{
    public class ActionTests
    {
        // Arrange
        List<double> integerNumbers = new List<double>(){6,3,2};
        List<double> floatNumbers = new List<double>(){4, 3.25, 0.25, 0};
        [Fact]
        public void AdditionTest()
        {
            // act
            var integerNumbersSum = Actions.Add(integerNumbers);
            var floatNumbersSum = Actions.Add(floatNumbers);

            // assert
            Assert.Equal(11, integerNumbersSum);
            Assert.Equal(7.5, floatNumbersSum);
        }

        [Fact]
        public void SubtractionTest()
        {
            // act
            var integerNumbersDifference = Actions.Subtract(integerNumbers);
            var floatNumbersDifference = Actions.Subtract(floatNumbers);
            // assert
            Assert.Equal(1, integerNumbersDifference);
            Assert.Equal(0.5, floatNumbersDifference);
        }

        [Fact]
        public void MultiplicationTest()
        {
            // act
            var integerNumbersProduct = Actions.Multiply(integerNumbers);
            var floatNumbersProduct = Actions.Multiply(floatNumbers);

            // assert
            Assert.Equal(36, integerNumbersProduct);
            Assert.Equal(0, floatNumbersProduct);
        }

        [Fact]
        public void DivisionTest()
        {
            // act
            var integerNumbersQuotient = Actions.Divide(integerNumbers);
            var floatNumbersQuotient = Actions.Divide(floatNumbers);

            // assert
            Assert.Equal(1, integerNumbersQuotient);
            // Assert.Equal(4.923076923, integerNumbersQuotient);
        }
    }
}
