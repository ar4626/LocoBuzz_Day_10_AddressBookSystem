using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        class Validator
        {
            public string checkValidName(string name)
            {
                string namePattern = @"^[A-Za-z'-]+$";
                bool isValidName = Regex.IsMatch(name, namePattern);
                while (!isValidName)
                {
                    Console.WriteLine("Enter a valid Name, donot use special character");
                    name = Console.ReadLine();
                    isValidName = Regex.IsMatch(name, namePattern);
                }
                return name;
            }

            public string checkValidAddress(string address)
            {
                string addressPattern = "[0-9A-Za-z\\s',.-]+";
                bool isValidName = Regex.IsMatch(address, addressPattern);
                while (!isValidName)
                {
                    Console.WriteLine("Enter a valid Name, donot use special character");
                    address = Console.ReadLine();
                    isValidName = Regex.IsMatch(address, addressPattern);
                }
                return address;
            }

            public string checkPhoneNumber(string phoneNumber)
            {
                string phoneNumberPattern = "^[6-9]\\d{9}$";
                bool isValidName = Regex.IsMatch(phoneNumber, phoneNumberPattern);
                while (!isValidName)
                {
                    Console.WriteLine("Enter a valid Phone Number, donot use country code.");
                    phoneNumber = Console.ReadLine();
                    isValidName = Regex.IsMatch(phoneNumber, phoneNumberPattern);
                }
                return phoneNumber;

            }

            public string checkEmail(string email)
            {
                string emailPattern = "^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;]{0,1}\\s*)+$";
                bool isValidEmail = Regex.IsMatch(email, emailPattern);
                while (!isValidEmail)
                {
                    Console.WriteLine("Enter a valid Email {abc@def.com} ");
                    email = Console.ReadLine();
                    isValidEmail =  Regex.IsMatch(email, emailPattern);
                }
                return email;
            }

        }


        class AddressBook:Validator
        {
            
            List<Contact> contacts = new List<Contact>();
            public void addContact()
            {

                Console.WriteLine("Enter the first name: ");
                string fname = checkValidName(Console.ReadLine());
                if (contacts.Any(c => c.Fname.Equals(fname)))
                {
                    Console.WriteLine($"Contact with name {fname} already exists. Duplicate entry not allowed.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    return;
                }

                Console.WriteLine("Enter the last name: ");
                string lname = checkValidName(Console.ReadLine());

                Console.WriteLine("Enter the address: ");
                string add = checkValidAddress(Console.ReadLine()); 

                Console.WriteLine("Enter the city: ");
                string city = checkValidName(Console.ReadLine());

                Console.WriteLine("Enter the state: ");
                string state = checkValidName(Console.ReadLine()); 

                Console.WriteLine("Enter the Phone: ");
                string phone = checkPhoneNumber(Console.ReadLine());

                Console.WriteLine("Enter the email: ");
                string email = checkEmail(Console.ReadLine());

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
                    Console.WriteLine("Contact not found. Enter a valid Name");
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
                            existing.Fname = checkValidName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Enter the New Last Name : ");
                            existing.Lname = checkValidName(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter the New Phone Number : ");
                            existing.Phonenumber = checkPhoneNumber(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter the New Email : ");
                            existing.Email = checkEmail(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter the New Address : ");
                            existing.Address = checkValidAddress(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter the New City : ");
                            existing.City = checkValidName(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Enter the New State : ");
                            existing.State = checkValidName(Console.ReadLine());
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

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.");

            User newUser = new User();
            bool isRunning = true;

            

            while (isRunning)
            {
                Console.WriteLine("Enter an Option to perform : ");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Select User and User Address Book Operations");
                Console.WriteLine("3. Display Users");
                Console.WriteLine("4. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the User: ");
                        string userName = Console.ReadLine();

                        AddressBook newAddressBook = new AddressBook();
                        newUser.addUser(userName);

                        Console.Clear();
                        Console.WriteLine($"User {userName} added successfully with a new Address Book.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        
                        bool a = true;
                        int count = 0;
                        while (a)
                        {

                            Console.WriteLine("Address Book Operations for " + userName);
                            Console.WriteLine("1.Add Contact");
                            Console.WriteLine("2.Delete Contact");
                            Console.WriteLine("3.Update Contact");
                            Console.WriteLine("4.Display Contacts");
                            Console.WriteLine("5 Exit");

                            int opt = Convert.ToInt32(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    count++;
                                    Console.Clear();
                                    Console.WriteLine("Add Details: \n");
                                    newAddressBook.addContact();
                                    break;

                                case 2:
                                    count--;
                                    Console.Clear();
                                    Console.WriteLine("Enter the Email of the contact ot be Deleted.");
                                    string email = Console.ReadLine();
                                    newAddressBook.deleteContact(email);
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Enter the Name of the contact to be Edited. ");
                                    string sname = Console.ReadLine();
                                    newAddressBook.editContact(sname);
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine($"Contacts for {newUser}\n");
                                    newAddressBook.displayContacts();
                                    break;
                                case 5:
                                    if (count > 0)
                                    {
                                        a = false;
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Atleast enter one contact.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        Console.WriteLine("Add Details: \n");
                                        newAddressBook.addContact();
                                        break;
                                    }
                            }
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("User List");
                        foreach (var user in newUser.GetUser().Keys)
                        {
                            Console.WriteLine(user);
                        }
                        Console.WriteLine("...........................");
                        Console.WriteLine("Enter the name of the User: ");
                        string selectedUserName = Console.ReadLine();

                        Console.Clear();
                        if (newUser.GetUser().ContainsKey(selectedUserName))
                        {
                            AddressBook book1 = newUser.getAddressBook(selectedUserName);
                            bool b = true;
                            while (b)
                            {
                                Console.WriteLine("Address Book Operations for " + selectedUserName);
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
                                            Console.WriteLine($"Contacts for {selectedUserName}\n");
                                            book1.displayContacts();
                                            break;
                                        case 5:
                                            b = false;
                                            break;
                                    }
                                }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"User {selectedUserName} not found.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Users\n");
                        foreach(var user in newUser.GetUser().Keys)
{
                            Console.WriteLine(user);
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
