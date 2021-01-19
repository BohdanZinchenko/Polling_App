using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Channels;


namespace ClassPollLibrary
{
    public class RegistrationPerson : Person
    { 
       
        private int _phone;
        private string _password;

        public void Update(List<RegistrationPerson> listPeople)
        {
            var update = JsonSerializer.Serialize(listPeople);
            File.WriteAllText(path: "Data.json", update);
        }
        public RegistrationPerson Registration()
        {
            
            Console.Write("What is your name ?   ");
            var name = Console.ReadLine();
            
            if (string.IsNullOrEmpty(name.Trim()))
            {
                Console.WriteLine("Cant be empty");
                return null;
            }

            Console.Write("What is your last name ?  ");
            var lastName = Console.ReadLine();
            
            if (string.IsNullOrEmpty(lastName.Trim()))
            {
                Console.WriteLine("Cant be empty");
                return null;
            }
            Console.Write("What is your age ?  ");

            if (!int.TryParse(Console.ReadLine(), out var age) || age > 120  || age <= 0)
            {
                Console.WriteLine("Incorrect input , age must be correct ");
                return null;
            }
            if (age <= 5)
            {
                Console.WriteLine("Sorry but you are too young");
                return null;
            }
            Console.Write("Your gender ? (Male/Female)   ");

            var gender = Console.ReadLine();
            if (gender != "Male" || gender != "Female")
            {
                Console.WriteLine("Sorry but you must have standard gender ");
                return null;
            }

            var isMan = gender == "Male";

            Console.Write( "Your phone number ? (Without country code (must have 9 symbols ))  ");
            if (!int.TryParse(Console.ReadLine(), out var phone) || phone.ToString().Length != 9)
            {
                Console.WriteLine("incorrect phone number ");
                return null;
            }

            Console.Write("Create a password ");
            var password = Console.ReadLine();
            
            if (string.IsNullOrEmpty(password.Trim()))
            {
                Console.WriteLine("Cant be empty");
                return null;
            }
            
            RegistrationPerson registeredPerson = new RegistrationPerson()
            {
                FirstName = name.Trim(),
                LastName = lastName.Trim(),
                Age = age,
                IsGenderMan = isMan,
                _phone = phone,
                _password = password.Trim()

            };
            return registeredPerson;
        }

        public RegistrationPerson LoginIn(List<RegistrationPerson> listPeople)
        {

            Console.Write("Pls input your phone number  ");

            if (!int.TryParse(Console.ReadLine(), out var phone) || phone.ToString().Length != 9)
            {
                Console.WriteLine("incorrect phone number ");
                return null;
            }

            Console.Write("Pls input your password  ");
            var password = Console.ReadLine();
            if (string.IsNullOrEmpty(password.Trim()))
            {
                Console.WriteLine("Cant be empty");
                return null;
            }

            var account = listPeople.Select(x=>x).Single(x => x._password == password && x._phone == phone);
            return account;




        }
    }

    
}