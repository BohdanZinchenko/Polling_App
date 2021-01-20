
using System.IO;
using System.Linq;


namespace ClassPollLibrary
{
    public static class ClassLinkForPoll
    {
        
        public  static  string GetPollLink()
        {
            var link= $"{TryGetSolutionDirectoryInfo()}\\ClassPollLibrary\\PollList.Json";
            return link;
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