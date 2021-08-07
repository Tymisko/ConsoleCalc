using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleCalc.Tests
{
    public class ScannerTests
    {
        [Fact]
        void simpleCalculationTest() 
        {
            // arrange
                Scanner scan = new Scanner("5+2");
                List<Token> correctTokens = new List<Token>() 
                {
                    {new Token(Token.TokenType.NUMBER, 5)},
                    {new Token(Token.TokenType.PLUS, 0)},
                    {new Token(Token.TokenType.NUMBER, 2)}
                };
            // act
                scan.scanTokens();
            // assert
                for(var i = 0; i < correctTokens.Count; i++)
                {
                    Assert.Equal(correctTokens[i].type, scan.tokens[i].type);
                }
        }
        [Fact]
        void parenScanTest()
        {
            // arrange
                Scanner parenScan = new Scanner("2*(33+2)");
                List<Token> correctParenTokens = new List<Token>() 
                {
                    {new Token(Token.TokenType.NUMBER, 2)},
                    {new Token(Token.TokenType.STAR, 0)},
                    {new Token(Token.TokenType.LEFT_PAREN, 0)},
                    {new Token(Token.TokenType.NUMBER, 33)},
                    {new Token(Token.TokenType.PLUS, 0)},
                    {new Token(Token.TokenType.NUMBER, 2)},
                    {new Token(Token.TokenType.RIGHT_PAREN, 0)}                  
                };
            // act
                parenScan.scanTokens();
            // assert
                for(var i = 0; i < correctParenTokens.Count; i++)
                {
                    Assert.Equal(correctParenTokens[i].type, parenScan.tokens[i].type);
                    Assert.Equal(correctParenTokens[i].value, parenScan.tokens[i].value);
                }
        }
    }
}