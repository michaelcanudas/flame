using System.Text.RegularExpressions;

namespace sharp
{
    public class Lexer
    {
        public void Lex(string input, out Token[] tokens)
        {
            tokens = new Token[input.Length];
            var pos = 0;

            var current = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i])) continue;
                if (i == input.Length - 1)
                {
                    tokens.Add(pos++, ref current);
                    continue;
                }

                current += input[i];
                var multi = (current + input[i + 1]) switch
                {
                    "->" => current + input[i + 1],
                    var word when Regex.IsMatch(word, @"^[a-zA-Z][a-zA-Z0-9]*$") => current + input[i + 1],
                    var number when Regex.IsMatch(number, @"^((\d+\.\d*)|(\d*\.\d+)|(\d+))$") => current + input[i + 1],
                    _ => current
                };

                if (current == multi) tokens.Add(pos++, ref current);
            }
        }
    }
}
