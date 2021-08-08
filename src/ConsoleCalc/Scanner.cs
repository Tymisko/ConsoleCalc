// TODO: sqrt, power etc.
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsoleCalc.Tests")] // allows internal class to being tested.

namespace ConsoleCalc
{
    internal class Scanner
    {
        string source;
        internal List<Token> tokens = new List<Token>();
        private int start = 0;
        private int current = 0;

        internal Scanner(string source)
        {
            this.source = source;
        }

        internal List<Token> scanTokens()
        {
            while(!isAtEnd())
            {
                // Beginning of the next lexeme
                start = current;
                scanToken();
            }

            tokens.Add(new Token(Token.TokenType.EOF, 0));
            return tokens;
        }

        private void scanToken()
        {
            char c = advance();
            switch(c)
            {
                case '(': addToken(Token.TokenType.LEFT_PAREN); break;
                case ')': addToken(Token.TokenType.RIGHT_PAREN); break;

                case '{': addToken(Token.TokenType.LEFT_BRACE); break;
                case '}': addToken(Token.TokenType.RIGHT_BRACE); break;

                case '*': addToken(Token.TokenType.STAR); break;
                case '/': case ':': addToken(Token.TokenType.SLASH); break;

                case '+': addToken(Token.TokenType.PLUS); break;
                case '-': addToken(Token.TokenType.MINUS); break;
                
                case ' ': addToken(Token.TokenType.WHITESPACE); break;

                default:
                    if(isDigit(c))
                    {
                        number();
                    }
                    else 
                    {
                        throw new ArgumentException();
                    }
                    break;
            }            
        }

        private void number()
        {
            while(isDigit(peek())) advance();

            // Look for fractional part.
            if (peek() == '.' && isDigit(peekNext()))
            {
                // Consume the "."
                advance();

                while(isDigit(peek())) advance();
            }

            addToken(Token.TokenType.NUMBER, Convert.ToDouble(source.Substring(start, current-start)));
        }

        private bool isDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private void addToken(Token.TokenType type, double value = 0)
        {
            // Grabs text of the current lexeme and creates a new token for it.
            tokens.Add(new Token(type, value));
        }

        private char advance() 
        {
            // consumes the next character in the source and returns it.
            return source[current++];
        }
        private char peek()
        {
            // It lookahead.
            if (isAtEnd()) return '\0';
            return source[current];
        }
        private char peekNext()
        {
            // It look 2 characters ahead.
            if((current+1) >= source.Length) return '\0';
            return source[current+1];
        }
        private bool isAtEnd()
        {
            return current >= source.Length;
        }
    }
} 