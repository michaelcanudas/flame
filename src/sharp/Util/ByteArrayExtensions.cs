using System.Runtime.CompilerServices;

namespace sharp
{
    public static class ByteArrayExtensions
    {
        public static byte[] ToByteArray<T>(ref this T value) where T : unmanaged
        {
            byte[] result = new byte[Unsafe.SizeOf<T>()];
            Unsafe.CopyBlock(ref result[0], ref Unsafe.As<T, byte>(ref value), (uint)result.Length);

            return result;
        }
    }
}
