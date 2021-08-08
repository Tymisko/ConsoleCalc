using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleCalc
{
    class TokenStream
    {
        private int current = 0;
        private bool full = false;
        private Token buffer;
        private List<Token> tokens;
        public TokenStream(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        public Token get() // get token from stream
        {
            if(full)
            {
                full = false;
                return buffer;
            }
            return tokens[current++];
        }
        public void putback(Token currentToken) // put token back to stream
        {
            if(full) 
            { 
                errorWriter.WriteLine("Putback executed when bufor is full.");
                throw new ArgumentException();
            }
            buffer = currentToken;
            full = true;
        }
        private TextWriter errorWriter = Console.Error;
    }
}