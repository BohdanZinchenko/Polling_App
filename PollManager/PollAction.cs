using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;


namespace PollManager
{
    public class PollAction
    {
        private static int _id;
        public List<Poll> pollList;

        PollAction(List<Poll> pollList)
        {
            this.pollList = pollList;
            _id = pollList.Last().Id;
            _id++;
        }
        public void AddPoll()
        {
            Console.Write("Name of poll = ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Incorrect input ");
            }

            var questionsCount = 1;
            Console.WriteLine("How many questions will be in this poll");
            if (!int.TryParse(Console.ReadLine(), out questionsCount))
            {
                Console.WriteLine("Incorrect input ,  count must be integer ");
                return;
            }

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine( $"Input question number {i+1}");
                Console.ReadLine();
            }
        }
    }
    
}