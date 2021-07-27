// Takes in a raw source as a series of characters and groups it into a series of chunks called tokens.

using System.Collections.Generic;

namespace ConsoleCalc
{
    class Scanner
    {
        string source;
        List<Token> tokens = new List<Token>();
        int start = 0;
        int current = 0;
        int index = 1;

        Scanner(string source)
        {
            this.source = source;
        }

        List<Token> scanTokens()
        {
            while(!isAtEnd())
            {
                start = current;
                scanTokens();
            }

            tokens.Add(new Token(Token.TokenType.EOF, "", null, index));
            return tokens;
        }
        private bool isAtEnd()
        {
            return current >= source.Length;
        }
    }
} 