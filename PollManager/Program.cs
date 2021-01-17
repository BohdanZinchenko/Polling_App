using System;

namespace PollManager
{
    class Program
    {
        static void Main(string[] args)
        {
            PollManagerMenu menu = new PollManagerMenu();
            menu.ShowMenu();
        }
    }
}
