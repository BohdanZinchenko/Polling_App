using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ClassPollLibrary
{
    public static class Update
    {
        public static void  UpdateFile(List<Poll> pollList)
        {
            var update = JsonSerializer.Serialize(pollList);
            File.WriteAllText(ClassLinkForPoll.GetPollLink(), update);
        }
    }
}