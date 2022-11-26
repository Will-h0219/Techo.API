using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.Models;

namespace Techo.Data.Helpers
{
    public static class HashHelper
    {
        public static ResultadoHash Hash(string planeText)
        {
            var salt = new byte[16];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return Hash(planeText, salt);
        }

        public static ResultadoHash Hash(string planeText, byte[] salt)
        {
            var derivedKey = KeyDerivation.Pbkdf2(password: planeText,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32);

            var hash = Convert.ToBase64String(derivedKey);

            return new ResultadoHash()
            {
                Hash = hash,
                Sal = salt
            };
        }
    }
}
