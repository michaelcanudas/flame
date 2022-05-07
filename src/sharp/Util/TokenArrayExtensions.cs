namespace sharp
{
    public static class TokenArrayExtensions
    {
        public static void Add(this Token[] tokens, int i, ref string current)
        {
            tokens[i] = new Token(current);
            current = "";
        }
    }
}
