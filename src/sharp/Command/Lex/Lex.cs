using System;

namespace sharp
{
    public class Lex
    {
        public static void Handle(string[] args)
        {
            if (args.Length < 2)
                InvalidArgCount.Throw();

            var input = args[1];
            var lexer = new Lexer();

            var output = Pipe.Run(input, lexer);
            OutputTokens(output);
        }

        private static void OutputTokens(Token[] output)
        {
            Console.WriteLine("[");
            for (int i = 0; i < output.Length; i++)
            {
                if (i != output.Length - 1)
                    Console.WriteLine(output[i].Value + ",");
                else
                    Console.WriteLine(output[i].Value);
            }
            Console.WriteLine("]");
        }
    }
}
