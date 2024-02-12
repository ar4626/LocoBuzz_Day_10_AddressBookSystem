using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Contact
    {
        private string fname;
        private string lname;
        private string address;
        private string city;
        private string state;
        private string phonenumber;
        private string email;

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Contact(string fname, string lname, string address, string city, string state, string phonenumber, string email)
        {
            Fname = fname;
            Lname = lname;
            Address = address;
            City = city;
            State = state;
            Phonenumber = phonenumber;
            Email = email;
        }
    }
}
