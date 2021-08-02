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
                    {new Token(Token.TokenType.NUMBER, "5", Convert.ToDouble(5))},
                    {new Token(Token.TokenType.PLUS, "+", null)},
                    {new Token(Token.TokenType.NUMBER, "2", Convert.ToDouble(2))}
                };
            // act
                scan.scanTokens();
            // assert
                for(var i = 0; i < correctTokens.Count; i++)
                {
                    Assert.Equal(correctTokens[i].type, scan.tokens[i].type);
                    Assert.Equal(correctTokens[i].lexeme, scan.tokens[i].lexeme);
                    Assert.Equal(correctTokens[i].literal, scan.tokens[i].literal);
                }
        }
        [Fact]
        void ParenCalcTest()
        {
            // arrange
                Scanner parenScan = new Scanner("2*(3+2)");
                List<Token> correctParenTokens = new List<Token>() 
                {
                    {new Token(Token.TokenType.NUMBER, "2", Convert.ToDouble(2))},
                    {new Token(Token.TokenType.STAR, "*", null)},
                    {new Token(Token.TokenType.LEFT_PAREN, "(", null)},
                    {new Token(Token.TokenType.NUMBER, "3", Convert.ToDouble(3))},
                    {new Token(Token.TokenType.PLUS, "+", null)},
                    {new Token(Token.TokenType.NUMBER, "2", Convert.ToDouble(2))},
                    {new Token(Token.TokenType.RIGHT_PAREN, ")", null)}                  
                };
            // act
                parenScan.scanTokens();
            // assert
                for(var i = 0; i < correctParenTokens.Count; i++)
                {
                    Assert.Equal(correctParenTokens[i].type, parenScan.tokens[i].type);
                    Assert.Equal(correctParenTokens[i].lexeme, parenScan.tokens[i].lexeme);
                    Assert.Equal(correctParenTokens[i].literal, parenScan.tokens[i].literal);
                }
        }
    }
}