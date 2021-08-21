// <copyright file="Scanner.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsoleCalc.Tests")]

namespace ConsoleCalc
{
    /// <summary>
    /// Scans string and separate it into tokens.
    /// </summary>
    internal class Scanner
    {
        private string source;
        private List<Token> tokens = new List<Token>();
        private int start = 0;
        private int current = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scanner"/> class.
        /// </summary>
        /// <param name="source">String that contains mathematical operation.</param>
        internal Scanner(string source)
        {
            this.source = source;
        }

        /// <summary>
        /// Gets list of tokens.
        /// </summary>
        public List<Token> Tokens
        {
            get
            {
                return this.tokens;
            }
        }

        /// <summary>
        /// Separates string into tokens.
        /// </summary>
        /// <returns>List of tokens.</returns>
        internal List<Token> ScanTokens()
        {
            while (!this.IsAtEnd())
            {
                // Beginning of the next lexeme
                this.start = this.current;
                this.ScanToken();
            }

            this.tokens.Add(new Token(Token.TokenType.EQUAL, 0));
            return this.tokens;
        }

        private void ScanToken()
        {
            char c = this.Advance();
            switch (c)
            {
                case '(': this.AddToken(Token.TokenType.LEFT_PAREN); break;
                case ')': this.AddToken(Token.TokenType.RIGHT_PAREN); break;

                case '{': this.AddToken(Token.TokenType.LEFT_BRACE); break;
                case '}': this.AddToken(Token.TokenType.RIGHT_BRACE); break;

                case '^': this.AddToken(Token.TokenType.CARET); break;

                case '*': this.AddToken(Token.TokenType.STAR); break;
                case '/': case ':': this.AddToken(Token.TokenType.SLASH); break;

                case '+': this.AddToken(Token.TokenType.PLUS); break;
                case '-': this.AddToken(Token.TokenType.MINUS); break;

                case '=': this.AddToken(Token.TokenType.EQUAL); break;
                case ' ': this.AddToken(Token.TokenType.WHITESPACE); break;

                default:
                    if (this.IsDigit(c))
                    {
                        this.Number();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                    break;
            }
        }

        private void Number()
        {
            while (this.IsDigit(this.Peek()))
            {
                this.Advance();
            }

            // Look for fractional part.
            if (this.Peek() == '.' && this.IsDigit(this.PeekNext()))
            {
                // Consume the "."
                this.Advance();

                while (this.IsDigit(this.Peek()))
                {
                    this.Advance();
                }
            }

            this.AddToken(Token.TokenType.NUMBER, Convert.ToDouble(this.source.Substring(this.start, this.current - this.start)));
        }

        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private void AddToken(Token.TokenType type, double value = 0)
        {
            // Grabs text of the current lexeme and creates a new token for it.
            this.tokens.Add(new Token(type, value));
        }

        private char Advance()
        {
            // consumes the next character in the source and returns it.
            return this.source[this.current++];
        }

        private char Peek()
        {
            // It lookahead.
            if (this.IsAtEnd())
            {
                return '\0';
            }

            return this.source[this.current];
        }

        private char PeekNext()
        {
            // It look 2 characters ahead.
            if ((this.current + 1) >= this.source.Length)
            {
                return '\0';
            }

            return this.source[this.current + 1];
        }

        private bool IsAtEnd()
        {
            return this.current >= this.source.Length;
        }
    }
}