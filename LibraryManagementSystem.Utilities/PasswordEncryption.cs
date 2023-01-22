using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryManagementSystem.Utilities
{
    public class PasswordEncryption
    {
        public static string XORCipher(string password, string key)
        {
            //var result = new StringBuilder();

            //for (int i = 0; i < password.Length; i++)
            //    result.Append((char)((uint)password[i] ^ (uint)key[i % key.Length]));

            //return result.ToString();

            return password;
        }
    }
}
