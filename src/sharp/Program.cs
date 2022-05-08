namespace sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // LexTest();
            Command.Handle(args);
        }

        private static void LexTest()
        {
            var source = @"
func main() -> {
    system::console::write(""Hello, world!"");
}
";

            var lexer = new Lexer();
            var parser = new Parser();
            var generator = new Generator();

            var tokens = Pipe.Run(
                source,
                lexer
                );

            for (int i = 0; i < tokens.Length; i++)
            {
                System.Console.WriteLine(tokens[i].Value);
            }
        }
    }
}
