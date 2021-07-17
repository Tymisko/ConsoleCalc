using System.Collections.Generic;
using Xunit;

namespace ConsoleCalc.Tests
{
    public class AdditionTests
    {
        // Arrange
        List<double> integerNumbers = new List<double>(){6,3,2};
        List<double> floatNumbers = new List<double>(){4, 3.25, 0.25, 0};
        [Fact]
        public void AdditionTest()
        {
            // act
            var integerNumbersSum = Actions.Sum(integerNumbers);
            var floatNumbersSum = Actions.Sum(floatNumbers);

            // assert
            Assert.Equal(11, integerNumbersSum);
            Assert.Equal(7.5, floatNumbersSum);
        }

        [Fact]
        public void SubtractionTest()
        {
            // act
            var integerNumbersDifference = Actions.Difference(integerNumbers);
            var floatNumbersDifference = Actions.Difference(floatNumbers);
            // assert
            Assert.Equal(1, integerNumbersDifference);
            Assert.Equal(0.5, floatNumbersDifference);
        }

        [Fact]
        public void MultiplicationTest()
        {
            // act
            var integerNumbersProduct = Actions.Product(integerNumbers);
            var floatNumbersProduct = Actions.Product(floatNumbers);

            // assert
            Assert.Equal(36, integerNumbersProduct);
            Assert.Equal(0, floatNumbersProduct);
        }

    }
}
