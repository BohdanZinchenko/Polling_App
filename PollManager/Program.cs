using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace PollManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var readFile = new List<Poll>();
            try
            {
                readFile  = JsonSerializer.Deserialize<List<Poll>>(File.ReadAllText( path:"PollList.json")); 
            }
            catch
            {
               Console.WriteLine("Cant find poll list , will be created new one");
            }

            PollManagerMenu menu = new PollManagerMenu(readFile);
            menu.ShowMenu();
            ClassLinkForPoll.SetLink();
        }
    }
}
