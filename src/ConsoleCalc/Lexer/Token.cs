// <copyright file="Token.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>
namespace ConsoleCalc
{
    /// <summary>
    /// Represents the smallest element of mathematical operation.
    /// </summary>
    public class Token
    {
        private TokenType type;
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="type">Type of token.</param>
        /// <param name="value">Value of token.</param>
        public Token(TokenType type, double value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Contains supported types of tokens.
        /// </summary>
        public enum TokenType
        {
            /// <summary>Represents '('.</summary>
            LEFT_PAREN,

            /// <summary>Represents ')'.</summary>
            RIGHT_PAREN,

            /// <summary>Represents '{'.</summary>
            LEFT_BRACE,

            /// <summary>Represents '}'.</summary>
            RIGHT_BRACE,

            /// <summary>Represents '^' that is raising to power operator.</summary>
            CARET,

            /// <summary>Represents '*' that is multiplication operator.</summary>
            STAR,

            /// <summary>Represents '/' that is division operator.</summary>
            SLASH,

            /// <summary>Represents '+' that is addition operator.</summary>
            PLUS,

            /// <summary>Represents '-' that is subtraction operator.</summary>
            MINUS,

            /// <summary>Represents "number" token type</summary>
            NUMBER,

            /// <summary>Represents whitespaces tokens type</summary>
            WHITESPACE,

            /// <summary>Represents '='</summary>
            EQUAL,
        }

        /// <summary>
        /// Gets token type.
        /// </summary>
        public TokenType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets value of token.
        /// </summary>
        public double Value
        {
            get
            {
                return this.value;
            }
        }
    }
}