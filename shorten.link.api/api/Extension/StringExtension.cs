
using System.IO.Hashing;
using System.Text;

namespace api.Extension
{
    public static class StringExtension
    {
        public static string ToCRC32Hash(this string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            var hash = Crc32.Hash(bytes);
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}