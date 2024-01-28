using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
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
                get { return address;}
                set { address = value; }
            }
            public string City
            {
                get { return city; }
                set { city = value; }
            }
            public string State
            {
                get { return state;}
                set { state = value; }
            }
            public string Phonenumber
            {
                get { return phonenumber;}
                set { phonenumber = value; }
            }
            public string Email
            {
                get { return email;}
                set { email = value; }
            }




        }

        class AddressBook
        {

            List<Contact> contacts = new List<Contact>();
            public void addContact()
            {
                Console.WriteLine("Enter the first name: ");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter the last name: ");
                string lname = Console.ReadLine();
                Console.WriteLine("Enter the address: ");
                string add = Console.ReadLine();
                Console.WriteLine("Enter the city: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter the state: ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter the Phone: ");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter the email: ");
                string email = Console.ReadLine();

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
                Thread.Sleep(1000);
                Console.Clear() ;
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
                Console.Clear ();   
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
                    Console.WriteLine("Contact not found.");
                }
                else {
                    displayaContact(existing);
                    Console.WriteLine();
                    Console.WriteLine("Enter the option to edit : ");
                    Console.WriteLine("1. First Name\n2. Last Name\n3. Phone Number\n4. Email\n5. Address\n6. City\n7. State\n");
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Enter the New First Name : ");
                            existing.Fname = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the New Last Name : ");
                            existing.Lname = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter the New Phone Number : ");
                            existing.Phonenumber = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter the New Email : ");
                            existing.Email = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter the New Address : ");
                            existing.Address = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter the New City : ");
                            existing.City = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter the New State : ");
                            existing.State = Console.ReadLine();
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
                else { 
                    contacts.Remove(existing);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Contact deleted Successfully");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        class Person
        {
            private Dictionary<string, AddressBook> persons;

            public Person()
            {
                persons = new Dictionary<string, AddressBook>();   
            }

            public void addPerson(string name)
            {
                AddressBook book = new AddressBook();
                persons.Add(name, book);
            }

            public void deletePerson(string name)
            {
                persons.Remove(name);
            }

            public AddressBook getAddressBook(string name)
            {
                return persons[name];
            }

            public Dictionary<string, AddressBook> GetPersons()
            {
                return persons;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.");

            Person newPerson = new Person();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Enter an Option to perform : ");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. Select Person and Perform Address Book Operations");
                Console.WriteLine("3. Display Persons");
                Console.WriteLine("4. Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the person: ");
                        string personName = Console.ReadLine();

                        AddressBook newAddressBook = new AddressBook();
                        newPerson.addPerson(personName);

                        Console.Clear();
                        Console.WriteLine($"Person {personName} added successfully with a new Address Book.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the person: ");
                        string selectedPersonName = Console.ReadLine();

                        Console.Clear();
                        if (newPerson.GetPersons().ContainsKey(selectedPersonName))
                        {
                            AddressBook book1 = newPerson.getAddressBook(selectedPersonName);
                            bool a = true;
                            while (a)
                            {
                                Console.WriteLine("Address Book Operations for " + selectedPersonName);
                                Console.WriteLine("1.Add Contact");
                                Console.WriteLine("2.Delete Contact");
                                Console.WriteLine("3.Update Contact");
                                Console.WriteLine("4.Display Contacts");
                                Console.WriteLine("5 Exit");
                                
                                int opt = Convert.ToInt32(Console.ReadLine());
                                switch (opt)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("Add Details: \n");
                                            book1.addContact();
                                            break;

                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("Enter the Email of the contact ot be Deleted.");
                                            string email = Console.ReadLine();
                                            book1.deleteContact(email);
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("Enter the Name of the contact to be Edited. ");
                                            string sname = Console.ReadLine();
                                            book1.editContact(sname);
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine($"Contacts for {selectedPersonName}\n");
                                            book1.displayContacts();
                                            break;
                                        case 5:
                                            a = false;
                                            break;
                                    }
                                }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Person {selectedPersonName} not found.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Persons\n");
                        foreach(var person in newPerson.GetPersons().Keys)
{
                            Console.WriteLine(person);
                        }
                        Console.ReadLine();
                        break;

                    case 4:
                        isRunning = false;
                        break;
                }
            }           

        }
    }
}
