using System;

namespace PollManager
{
    public class PersonMenuWork
    {
        public void StartMenu()
        {
            Console.WriteLine("Its app for social Poll");
            Console.WriteLine("Do you agree for use your personal information ? ");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Sorry you can't vote");
                return;
            }

            RegistrationPerson person = new RegistrationPerson();
            person.Registration();

        }
    }
}