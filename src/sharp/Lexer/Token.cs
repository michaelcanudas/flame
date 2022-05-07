using System.Text.RegularExpressions;

namespace sharp
{
    public struct Token
    {
        public string Value;
        public TokenKind Kind;
        public TokenCategory Category;

        public Token(string value)
        {
            Value = value;
            Kind = TokenKind.None;
            Category = TokenCategory.None;

            Kind = GetKindAndCategory().kind;
            Category = GetKindAndCategory().category;
        }

        private (TokenKind kind, TokenCategory category) GetKindAndCategory()
        {
            return Value switch
            {
                "func" => (TokenKind.Func, TokenCategory.Keyword),
                ";" => (TokenKind.Semicolon, TokenCategory.Symbol),
                "(" => (TokenKind.LeftParenthesis, TokenCategory.Symbol),
                ")" => (TokenKind.RightParenthesis, TokenCategory.Symbol),
                "{" => (TokenKind.RightBracket, TokenCategory.Symbol),
                "}" => (TokenKind.LeftBracket, TokenCategory.Symbol),
                "->" => (TokenKind.Pointer, TokenCategory.Symbol),
                var word when Regex.IsMatch(word, @"^[a-zA-Z][a-zA-Z0-9]*$") => (TokenKind.Identifier, TokenCategory.Identifier),
                var number when Regex.IsMatch(number, @"^((\d+\.\d*)|(\d*\.\d+)|(\d+))$") => (TokenKind.Number, TokenCategory.Literal),
                _ => (TokenKind.None, TokenCategory.None)
            };
        }

        public enum TokenKind
        {
            None,
            Func,
            Semicolon,
            LeftParenthesis,
            RightParenthesis,
            LeftBracket,
            RightBracket,
            Pointer,
            Identifier,
            Number,
            Null
        }

        public enum TokenCategory
        {
            None,
            Keyword,
            Symbol,
            //Operator,
            //Type,
            Identifier,
            Literal,
            Util
        }
    }
}
