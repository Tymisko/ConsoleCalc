using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleCalc
{
    class Parser 
    {
        public double result;
        TokenStream ts;
        private bool lastToken = false;
        public Parser(List<Token> tokens)
        {
            TokenStream ts = new TokenStream(tokens);
            this.ts = ts;
            result = expression();
        }
        private TextWriter errorWriter = Console.Error;
        double expression()
        {
            double left = term();
            if(lastToken)
            {
                return left;
            }
            Token currentToken = ts.get();
            while(true)
            {
                switch(currentToken.type)
                {
                    case Token.TokenType.PLUS:
                        left += term();
                        currentToken = ts.get();
                        break;
                    case Token.TokenType.MINUS: 
                        left -= term();
                        currentToken = ts.get();
                        break;
                    default:
                        ts.putback(currentToken);
                        return left;
                }
            }
        }
        double term()
        {
            double left = primary();
            if(lastToken) {
                return left;
            }
            Token currentToken = ts.get();
            while(true)
            {
                switch(currentToken.type)
                {
                    case Token.TokenType.STAR:
                        left *= primary();
                        currentToken = ts.get();
                        break;
                    case Token.TokenType.SLASH:
                    {
                        double d = primary();
                        if(d == 0) throw new DivideByZeroException($"Divided by zero");
                        left /= d;
                        currentToken = ts.get();
                        break;
                    }
                    default:
                        ts.putback(currentToken);
                        return left;
                }
            }
        }
        double primary()
        {
            Token currentToken = ts.get();
            switch(currentToken.type)
            {
                case Token.TokenType.LEFT_PAREN:
                    {
                        double d = expression();
                        currentToken = ts.get();
                        if(currentToken.type != Token.TokenType.RIGHT_PAREN) errorWriter.WriteLine("')' was expected.");
                        return d;
                    }
                case Token.TokenType.NUMBER:
                    return Convert.ToDouble(currentToken.value);
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
