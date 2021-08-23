// <copyright file="TokenStream.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>
namespace ConsoleCalc.Lexer
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// TokenStream is a stream of scanned tokens by <see cref="Scanner.ScanTokens()"/>. It is neccesary for properly working Parser.
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
        /// <param name="tokens">List of scanned tokens by <see cref="Scanner.ScanTokens()"/>.</param>
        public TokenStream(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        /// <summary>
        /// Gets next token from <see cref="tokens"/> if <see cref="buffer"/> is empty.
        /// </summary>
        /// <returns>Next element of <see cref="TokenStream.tokens"/>.</returns>
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
        /// Puts token to <see cref="buffer"/>.
        /// </summary>
        /// <param name="currentToken">Token that will be stored in <see cref="buffer"/>.</param>
        public void PutBack(Token currentToken)
        {
                if (this.full)
                {
                    throw new ArgumentException("Putback executed when bufor is full.");
                }

                this.buffer = currentToken;
                this.full = true;
        }

        /// <summary>
        /// Looks forward to check next token from <see cref="tokens"/> without incrementing <see cref="current"/> iterator.
        /// </summary>
        /// <returns>Next token of <see cref="tokens"/>.</returns>
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
        /// Increment <see cref="current"/> that is stream iterator.
        /// </summary>
        public void Forward()
        {
            this.current++;
        }

        /// <summary>
        /// Checks if <see cref="current"/> is at the end of <see cref="tokens"/>.
        /// </summary>
        /// <returns>True or False.</returns>
        public bool IsAtEnd()
        {
            return this.current >= this.tokens.Count - 1;
        }
    }
}