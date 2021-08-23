// <copyright file="Parser.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc.Lexer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Parsing scanned string.
    /// </summary>
    /// <return>Result is available as field of Parser element.</return>
    internal class Parser
    {
        private double result = 0;
        private TokenStream tokenStream;
        private bool lastToken = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="tokens">Scanned source by Scanner class.</param>
        public Parser(List<Token> tokens)
        {
            TokenStream tokenStream = new TokenStream(tokens);
            this.tokenStream = tokenStream;
            this.result = this.Expression();
        }

        /// <summary>Public method that return result.</summary>
        /// <returns>Result of scanned and parsed tokens.</returns>
        public double Result()
        {
            return this.result;
        }

        // Supports addition, subtraction, parenthesis, percent of number and modulo
        private double Expression()
        {
            double left = this.Term();
            if (this.lastToken)
            {
                return left;
            }

            Token currentToken = this.tokenStream.Get();
            while (true)
            {
                switch (currentToken.Type)
                {
                    case Token.TokenType.PLUS:
                        {
                            left += this.Term();
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    case Token.TokenType.MINUS:
                        {
                            left -= this.Term();
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    case Token.TokenType.PERCENT:
                        {
                            left = this.PercentAction(left);
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    default:
                        this.tokenStream.PutBack(currentToken);
                        return left;
                }
            }
        }

        // Supports mulptiplications, divisions and raising to power
        private double Term()
        {
            double left = this.Primary();
            if (this.lastToken)
            {
                return left;
            }

            Token currentToken = this.tokenStream.Get();
            while (true)
            {
                switch (currentToken.Type)
                {
                    // to handle '2(1+3)'
                    case Token.TokenType.LEFT_PAREN:
                    case Token.TokenType.LEFT_BRACE:
                        {
                            // to handle raising to power
                            left = this.ParenthesisAction(left, out currentToken, currentToken.Type);
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    // to handle '(1+3)2'
                    case Token.TokenType.NUMBER:
                        {
                            left *= currentToken.Value;
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    case Token.TokenType.CARET:
                        {
                            left = Math.Pow(left, this.Primary());
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    case Token.TokenType.STAR:
                        {
                            left *= this.Primary();
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    case Token.TokenType.SLASH:
                        {
                            left = this.Dividing(left);
                            currentToken = this.tokenStream.Get();
                            break;
                        }

                    default:
                        {
                            this.tokenStream.PutBack(currentToken);
                            return left;
                        }
                }
            }
        }

        // supports primary elements like number, equal and parentheses inside another parentheses.
        private double Primary()
        {
            Token currentToken = this.tokenStream.Get();
            switch (currentToken.Type)
            {
                case Token.TokenType.LEFT_PAREN:
                case Token.TokenType.LEFT_BRACE:
                    return this.ParenthesisAction(out currentToken, currentToken.Type);

                case Token.TokenType.NUMBER:
                    return Convert.ToDouble(currentToken.Value);

                // Supports actions where minus is first token
                case Token.TokenType.MINUS:
                    return this.Primary() * -1;

                case Token.TokenType.EQUAL:
                    this.lastToken = true;
                    return 0;

                default:
                    throw new ArgumentException("Factor was expected.");
            }
        }

        private double Dividing(double left)
        {
            double d = this.Primary();
            if (d == 0)
            {
                throw new DivideByZeroException();
            }

            left /= d;
            return left;
        }

        private double ParenthesisAction(double left, out Token currentToken, Token.TokenType parentType)
        {
            double parenthesisResult = this.Expression();
            currentToken = this.tokenStream.Get();

            switch (parentType)
            {
                case Token.TokenType.LEFT_BRACE:
                    {
                        if (currentToken.Type != Token.TokenType.RIGHT_BRACE)
                        {
                            throw new ArgumentException("'}' was expected.");
                        }

                        break;
                    }

                case Token.TokenType.LEFT_PAREN:
                    {
                        if (currentToken.Type != Token.TokenType.RIGHT_PAREN)
                        {
                            throw new ArgumentException("')' was expected.");
                        }

                        break;
                    }
            }

            if (!this.tokenStream.IsAtEnd() && this.tokenStream.LookForward().Type == Token.TokenType.CARET)
            {
                this.tokenStream.Forward();
                left *= Math.Pow(parenthesisResult, this.Primary());
            }
            else
            {
                left *= parenthesisResult;
            }

            return left;
        }

        private double ParenthesisAction(out Token currentToken, Token.TokenType parentType)
        {
            double parenthesisResult = this.Expression();
            currentToken = this.tokenStream.Get();

            switch (parentType)
            {
                case Token.TokenType.LEFT_BRACE:
                    {
                        if (currentToken.Type != Token.TokenType.RIGHT_BRACE)
                        {
                            throw new ArgumentException("'}' was expected.");
                        }

                        break;
                    }

                case Token.TokenType.LEFT_PAREN:
                    {
                        if (currentToken.Type != Token.TokenType.RIGHT_PAREN)
                        {
                            throw new ArgumentException("')' was expected.");
                        }

                        break;
                    }
            }

            return parenthesisResult;
        }

        private double PercentAction(double left)
        {
            // for percent calculation of number 'x %* y'
            if (this.tokenStream.LookForward().Type == Token.TokenType.STAR)
            {
                this.tokenStream.Forward();
                return (left / 100) * this.Primary();
            }

            // for modulo 'x % y'
            return left % this.Primary();
        }
    }
}
