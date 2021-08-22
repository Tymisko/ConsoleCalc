// <copyright file="ActionTests.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc.Tests
{
    using Xunit;

    /// <summary>
    /// Testing class that contains xUnit tests for actions.
    /// </summary>
    public class ActionTests
    {
        [Theory]
        [InlineData("2+6:2*3")]
        [InlineData("7-2*0+5:5-2")]
        [InlineData("2*(1+3)")]
        [InlineData("2(1 + 3)")]
        [InlineData("-99 + 1)")]
        [InlineData("(-99+1)*1=")]
        [InlineData("2^5")]
        [InlineData("2 ^ 5")]
        [InlineData("2(1+5^2)^3")]
        [InlineData("(1 + 3)2")]
        [InlineData("25%*4")] // percentage of number
        [InlineData("125%10")] // modulo
        [InlineData("2(25%*100+5^2)^3%13")]
        private void Should_Be_Correctly_Calculated(string source)
        {
            // arrange
            Scanner scan = new Scanner(source);
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            switch (source)
            {
                case "2+6:2*3": Assert.Equal(11, parsedScan.Result()); break;
                case "7-2*0+5:5-2": Assert.Equal(6, parsedScan.Result()); break;
                case "2*(1+3)": Assert.Equal(8, parsedScan.Result()); break;
                case "2(1 + 3)": Assert.Equal(8, parsedScan.Result()); break;
                case "- 99 + 1": Assert.Equal(-98, parsedScan.Result()); break;
                case "(-99+1)*1=": Assert.Equal(-98, parsedScan.Result()); break;
                case "2^5": Assert.Equal(32, parsedScan.Result()); break;
                case "2 ^ 5": Assert.Equal(32, parsedScan.Result()); break;
                case "2(1+5^2)^3": Assert.Equal(35152, parsedScan.Result()); break;
                case "(1 + 3)2": Assert.Equal(8, parsedScan.Result()); break;
                case "25%*4": Assert.Equal(1, parsedScan.Result()); break;
                case "125%10": Assert.Equal(5, parsedScan.Result()); break;
                case "2(25%*100+5^2)^3%13": Assert.Equal(10, parsedScan.Result()); break;
            }
        }
    }
}