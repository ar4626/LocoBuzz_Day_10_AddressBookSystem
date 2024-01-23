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

        class AddressBook
        {
            private List<Contact> contacts;

            public AddressBook()
            {
                contacts = new List<Contact>();
            }

            public void addContact(Contact contact)
            {
                contacts.Add(contact);
            }

            public void displayContacts()
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.fname} {contact.lname}");
                    Console.WriteLine($"Address: {contact.address}, {contact.city}, {contact.state}");
                    Console.WriteLine($"Phone: {contact.phonenumber}");
                    Console.WriteLine($"Email: {contact.email}");
                    Console.WriteLine();
                }
            }

            public void editContact(string fname, Contact contact)
            {
                Contact existing = contacts.Find(c => c.fname.Equals(fname));
                //Console.WriteLine(existing.fname);
                if (existing == null)
                {
                    Console.WriteLine("Contact not found");
                }
                else { 
                    existing.fname = contact.fname;
                    existing.lname = contact.lname;
                    existing.address = contact.address;
                    existing.city = contact.city;
                    existing.state = contact.state;
                    existing.phonenumber = contact.phonenumber;
                    existing.email = contact.email;

                    displayContacts();

                }
            }
            public void deleteContact(string fname)
            {
                Contact existing = contacts.Find(c => c.fname.Equals(fname));
                //Console.WriteLine(existing.fname);
                if (existing == null)
                {
                    Console.WriteLine("Contact not found");
                }
                else { 
                    contacts.Remove(existing);

                    Console.WriteLine("Contact deleted Successfully");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.");
            List<Contact> addressBook = new List<Contact>();

            Contact newContact = new Contact
            {
                fname = "Ankit",
                lname = "Raj",
                address = "Ramnagar",
                city = "Hzb",
                state = "JH",
                phonenumber = "12345",
                email = "adsf@gmail.com"
            };

            AddressBook book1 = new AddressBook();

            book1.addContact(newContact);
            book1.displayContacts();

            Contact updated = new Contact
            {
                fname = "Ankit",
                lname = "Singh",
                address = "Ramnagar",
                city = "Hzb",
                state = "TN",
                phonenumber = "12345678",
                email = "adsfasdf@gmail.com"
            };

            Console.WriteLine("Enter the first name of the contact to edit: ");
            string firstName = Console.ReadLine();

            book1.editContact(firstName, updated);

            Console.WriteLine("Enter the first name of the contact to edit: ");
            string fName = Console.ReadLine();
            book1.deleteContact(fName);
            Console.ReadLine();

        }
    }
}
