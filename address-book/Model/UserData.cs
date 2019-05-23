using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_tests
{
    public class UserData
    {
        private string name;
        private string password;
        public UserData(string name, string password)
        {
            Username = name;
            Password = password;
        }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
