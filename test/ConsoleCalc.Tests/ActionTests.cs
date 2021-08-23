// <copyright file="ActionTests.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc.Tests
{
    using Xunit;
    using ConsoleCalc.Lexer;

    /// <summary>
    /// Testing class that contains xUnit tests for actions.
    /// </summary>
    public class ActionTests
    {
        [Theory]
        [InlineData("2+6:2*3", 11)]
        [InlineData("7-2*0+5:5-2", 6)]
        [InlineData("2*(1+3)", 8)]
        [InlineData("2(1 + 3)", 8)]
        [InlineData("-99 + 1)", -98)]
        [InlineData("(-99+1)*1=", -98)]
        [InlineData("2^5", 32)]
        [InlineData("2 ^ 5", 32)]
        [InlineData("2(1+5^2)^3", 35152)]
        [InlineData("(1 + 3)2", 8)]
        [InlineData("25%*4", 1)] // percentage of number
        [InlineData("125%10", 5)] // modulo
        [InlineData("2(25%*100+5^2)^3%13", 10)]
        [InlineData("1*(50*51)/50*51", 2601)]
        [InlineData("1(50*51)/50*51", 2601)]
        [InlineData("10(5)/5", 10)]

        private void Should_Be_Correctly_Calculated(string source, double result)
        {
            // arrange
            Scanner scan = new Scanner(source);
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(result, parsedScan.Result());
        }
    }
}