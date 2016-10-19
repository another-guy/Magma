using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Magma.AspNetCore.Rest
{
    public sealed class Random : IRandom
    {
        public string GenerateRandomString(uint length = 32, uint preferedBufferLength = 1024)
        {
            if (length < 1) throw new ArgumentException(nameof(length));

            using (var cryptoServiceProvider = RandomNumberGenerator.Create())
            {
                var result = new StringBuilder();
                var counter = 0;

                while (true)
                {
                    var randomBytes = new byte[preferedBufferLength];
                    cryptoServiceProvider.GetBytes(randomBytes);
                    foreach (var randomCharacter in Convert.ToBase64String(randomBytes))
                        if (IsAllowedCharacter(randomCharacter))
                        {
                            result.Append(randomCharacter);
                            counter++;
                            if (counter >= length)
                                return result.ToString();
                        }
                }
            }
        }

        private static bool IsAllowedCharacter(char character)
        {
            return (character >= 'a' && character <= 'z') ||
                (character >= 'A' && character <= 'Z') ||
                (character >= '0' && character <= '9') ||
                (WhiteListedNonAlphanumericCharacters.Contains(character));
        }

        private static List<char> WhiteListedNonAlphanumericCharacters =
            new List<char>() { '$', '-', '_', '.', '+', '!', '*', '(', ')', ',', '\'' };
    }
}
