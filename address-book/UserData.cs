using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_tests
{
    class UserData
    {
        private string name;
        private string password;
        public UserData(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public string Username
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
