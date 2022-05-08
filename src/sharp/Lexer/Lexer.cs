using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace sharp
{
    public class Lexer
    {
        public void Lex(string input, out Token[] tokens)
        {
            var tokenList = new List<Token>();

            var current = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i])) 
                    continue;
                
                current += input[i];
                if (i == input.Length - 1)
                    continue;

                var multi = (current + input[i + 1]) switch
                {
                    "->" or "::" => current + input[i + 1],
                    var word when Regex.IsMatch(word, @"^[a-zA-Z][a-zA-Z0-9]*$") => current + input[i + 1],
                    var str when Regex.IsMatch(str, @"^""[^""]*""?$") => current + input[i + 1],
                    var number when Regex.IsMatch(number, @"^((\d+\.\d*)|(\d*\.\d+)|(\d+))$") => current + input[i + 1],
                    _ => current
                };

                if (current == multi)
                {
                    tokenList.Add(new Token(current));
                    current = "";
                }
            }

            tokens = tokenList.ToArray();
        }
    }
}
