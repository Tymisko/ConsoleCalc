// Takes in a raw source as a series of characters and groups it into a series of chunks called tokens.
using System;
using System.Collections.Generic;

namespace ConsoleCalc
{
    public class Token
    {
        public Token(TokenType type, string lexeme, object literal)
        {
            this.type = type;       
            this.lexeme = lexeme;   
            this.literal = literal;   
        }

        public enum TokenType
        {
            LEFT_PAREN, RIGHT_PAREN,
            LEFT_BRACE, RIGHT_BRACE,
            STAR, SLASH,
            PLUS, MINUS,
            NUMBER,
            EOF
        }

        internal TokenType type; // type of token
        internal string lexeme;  // token's value
        internal object literal; // token's literal value
        
        public override string ToString()
        {
            return $"{type} {lexeme} {literal}";
        }
    }
}