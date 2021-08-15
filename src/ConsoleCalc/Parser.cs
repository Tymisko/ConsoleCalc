﻿// <copyright file="Parser.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Parsing scanned string.
    /// </summary>
    /// <return>Result is available as field of Parser element.</return>
    internal class Parser
    {
        /// <summary>
        /// Contains result of mathematical operation.
        /// </summary>
        private double result;
        private TokenStream tokenStream;
        private bool lastToken = false;
        private TextWriter errorWriter = Console.Error;

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

        // Supports addition, subtraction and parenthesis
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
                        left += this.Term();
                        currentToken = this.tokenStream.Get();
                        break;
                    case Token.TokenType.MINUS:
                        left -= this.Term();
                        currentToken = this.tokenStream.Get();
                        break;

                    // to handle '2(1+3)'
                    case Token.TokenType.LEFT_PAREN:
                        {
                            double d = this.Expression();
                            currentToken = this.tokenStream.Get();
                            if (currentToken.Type != Token.TokenType.RIGHT_PAREN)
                            {
                                this.errorWriter.WriteLine("')' was expected.");
                                throw new ArgumentException();
                            }

                            return left * d;
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
                    case Token.TokenType.CARET:
                        left = Math.Pow(left, this.Primary());
                        currentToken = this.tokenStream.Get();
                        break;
                    case Token.TokenType.STAR:
                        left *= this.Primary();
                        currentToken = this.tokenStream.Get();
                        break;
                    case Token.TokenType.SLASH:
                    {
                        double d = this.Primary();
                        if (d == 0)
                        {
                            throw new DivideByZeroException();
                        }

                        left /= d;
                        currentToken = this.tokenStream.Get();
                        break;
                    }

                    default:
                        this.tokenStream.PutBack(currentToken);
                        return left;
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
                    {
                        double d = this.Expression();
                        currentToken = this.tokenStream.Get();
                        if (currentToken.Type != Token.TokenType.RIGHT_PAREN)
                        {
                            this.errorWriter.WriteLine("')' was expected.");
                            throw new ArgumentException();
                        }

                        return d;
                    }

                case Token.TokenType.LEFT_BRACE:
                    {
                        double d = this.Expression();
                        currentToken = this.tokenStream.Get();
                        if (currentToken.Type != Token.TokenType.RIGHT_BRACE)
                        {
                            this.errorWriter.WriteLine("'}' was expected.");
                            throw new ArgumentException();
                        }

                        return d;
                    }

                case Token.TokenType.NUMBER:
                    return Convert.ToDouble(currentToken.Value);
                case Token.TokenType.WHITESPACE:
                    return this.Primary();

                // Supports actions where minus is first token
                case Token.TokenType.MINUS:
                    return this.Primary() * -1;
                case Token.TokenType.EQUAL:
                    this.lastToken = true;
                    return 0;
                default:
                    this.errorWriter.WriteLine("Factor was expected.");
                    throw new ArgumentException();
            }
        }
    }
}
