using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleCalc.Tests
{
    public class ScannerTests
    {
        // Scanner scan = new Scanner("5+2");
        // scan.scanTokens();
        // foreach(var token in scan.tokens){
        //     System.Console.WriteLine(token);
        // }

        [Fact]
        void simpleCalculationTest() 
        {
            // arrange
                Scanner scan = new Scanner("5+2");
            // act
                scan.scanTokens();
                List<Token> correctTokens = new List<Token>() 
                {
                    {new Token(Token.TokenType.NUMBER, "5", Convert.ToDouble(5))},
                    {new Token(Token.TokenType.PLUS, "+", null)},
                    {new Token(Token.TokenType.NUMBER, "2", Convert.ToDouble(2))}
                };
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
        }

    }
}