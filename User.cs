using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class User
    {
        private Dictionary<string, AddressBook> users;

        public User()
        {
            users = new Dictionary<string, AddressBook>();
        }

        public void addUser(string name)
        {
            AddressBook book = new AddressBook();
            users.Add(name, book);
        }

        public void deleteUser(string name)
        {
            users.Remove(name);
        }

        public AddressBook getAddressBook(string name)
        {
            return users[name];
        }

        public Dictionary<string, AddressBook> GetUser()
        {
            return users;
        }

    }
}
