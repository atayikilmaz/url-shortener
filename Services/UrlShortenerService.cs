using System;
using System.Security.Cryptography;
using System.Text;

namespace urlShortener.Services
{
    public class UrlShortenerService
    {
        private const int ShortUrlLength = 7; 
        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create(); 

        public string GenerateShortenedUrl(string longUrl)
        {
            string baseUrl = "https://pielyn.com/"; 
            string uniqueCode = GenerateUniqueIdentifier(longUrl);

            return uniqueCode;
        }

        private string GenerateUniqueIdentifier(string longUrl)
        {
            // Hashing original url
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(longUrl));

            // Creating random 7 letter code from hash
            StringBuilder stringBuilder = new StringBuilder(ShortUrlLength);
            for (int i = 0; i < ShortUrlLength; i++)
            {
                int randomIndex = RandomByte(hashBytes.Length);
                stringBuilder.Append(Base62EncodeChar(hashBytes[randomIndex]));
            }

            return stringBuilder.ToString();
        }

        
        private int RandomByte(int maxValue)
        {
            byte[] randomBytes = new byte[4];
            Rng.GetBytes(randomBytes);
            return Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % maxValue;
        }

        private char Base62EncodeChar(byte b)
        {
            const string base62Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return base62Chars[b % 62];
        }
    }
}