using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilLabbar.Lab7
{
    class Account
    {
        public string Username { get;  }
        public string Password { get; }
        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public static Account FromString(string line)
        {
            string []parts = line.Split(' ');
            var account = new Account(parts[0], parts[1]);
            return account;
        }

        public string ToString()
        {
            return string.Format($"{Username} {Password}");
        }

    }
}
