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
            List<RegistrationPerson> PersonList;
            try
            {
                PersonList = JsonSerializer.Deserialize<List<RegistrationPerson>>(@"Accounts.json");
            }
            catch
            {
                Console.WriteLine("You will be first person in this program , congratulation");
                PersonList = new List<RegistrationPerson>();
            }

            
            


        }
    }
}
