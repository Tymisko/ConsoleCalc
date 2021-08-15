// <copyright file="ParserTests.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc.Tests
{
    using Xunit;

    /// <summary>
    /// Contains xUnit tests for Parsers class.
    /// </summary>
    public class ParserTests
    {
        [Fact]
        private void ParsingTest()
        {
            // arrange
            Scanner scan = new Scanner("2+(5-3)*2");
            Parser parsedScan = new Parser(scan.ScanTokens());

            // assert
            Assert.Equal(6, parsedScan.Result());
        }
    }
}