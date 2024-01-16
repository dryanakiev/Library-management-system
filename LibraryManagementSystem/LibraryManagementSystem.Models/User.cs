using LibraryManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        private int _id;
        private string _usename;
        private string _password;
        private string _name;
        private string _email;
        private string _salt;

        public User() 
        {
            _id = 0;
            _usename = string.Empty;
            _password = string.Empty;
            _name = string.Empty;
            _email = string.Empty;
            _salt = string.Empty;
        }

        public User(int id, string usename, string password, string name, string email, string salt)
        {
            _id = id;
            _usename = usename;
            _password = password;
            _name = name;
            _email = email;
            _salt = GenerateSalt.GenerateRandomSalt();
        }

        public int Id { get;set; }
        public string Username { get;set; }
        public string Password 
        {
            get { return _password; }
            set { _password = PasswordEncryption.XORCipher(value, _salt); }
        }
        public string Name { get;set; }
        public string Email { get;set; }
        public string Salt { get; }
    }
}
