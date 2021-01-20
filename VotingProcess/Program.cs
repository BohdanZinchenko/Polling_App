using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using ClassPollLibrary;

namespace VotingProcess
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Poll> readPollList;
            try
            {
                readPollList = JsonSerializer.Deserialize<List<Poll>>(File.ReadAllText(ClassLinkForPoll.GetPollLink()));
            }
            catch
            {
                Console.WriteLine("We haven`t polls yet, pls come back later ");
                return;
            }
            
           
            List<RegistrationPerson> personList;
            try
            {
                var readFile = File.ReadAllText("Accounts.json");
                personList = JsonSerializer.Deserialize<List<RegistrationPerson>>(readFile);
            }
            catch
            {
                Console.WriteLine("You will be first person in this program , congratulation");
                personList = new List<RegistrationPerson>();
            }

            var ask = new PersonMenuWork();
            ask.AcceptPersonalInfo();
            while (true)
            {
                var menu = new PersonMenuWork();
                menu.StartMenu(personList, readPollList);
                var personAccount = menu.GetPerson();
                if (personAccount == null)
                {
                    return;
                }
                var pollWork = new AccountPollMenu();
                pollWork.MenuStart(personAccount, readPollList);
            }

            






        }
    }
}
