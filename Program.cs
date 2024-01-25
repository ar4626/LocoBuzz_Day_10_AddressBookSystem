using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {

        class Contact
        {
            public string fname;
            public string lname;
            public string address;
            public string city;
            public string state;
            public string phonenumber;
            public string email;

            /*Contact(string fname, string lname, string address, string city, string state, string phonenumber, string email)
            {
                this.fname = fname;
                this.lname = lname;
                this.address = address;
                this.city = city;
                this.state = state;
                this.phonenumber = phonenumber;
                this.email = email;
            }*/
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.");
            List<Contact> addressBook = new List<Contact>();

            Contact newContact = new Contact
            {
                fname = "Ankit",
                lname = "Raj",
                address = "asdf",
                city = "HZB",
                state = "jh",
                phonenumber = "12345",
                email = "asdf@example.com"
            };

        }
    }
}
