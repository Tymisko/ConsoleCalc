// Takes in a raw source as a series of characters and groups it into a series of chunks called tokens.
using System;
using System.Collections.Generic;

namespace ConsoleCalc
{
    public class Token
    {
        public Token(TokenType type, double value)
        {
            this.type = type;       
            this.value = value;
        }

        public enum TokenType
        {
            LEFT_PAREN, RIGHT_PAREN,
            LEFT_BRACE, RIGHT_BRACE,
            CARET,
            STAR, SLASH,
            PLUS, MINUS,
            NUMBER,
            WHITESPACE,
            EOF
        }

        internal TokenType type; // type of token
        internal double value; // value of token
        
        public override string ToString()
        {
            return $"{type} {value}";
        }
    }
}