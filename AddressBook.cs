using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class AddressBook : Validator
    {

        List<Contact> contacts = new List<Contact>();
        public void addContact()
        {

            Console.WriteLine("Enter the first name: ");
            string fname = CheckValidName(Console.ReadLine());
            if (contacts.Any(c => c.Fname.Equals(fname)))
            {
                Console.WriteLine($"Contact with name {fname} already exists. Duplicate entry not allowed.");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }

            Console.WriteLine("Enter the last name: ");
            string lname = CheckValidName(Console.ReadLine());

            Console.WriteLine("Enter the address: ");
            string add = CheckValidAddress(Console.ReadLine());

            Console.WriteLine("Enter the city: ");
            string city = CheckValidName(Console.ReadLine());

            Console.WriteLine("Enter the state: ");
            string state = CheckValidName(Console.ReadLine());

            Console.WriteLine("Enter the Phone: ");
            string phone = CheckPhoneNumber(Console.ReadLine());

            Console.WriteLine("Enter the email: ");
            string email = CheckEmail(Console.ReadLine());

            Contact newCon = new Contact
            {
                Fname = fname,
                Lname = lname,
                Address = add,
                City = city,
                State = state,
                Phonenumber = phone,
                Email = email
            };
            contacts.Add(newCon);

            //contacts = contacts.OrderBy(obj => obj.Fname).ToList();

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Contact Added Successfully");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void displayContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Fname} {contact.Lname}");
                Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State}");
                Console.WriteLine($"Phone: {contact.Phonenumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void displayaContact(Contact contact)
        {
            Console.WriteLine($"First Name : {contact.Fname}");
            Console.WriteLine($"Last Name : {contact.Lname}");
            Console.WriteLine($"Phone Number : {contact.Phonenumber}");
            Console.WriteLine($"Email : {contact.Email}");
            Console.WriteLine($"Address : {contact.Address}");
            Console.WriteLine($"City : {contact.City}");
            Console.WriteLine($"State : {contact.State}");
        }

        public void editContact(string fname)
        {
            Contact existing = contacts.Find(c => c.Fname.Equals(fname));
            //Console.WriteLine(existing.fname);
            if (existing == null)
            {
                Console.WriteLine("Contact not found. Enter a valid Name");
            }
            else
            {
                displayaContact(existing);
                Console.WriteLine();
                Console.WriteLine("Enter the option to edit : ");
                Console.WriteLine("1. First Name\n2. Last Name\n3. Phone Number\n4. Email\n5. Address\n6. City\n7. State\n");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Enter the New First Name : ");
                        existing.Fname = CheckValidName(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Enter the New Last Name : ");
                        existing.Lname = CheckValidName(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter the New Phone Number : ");
                        existing.Phonenumber = CheckPhoneNumber(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Enter the New Email : ");
                        existing.Email = CheckEmail(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Enter the New Address : ");
                        existing.Address = CheckValidAddress(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Enter the New City : ");
                        existing.City = CheckValidName(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("Enter the New State : ");
                        existing.State = CheckValidName(Console.ReadLine());
                        break;
                }
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Contact Editted Successfully.");
                Thread.Sleep(2000);
                Console.Clear();

                //displayContacts();

            }
        }

        public void deleteContact(string email)
        {
            Contact existing = contacts.Find(c => c.Email.Equals(email));
            //Console.WriteLine(existing.fname);
            if (existing == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                contacts.Remove(existing);
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Contact deleted Successfully");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
            
        public void sortContact(int a)
        {
            switch (a)
            {
                case 0: 
                    contacts = contacts.OrderBy(obj => obj.Fname).ToList();
                    break;
                case 1:
                    contacts = contacts.OrderBy(obj => obj.City).ThenBy(ob => ob.Fname).ToList();
                    break;
                case 2:
                    contacts = contacts.OrderBy(obj => obj.State).ThenBy(ob=>ob.Fname).ToList();
                    break;
                default:
                    Console.WriteLine("Please choose the Correct Option"); 
                    break;
            }
        }
        

        public List<Contact> GetContacts()
        {
            //Console.WriteLine("Contact returned"+ contacts.Count());
            return contacts;
        }
    }
}
