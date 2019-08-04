using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Api.Domain.UrlHasher
{
    public class UrlBaseEncoder
    {
        private string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string EncodeUrlInBase62(long seed)
        {
            Stack<long> hashDigits = new Stack<long>();
            while (seed > 0)
            {
                var remainder = seed % 62;
                seed = seed / 62;
                hashDigits.Push(remainder);
            }

            StringBuilder builder = new StringBuilder();
            foreach (var number in hashDigits)
            {
                builder.Append(characters[(int)number]);
            }

            return builder.ToString();
        }
    }
}