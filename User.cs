using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public List<String> GetContactByCity(string city)
        {
            List<String> citylist = new List<String>();
            foreach (AddressBook name in users.Values)
            {
                foreach (Contact person in name.GetContacts())
                {
                    if (person.City == city)
                    {
                        citylist.Add(person.Fname);
                    }
                }
            }

            return citylist;
        }

        public List<String> GetContactByState(string state)
        {
            List<String> statelist = new List<String>();
            foreach (AddressBook name in users.Values)
            {
                foreach (Contact person in name.GetContacts())
                {
                    if (person.State == state)
                    {
                        statelist.Add(person.Fname);
                    }
                }
            }
            return statelist;
        }

        public Dictionary<String,List<String>> cityDictionaryFinder()
        {
            Dictionary<String, List<String>> cityDictionary = new Dictionary<string, List<string>>();
            List<string> citylist = new List<string>();
            foreach(AddressBook name in users.Values)
            {
                foreach(Contact person in name.GetContacts())
                {
                    citylist.Add(person.City);
                }
            }
            citylist=citylist.Distinct().ToList();
            foreach(String city in citylist)
            {
                List<string> citylists = GetContactByCity(city);
                cityDictionary.Add(city, citylists);
            }
            return cityDictionary;
        }

        public Dictionary<String, List<String>> stateDictionaryFinder()
        {
            Dictionary<String, List<String>> stateDictionary = new Dictionary<string, List<string>>();
            List<string> statelist = new List<string>();
            foreach (AddressBook name in users.Values)
            {
                foreach (Contact person in name.GetContacts())
                {
                    statelist.Add(person.City);
                }
            }
            statelist = statelist.Distinct().ToList();
            foreach (String state in statelist)
            {
                List<string> statelists = GetContactByCity(state);
                stateDictionary.Add(state, statelists);
            }
            return stateDictionary;
        }

        // Export contacts to a text file
        public void ExportToFile()
        {
            string path = @"F:\\LOCOBUZZ\\Day 10\\Address Book System\\addressbook.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(String bookName in users.Keys)
                {
                    AddressBook name = users[bookName];
                    int slNo = 1;
                    writer.WriteLine($"Address Book : {bookName}");
                    foreach (Contact contact in name.GetContacts())
                    {
                        writer.WriteLine($"{slNo++}. Name: {contact.Fname} {contact.Lname}");
                        writer.WriteLine($"  Address: {contact.Address}, {contact.City}, {contact.State}");
                        writer.WriteLine($"  Phone: {contact.Phonenumber}");
                        writer.WriteLine($"  Email: {contact.Email}");
                        writer.WriteLine();
                    }
                }
            }
        }

    }
}
