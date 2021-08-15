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
        [Fact]
        private void Action00()
        {
            // arrange
            Scanner scan = new Scanner("2+6:2*3");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(11, parsedScan.Result());
        }

        [Fact]
        private void Action01()
        {
            // arrange
            Scanner scan = new Scanner("7-2*0+5:5-2");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(6, parsedScan.Result());
        }

        [Fact]
        private void Action02()
        {
            // arrange
            Scanner scan = new Scanner("2*(1+3)");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(8, parsedScan.Result());
        }

        [Fact]
        private void Action03()
        {
            // arrange
            Scanner scan = new Scanner("2(1+3)");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(8, parsedScan.Result());
        }

        [Fact]
        private void Action04()
        {
            // arrange
            Scanner scan = new Scanner("-99+1");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(-98, parsedScan.Result());
        }

        [Fact]
        private void Action05()
        {
            // arrange
            Scanner scan = new Scanner("(-99+1)*1=");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(-98, parsedScan.Result());
        }
    }
}