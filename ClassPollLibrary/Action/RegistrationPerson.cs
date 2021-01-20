using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;



namespace ClassPollLibrary
{
    public class RegistrationPerson : PersonAccount
    { 
        
        public void Update(List<RegistrationPerson> listPeople)
        {
            var update = JsonSerializer.Serialize(listPeople);
            File.WriteAllText("Accounts.json", update);
        }
        public RegistrationPerson Registration(List<Poll> pollList , List<RegistrationPerson> listPeople)
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
            Console.Write("Your gender ? (Male(M)/Female(F)) ");
            var gender = Console.ReadKey();
            bool isMan;
            switch (gender.Key)
            {
                case ConsoleKey.M:
                    isMan = true;
                    break;
                case ConsoleKey.F:
                    isMan = false;
                    break;
                default:
                    Console.WriteLine("Sorry but you must have standard gender ");
                    return null;
            }
            Console.WriteLine();

            Console.Write( "Your phone number ? (Without country code (must have 9 symbols ))  ");
            if (!int.TryParse(Console.ReadLine(), out var phone) || phone.ToString().Length != 9)
            {
                Console.WriteLine("incorrect phone number ");
                return null;
            }
           
            try
            {
                var registered = listPeople.Select(x => x).Where(x => x.Phone == phone);
                if (registered.Any())
                {
                    Console.WriteLine("This account is already registered");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Some Add another account with the same login directly in file ");
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
                Phone = phone,
                Password = password.Trim()

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
            RegistrationPerson account;
            try
            { 
                var acs = listPeople.Select(x => x).Where(x => x.Phone == phone && x.Password == password);
                account = acs.Single();
            }
            catch
            {
                return null;
            }
            return account;




        }
    }

    
}