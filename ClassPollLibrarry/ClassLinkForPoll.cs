using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace ClassPollLibrary
{
    public static class ClassLinkForPoll
    {
        
        public   static  string GetLink()
        {
            var file = File.ReadAllText($"{TryGetSolutionDirectoryInfo()}\\ClassPollLibrary\\Link.Json");
            return file;
        }

        public static void SetLink()
        {
            var wayToFile = $"{TryGetSolutionDirectoryInfo()}\\ClassPollLibrary\\Link.Json";
            var linkInfo = JsonSerializer.Serialize(Path.GetFullPath("PollList.json"));
            File.WriteAllText(wayToFile, linkInfo);

        }
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}