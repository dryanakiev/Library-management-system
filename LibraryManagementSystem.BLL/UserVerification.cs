using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class UserVerification
    {
        public static bool VerifyAccount(string username, string password)
        {
            User user = ExtractFromDatabase.FindUser(username);

            if(user == null)
            {
                return false;
            }

            string encryptedPassword = PasswordEncryption.XORCipher(password,user.Salt);

            if(user.Password == encryptedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
