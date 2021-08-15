// <copyright file="ScannerTests.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Contains xUnit tests for Scanner class.
    /// </summary>
    public class ScannerTests
    {
        [Fact]
        private void SimpleCalculationTest()
        {
            // arrange
                Scanner scan = new Scanner("5+2");
                List<Token> correctTokens = new List<Token>()
                {
                    { new Token(Token.TokenType.NUMBER, 5) },
                    { new Token(Token.TokenType.PLUS, 0) },
                    { new Token(Token.TokenType.NUMBER, 2) },
                };

            // act
                scan.ScanTokens();

            // assert
                for (var i = 0; i < correctTokens.Count; i++)
                {
                    Assert.Equal(correctTokens[i].Type, scan.Tokens[i].Type);
                }
        }

        [Fact]
        private void ParenScanTest()
        {
            // arrange
                Scanner parenScan = new Scanner("2*(33+2)");
                List<Token> correctParenTokens = new List<Token>()
                {
                    { new Token(Token.TokenType.NUMBER, 2) },
                    { new Token(Token.TokenType.STAR, 0) },
                    { new Token(Token.TokenType.LEFT_PAREN, 0) },
                    { new Token(Token.TokenType.NUMBER, 33) },
                    { new Token(Token.TokenType.PLUS, 0) },
                    { new Token(Token.TokenType.NUMBER, 2) },
                    { new Token(Token.TokenType.RIGHT_PAREN, 0) },
                };

            // act
                parenScan.ScanTokens();

            // assert
                for (var i = 0; i < correctParenTokens.Count; i++)
                {
                    Assert.Equal(correctParenTokens[i].Type, parenScan.Tokens[i].Type);
                    Assert.Equal(correctParenTokens[i].Value, parenScan.Tokens[i].Value);
                }
        }
    }
}