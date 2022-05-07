namespace sharp
{
    public class Generator
    {
        public void Generate(Node input, out File file)
        {
            file = new File();
            PEHeader p = new PEHeader();
        }
    }

    public struct File
    {
        public byte[] Header;
        public byte[] Instructions;
        public byte[] Data;
    }
}
