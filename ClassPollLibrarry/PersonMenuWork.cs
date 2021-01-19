using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPollLibrary
{
    public class PersonMenuWork
    {
        private int _chooseMenu;
        private bool _firstWork =true;
        public void StartMenu(List<RegistrationPerson> persons)
        {
            Console.WriteLine("Its app for social Poll");
            Console.WriteLine("Do you agree for use your personal information ? ");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Sorry you can't vote");
                return;
            }

            while (_firstWork)
            {
                RegistrationPerson account = new RegistrationPerson();
                Console.WriteLine("1: Registration");
                Console.WriteLine("2: Login");
                while (!int.TryParse(Console.ReadLine(), out _chooseMenu) && _chooseMenu <= 0 || _chooseMenu > 2)
                {
                    Console.WriteLine("Error input , chose something from 1 to 2");
                }
                switch (_chooseMenu)
                {
                    case 1:
                        persons.Add(account.Registration());
                        if (persons.Last() == null)
                        {
                            persons.Remove(persons.Last());
                            continue;
                        }
                        else
                        {
                            account = persons.Last();
                        }
                        account.Update(persons);
                        _firstWork = false;
                        break;
                    case 2:
                        account = account.LoginIn(persons);
                        if (account == null)
                        {
                            Console.WriteLine("Incorrect login or password");
                        }
                        else
                        {
                            _firstWork = false;
                        }
                        break;
                }
            }


        }
    }
}