using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;

namespace MagazijnProject
{
    public class Hashing
    {
        public byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        public byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 1;
            argon2.MemorySize = 1024 * 1024; // 1 GB
            return argon2.GetBytes(16);
        }
        public bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        public string GetHashString(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }

        public byte[] GetHashBytes(string hash)
        {
            return Convert.FromBase64String(hash);
        }
    }
}