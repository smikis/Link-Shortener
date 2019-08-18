using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Api.Domain.UrlHasher
{
    public class UrlBaseEncoder
    {
        private static string Characters { get; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly int _base = Characters.Length;
        
        public string EncodeUrl(long seed)
        {
            Stack<long> hashDigits = new Stack<long>();
            while (seed > 0)
            {
                var remainder = seed % _base;
                seed = seed / _base;
                hashDigits.Push(remainder);
            }

            StringBuilder builder = new StringBuilder();
            foreach (var number in hashDigits)
            {
                builder.Append(Characters[(int)number]);
            }

            return builder.ToString();
        }

        public long DecodeUrl(string number)
        {
            var reverseNumber = number.Reverse().ToArray();
            long result = 0;
            for (var i = 0; i < reverseNumber.Length; i++)
            {
                var position = Characters.IndexOf(reverseNumber[i]);
                result += position * (long)Math.Pow(_base, i);
            }

            return result;
        }
    }
}