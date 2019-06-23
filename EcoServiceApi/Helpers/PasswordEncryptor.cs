using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Helpers
{
    public static class PasswordEncryptor
    {
        private static string _salt = "f1nd1ngn3m0";
        private const int SaltSize = 128;
        private const int PasswordHashSize = 256;
        private const int ByteSize = 8;

        /// <summary>
        /// Generates encrypted string for password using salt.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            var saltBytes = Convert.FromBase64String(_salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: PasswordHashSize / ByteSize));
        }
    }
}
