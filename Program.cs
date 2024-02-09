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
                Console.WriteLine("4. Search Users based on City / State");
                Console.WriteLine("5. Get Dictionary of User by City / State");
                Console.WriteLine("6. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the User: ");
                        string userName = Console.ReadLine();

                        //AddressBook newAddressBook = new AddressBook();
                        newUser.addUser(userName);

                        AddressBook book1 = newUser.getAddressBook(userName);

                        Console.Clear();
                        Console.WriteLine($"User {userName} added successfully with a new Address Book.");
                        Thread.Sleep(1000);
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
                            Console.WriteLine("5.Sort Contacts");
                            Console.WriteLine("6 Exit");

                            int opt = Convert.ToInt32(Console.ReadLine());

                            switch (opt)
                            {
                                case 1:
                                    count++;
                                    Console.Clear();
                                    Console.WriteLine("Add Details: \n");
                                    book1.addContact();
                                    break;

                                case 2:
                                    count--;
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
                                    Console.WriteLine($"Contacts for {newUser}\n");
                                    book1.displayContacts();
                                    break;
                                case 5:
                                    book1.sortContact();
                                    Console.WriteLine("Contact Sorted ");
                                    Thread.Sleep(1000); 
                                    Console.Clear();
                                    break;
                                case 6:
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
                                        book1.addContact();
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
                            AddressBook book2 = newUser.getAddressBook(selectedUserName);
                            bool b = true;
                            while (b)
                            {
                                Console.WriteLine("Address Book Operations for " + selectedUserName);
                                Console.WriteLine("1.Add Contact");
                                Console.WriteLine("2.Delete Contact");
                                Console.WriteLine("3.Update Contact");
                                Console.WriteLine("4.Display Contacts");
                                Console.WriteLine("5.Sort Contacts");
                                Console.WriteLine("6 Exit");

                                int opt = Convert.ToInt32(Console.ReadLine());
                                switch (opt)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("Add Details: \n");
                                            book2.addContact();
                                            break;

                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("Enter the Email of the contact ot be Deleted.");
                                            string email = Console.ReadLine();
                                            book2.deleteContact(email);
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("Enter the Name of the contact to be Edited. ");
                                            string sname = Console.ReadLine();
                                            book2.editContact(sname);
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine($"Contacts for {selectedUserName}\n");
                                            book2.displayContacts();
                                            break;
                                        case 5:
                                            book1.sortContact();
                                            Console.WriteLine("Contact Sorted ");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            break;
                                        case 6:
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
                        Console.Clear();
                        bool q = true;
                        while (q)
                        {
                            Console.WriteLine("Filter Operation for person based on .");
                            Console.WriteLine("1.City");
                            Console.WriteLine("2.State");
                            Console.WriteLine("3.Exit");
                            int filterOption = Convert.ToInt32(Console.ReadLine());
                            switch (filterOption)
                            {
                                case 1:
                                    Console.WriteLine("Enter the name of City.");
                                    string cityName = Console.ReadLine();
                                    Console.Clear();
                                    List<string> userList = newUser.GetContactByCity(cityName);
                                    Console.Clear();
                                    if(userList.Count > 0)
                                    {
                                        Console.WriteLine($"List of Person for city :- {cityName}");
                                        foreach (String person in userList)
                                        {
                                            Console.WriteLine(person);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There is no person living in city :- {cityName}");
                                    }
                                    
                                    Console.ReadLine();

                                    break;
                                case 2:
                                    Console.WriteLine("Enter the name of State.");
                                    string stateName = Console.ReadLine();
                                    Console.Clear();
                                    List<string> stateuserList = newUser.GetContactByState(stateName);
                                    Console.Clear();
                                    if (stateuserList.Count > 0)
                                    {
                                        Console.WriteLine($"List of Person for State :- {stateName}");
                                        foreach(String person in stateuserList)
                                        {
                                            Console.WriteLine(person);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There is no person living in city :- {stateName}");
                                    }

                                    Console.ReadLine(); break;
                                case 3:
                                    q= false;
                                    Console.Clear();    
                                    break;
                            }
                        }

                        break;

                    case 5:
                        Console.Clear();
                        bool w = true;
                        while (w)
                        {
                            Console.WriteLine("Get Dictionary of People by City / State : ");
                            Console.WriteLine("1.City");
                            Console.WriteLine("2.State");
                            Console.WriteLine("3.Exit");
                            int filterOption = Convert.ToInt32(Console.ReadLine());
                            switch (filterOption)
                            {
                                case 1:
                                    Dictionary<String, List<string>> cityDictionary=newUser.cityDictionaryFinder();
                                    Console.Clear();
                                    Console.WriteLine("Dictionary of City");
                                    if (cityDictionary.Count > 0)
                                    {
                                        foreach (string city in cityDictionary.Keys)
                                        {
                                            Console.Write(city + $" ({cityDictionary[city].Count} Person) : ");
                                            foreach (String people in cityDictionary[city])
                                            {
                                                Console.Write($"{people}, ");
                                            }
                                            Console.WriteLine("\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("City Dictionary is Empty.");
                                    }
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Dictionary<String, List<string>> stateDictionary = newUser.stateDictionaryFinder();
                                    Console.Clear();
                                    Console.WriteLine("Dictionary of State");
                                    if (stateDictionary.Count > 0)
                                    {
                                        foreach (string state in stateDictionary.Keys)
                                        {
                                            Console.Write(state + $" ({stateDictionary[state].Count} Person) : ");
                                            foreach (String people in stateDictionary[state])
                                            {
                                                Console.Write($"{people}, ");
                                            }
                                            Console.WriteLine("\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("State Dictionary is Empty.");
                                    }
                                    Console.ReadKey();
                                   break;
                                case 3:
                                    w = false;
                                    Console.Clear();
                                    break;
                            }
                        } break;

                    case 6:

                        isRunning = false;
                        break;
                }
            }           

        }
    }
}
