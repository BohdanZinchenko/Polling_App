using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using PollManager;


namespace VotingProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            var wayToLink = JsonSerializer.Deserialize<string>(ClassLinkForPoll.GetLink());
            var linkToList = File.ReadAllText(wayToLink);
            var readfile = JsonSerializer.Deserialize<List<Poll>>(linkToList);
        }
    }
}
