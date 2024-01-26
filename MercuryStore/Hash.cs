using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MercuryStore
{
    class Hash
    {
        //Hash (SHA256) method
        public static string Hash_SHA256(string s)
        {
            string hash = String.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }
            return hash;
        }
    }
}
