using System;
using System.Diagnostics.CodeAnalysis;


namespace PollManager
{
    public class RegistrationPerson : Person
    { 
       
        private int _phone;
        private string _password;


        public void Registration()
        {
            
            Console.Write("What is your name ?   ");
            var name = Console.ReadLine();

            Console.Write("What is your last name ?  ");
            var lastName = Console.ReadLine();
            Console.Write("What is your age ?  ");

            if (!int.TryParse(Console.ReadLine(), out var age) || age > 120  || age <= 0)
            {
                Console.WriteLine("Incorrect input , age must be correct ");
                return;
            }
            if (age <= 5)
            {
                Console.WriteLine("Sorry but you are too young");
                return;
            }
            Console.Write("Your gender ? (Male/Female)   ");

            var gender = Console.ReadLine();
            if (gender != "Male" || gender != "Female")
            {
                Console.WriteLine("Sorry but you must have standard gender ");
                return;
            }

            var isMan = gender == "Male";

            Console.Write( "Your phone number ? (Without country code (must have 9 symbols ))  ");
            if (!int.TryParse(Console.ReadLine(), out var phone) || phone.ToString().Length != 9)
            {
                Console.WriteLine("incorrect phone number ");
                return;
            }

            Console.Write("Create a password ");
            var password = Console.ReadLine();

            firstName = name;
            this.lastName = lastName;
            this.age = age;
            isGenderMan = isMan;
            _phone = phone;
            _password = password;
        }

    }
}