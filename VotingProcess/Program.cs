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
            
            var wayToList = JsonSerializer.Deserialize<string>(ClassLinkForPoll.GetLink());
            var linkToList = File.ReadAllText(wayToList);
            var readPollList = JsonSerializer.Deserialize<List<Poll>>(linkToList);
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

            PersonMenuWork menu = new PersonMenuWork();
            menu.StartMenu(personList);
            var personAccount = menu.GetPerson();
            if (personAccount == null)
            {
                return;
            }
            AccountPollMenu pollWork = new AccountPollMenu();
            pollWork.MenuStart(personAccount, readPollList);
            
             




        }
    }
}
