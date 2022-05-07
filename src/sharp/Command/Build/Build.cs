namespace sharp
{
    public class Build
    {
        public static void Handle(string[] args)
        {
            if (args.Length < 3) InvalidArgCount.Throw();

            var input = args[1];
            var lexer = new Lexer();
            var parser = new Parser();
            var generator = new Generator();

            var output = Pipe.Run(input, lexer, parser, generator);
            OutputFile(args, output);
        }

        private static void OutputFile(string[] args, File output)
        {
            if (args.Length < 3) InvalidArgCount.Throw();

            var hSize = output.Header.Length;
            var iSize = output.Instructions.Length;
            var dSize = output.Data.Length;
            var size = hSize + iSize + dSize;

            var bytes = new byte[size];
            for (int i = 0; i < hSize; i++) bytes[i] = output.Header[i];
            for (int i = 0; i < iSize; i++) bytes[hSize + i] = output.Instructions[i];
            for (int i = 0; i < dSize; i++) bytes[hSize + iSize + i] = output.Header[i];

            System.IO.File.Create(args[2]);
            System.IO.File.WriteAllBytes(args[2], bytes);
        }
    }
}
