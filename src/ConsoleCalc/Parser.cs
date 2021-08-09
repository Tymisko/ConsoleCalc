using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleCalc
{
    class Parser 
    {
        public double result;
        TokenStream tokenStream;
        private bool lastToken = false;
        public Parser(List<Token> tokens)
        {
            TokenStream tokenStream = new TokenStream(tokens);
            this.tokenStream = tokenStream;
            result = expression();
        }
        private TextWriter errorWriter = Console.Error;
        double expression()
        {
           double left = term();
            if(lastToken) return left;
            Token currentToken = tokenStream.get();
            while(true)
            {
                switch(currentToken.type)
                {
                    case Token.TokenType.PLUS:
                        left += term();
                        currentToken = tokenStream.get();
                        break;
                    case Token.TokenType.MINUS: 
                        left -= term();
                        currentToken = tokenStream.get();
                        break;
                    // to handle '2(1+3)'
                    case Token.TokenType.LEFT_PAREN:
                        {
                            double d = expression();
                            currentToken = tokenStream.get();
                            if (currentToken.type != Token.TokenType.RIGHT_PAREN)
                            {
                                errorWriter.WriteLine("')' was expected.");
                                throw new ArgumentException();
                            }
                            return left*d;
                        }
                    default:
                        tokenStream.putback(currentToken);
                        return left;
                }
            }
        }
        double term()
        {
            double left = primary();
            if(lastToken) return left;
            Token currentToken = tokenStream.get();
            while(true)
            {
                switch(currentToken.type)
                {
                    case Token.TokenType.CARET:
                        left = Math.Pow(left, primary());
                        currentToken = tokenStream.get();
                        break;
                    case Token.TokenType.STAR:
                        left *= primary();
                        currentToken = tokenStream.get();
                        break;
                    case Token.TokenType.SLASH:
                    {
                        double d = primary();
                        if(d == 0) throw new DivideByZeroException();
                        left /= d;
                        currentToken = tokenStream.get();
                        break;
                    }
                    default:
                        tokenStream.putback(currentToken);
                        return left;
                }
            }
        }
        double primary()
        {
            Token currentToken = tokenStream.get();
            switch(currentToken.type)
            {
                case Token.TokenType.LEFT_PAREN:
                    {
                        double d = expression();
                        currentToken = tokenStream.get();
                        if(currentToken.type != Token.TokenType.RIGHT_PAREN)
                        {
                            errorWriter.WriteLine("')' was expected.");
                            throw new ArgumentException();
                        }
                        return d;
                    }
                case Token.TokenType.LEFT_BRACE:
                    {
                        double d = expression();
                        currentToken = tokenStream.get();
                        if(currentToken.type != Token.TokenType.RIGHT_BRACE)
                        {
                            errorWriter.WriteLine("'}' was expected.");
                            throw new ArgumentException();
                        }
                            
                        return d;
                    }
                case Token.TokenType.NUMBER:
                    return Convert.ToDouble(currentToken.value);
                case Token.TokenType.WHITESPACE:
                    return primary();
                // Support actions where minus is first token
                case Token.TokenType.MINUS:
                    return primary()*-1;
                case Token.TokenType.EQUAL:
                case Token.TokenType.EOF:
                    lastToken = true;
                    return 0;
                default:
                    errorWriter.WriteLine("Factor was expected.");
                    throw new ArgumentException();
            }
        }
    }
}
