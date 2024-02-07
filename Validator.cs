using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Validator
    {
        public string CheckValidName(string name)
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

        public string CheckValidAddress(string address)
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

        public string CheckPhoneNumber(string phoneNumber)
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

        public string CheckEmail(string email)
        {
            string emailPattern = "^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;]{0,1}\\s*)+$";
            bool isValidEmail = Regex.IsMatch(email, emailPattern);
            while (!isValidEmail)
            {
                Console.WriteLine("Enter a valid Email {abc@def.com} ");
                email = Console.ReadLine();
                isValidEmail = Regex.IsMatch(email, emailPattern);
            }
            return email;
        }

    }
}
