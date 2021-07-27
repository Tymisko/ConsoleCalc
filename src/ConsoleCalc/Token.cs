namespace ConsoleCalc
{
    public class Token
    {
        public Token(TokenType type, string lexeme, object literal, int index)
        {
            this.type = type;       
            this.lexeme = lexeme;   
            this.literal = literal; 
            this.index = index;     
        }

        public enum TokenType
        {
            LEFT_PAREN, RIGHT_PAREN,
            LEFT_BRACE, RIGHT_BRACE,
            STAR, SLASH,
            PLUS, MINUS,
            EOF
        }

        TokenType type; // type of token
        string lexeme;  // token's value
        object literal; // token's literal value
        int index;      // index of token's occurance

        public override string ToString()
        {
            return $"{type} {lexeme} {literal}";
        }
    }
}