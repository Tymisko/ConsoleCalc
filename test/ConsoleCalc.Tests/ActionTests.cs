using System.Collections.Generic;
using Xunit;

namespace ConsoleCalc.Tests
{
    public class AdditionTests
    {
        [Fact]
        public void AdditionTest()
        {
            // arrange
            List<double> numbers = new List<double>() {1,2,3};
            List<double> floatingNumbers = new List<double>() {1.25, 2.25, 0.50};

            // act
            var sum = Actions.Sum(numbers);
            var floatingNumbersSum = Actions.Sum(floatingNumbers);

            // assert
            Assert.Equal(6, sum);
            Assert.Equal(4, floatingNumbersSum);
        }

        [Fact]
        public void SubtractionTest()
        {
            // arrange
            List<double> numbers = new List<double>(){6,3,2};
            List<double> nums = new List<double>(){4, 3.25, 0.25};
        
            // act
            var numbersDifference = Actions.Difference(numbers);
            var numsDifference = Actions.Difference(nums);

            // assert
            Assert.Equal(1, numbersDifference);
            Assert.Equal(0.5, numsDifference);
        }

    }
}
