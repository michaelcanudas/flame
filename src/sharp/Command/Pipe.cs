namespace sharp
{
    public class Pipe
    {
        public static Token[] Run(string input, Lexer lexer)
        {
            lexer.Lex(input, out Token[] tokens);
            return tokens;
        }

        public static Node Run(Token[] tokens, Parser parser)
        {
            parser.Parse(tokens, out Node root);
            return root;
        }

        public static Node Run(string input, Lexer lexer, Parser parser)
        {
            lexer.Lex(input, out Token[] tokens);
            parser.Parse(tokens, out Node root);
            return root;
        }

        public static File Run(Token[] tokens, Parser parser, Generator generator)
        {
            parser.Parse(tokens, out Node root);
            generator.Generate(root, out File file);
            return file;
        }

        public static File Run(Node root, Generator generator)
        {
            generator.Generate(root, out File file);
            return file;
        }

        public static File Run(string input, Lexer lexer, Parser parser, Generator generator)
        {
            lexer.Lex(input, out Token[] tokens);
            parser.Parse(tokens, out Node root);
            generator.Generate(root, out File file);
            return file;
        }
    }
}
