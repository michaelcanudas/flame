namespace sharp
{
    public class Command
    {
        public static void Handle(string[] args)
        {
            if (args.Length == 0) 
                InvalidArgCount.Throw();
            
            switch (args[0])
            {
                case "build":
                    Build.Handle(args);
                    break;
                case "lex":
                    Lex.Handle(args);
                    break;
            }
        }
    }
}
