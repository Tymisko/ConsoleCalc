// <copyright file="TokenStream.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>
namespace ConsoleCalc
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Is a stream of tokens.
    /// </summary>
    public class TokenStream
    {
        private int current = 0;
        private bool full = false;
        private Token buffer;
        private List<Token> tokens;
        private TextWriter errorWriter = Console.Error;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenStream"/> class.
        /// </summary>
        /// <param name="tokens">List of scanned tokens by Scanner class.</param>
        public TokenStream(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        /// <summary>
        /// Gets next token from stream.
        /// </summary>
        /// <returns>Token from token's list.</returns>
        public Token Get()
        {
            if (this.full)
            {
                this.full = false;
                return this.buffer;
            }

            return this.tokens[this.current++];
        }

        /// <summary>
        /// Puts token back to stream. Stores it in buffer.
        /// </summary>
        /// <param name="currentToken">Token that will be stored in buffer.</param>
        public void PutBack(Token currentToken)
        {
            if (currentToken.Type != Token.TokenType.WHITESPACE)
            {
                if (this.full)
                {
                    this.errorWriter.WriteLine("Putback executed when bufor is full.");
                    throw new ArgumentException();
                }

                this.buffer = currentToken;
                this.full = true;
            }
        }

        /// <summary>
        /// Look forward to check what is next token.
        /// </summary>
        /// <returns>Next token without incrementing 'current' iterator.</returns>
        /// <param name="steps">Amount of steps to look forward.</param>
        public Token LookForward()
        {
            if (!this.IsAtEnd())
            {
                return this.tokens[this.current];
            }
            else
            {
                throw new IndexOutOfRangeException("Look forward while at end.");
            }
        }

        /// <summary>
        /// Increases token stream iterator.
        /// </summary>
        /// <param name="steps">Amount of steps to go forward.</param>
        public void Forward(int steps)
        {
            this.current += steps;
        }

        /// <summary>
        /// Checks if token stream is at the end of token list.
        /// </summary>
        /// <returns>Returns boolean if iterator is at end of token lists.</returns>
        public bool IsAtEnd()
        {
            return this.current >= this.tokens.Count - 1;
        }
    }
}