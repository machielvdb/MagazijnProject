using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public string sha256encrypt(string password, string salt)
        {
            string saltAndPassword = string.Concat(password, salt);
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedBytes = sha256hasher.ComputeHash(encoder.GetBytes(saltAndPassword));
            string hashedpassword = string.Concat(GetHashString(hashedBytes), salt);
            return hashedpassword;
        }
        public bool VerifyHash(string password, string salt, string storedpassword)
        {
            var newHash = sha256encrypt(password, salt);
            return (storedpassword == newHash);
        }

        public string GetHashString(byte[] hash)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < hash.Length; i++)
            {
                output.Append(hash[i].ToString("X2"));
            }
            return output.ToString();
        }

        public byte[] GetHashBytes(string hash) => Convert.FromBase64String(hash);
    }
}