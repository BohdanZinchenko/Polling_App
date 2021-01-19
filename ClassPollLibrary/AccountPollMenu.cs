using System;
using System.Collections.Generic;

namespace ClassPollLibrary
{
    public class AccountPollMenu
    {
        private int _chooseMenu;
        public void MenuStart(RegistrationPerson person,List<Poll> polList)
        {
            Console.WriteLine($"Welcome {person.FirstName}");
            Console.WriteLine($"Choose what you want to do ");

            while (true)
            {
                var accountWork = new AccountPollWork();
                Console.WriteLine("1: Vote ");
                Console.WriteLine("Exit");
                while (!int.TryParse(Console.ReadLine(), out _chooseMenu) && _chooseMenu <= 0 || _chooseMenu > 3)
                {
                    Console.WriteLine("Error input , chose something from 1 to 2");
                    break;
                }

                switch (_chooseMenu)
                {
                    case 1:
                        accountWork.MakePoll(polList,person);
                        break;
                    case 2:
                        return;


                }

            }
        }
    }
}