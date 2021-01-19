using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPollLibrary
{
    public class PersonMenuWork
    {
        private int _chooseMenu;
        private bool _firstWork =true;
        private RegistrationPerson _personAccount;
        public void StartMenu(List<RegistrationPerson> persons,List<Poll> pollList)
        {
            
            Console.WriteLine();
            while (_firstWork)
            {
                RegistrationPerson account = new RegistrationPerson();
                Console.WriteLine("1: Registration");
                Console.WriteLine("2: Login");
                Console.WriteLine("3: Exit");
                while (!int.TryParse(Console.ReadLine(), out _chooseMenu) && _chooseMenu <= 0 || _chooseMenu > 3)
                {
                    Console.WriteLine("Error input , chose something from 1 to 3");
                    break;
                }
                switch (_chooseMenu)
                {
                    case 1:
                        persons.Add(account.Registration(pollList,persons));
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
                        _personAccount = account;
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
                            _personAccount = account;
                            _firstWork = false;
                        }
                        break;
                    case 3:
                        return;
                    default:
                        continue;
                }
            }


        }

        public void AcceptPersonalInfo()
        {
            Console.WriteLine("Its app for social Poll");
            Console.WriteLine("Do you agree for use your personal information ?  (Press Y if Yes)");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Sorry you can't vote");
                return;
            }
        }

        public RegistrationPerson GetPerson()
        {
            return _personAccount;
        }
    }
}