using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace ClassPollLibrary
{
    public class StatShow
    {
        public struct FindElem
        {
            public int Count;
            public string Answer;
        }
        public void ShowStat(List<Poll> pollLIst)
        {
            if (pollLIst.Count <= 0)
            {
                Console.WriteLine("Poll list is empty , come back here later");
                return;
                
            }
            Console.WriteLine("From what poll you want to see stat ");
            var sortedPolList = pollLIst.Select(x => x).OrderBy(x => x.Id).ToList();
            sortedPolList.ForEach(x => Console.WriteLine($"{x.Id} poll :  { x.PollName }"));


            if (!int.TryParse(Console.ReadLine(), out var idPoll))
            {
                Console.WriteLine("Incorrect input , age must be correct ");
                return;
            }

            Poll selectedPoll;
            try
            {
                selectedPoll = pollLIst.Select(x => x).Single(x => x.Id == idPoll);
            }
            catch
            {
                Console.WriteLine("Error input , you must choose id ");
                return;
            }

            if (selectedPoll.Stat.Votes <= 0)
            {
                Console.WriteLine("Sorry but no body have vote for this poll yet");
                return;
            }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("       Global statistic about voters ");

            Console.WriteLine();

            Console.WriteLine($"\t    Count of all votes ");
            Console.WriteLine($"\t           {selectedPoll.Stat.Votes}");

            Console.WriteLine();

            Console.Write("      To 18    From 18 to 30    More 30 ");
            Console.WriteLine();
            Console.WriteLine($"Men     {selectedPoll.Stat.ManTo18}   \t     {selectedPoll.Stat.ManFrom18To30}    \t  {selectedPoll.Stat.ManFrom30}");
            
            Console.WriteLine();
            Console.WriteLine($"Women   {selectedPoll.Stat.WomanTo18}   \t     {selectedPoll.Stat.WomanFrom18To30}    \t  {selectedPoll.Stat.WomanFrom30}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("       Statistic about answers    ");
            Console.WriteLine();

            var index = 0;
            foreach (var question in selectedPoll.Questions)
            {
                var count = 0;
                var findElem = new FindElem();
                Console.WriteLine($"For the question {question} ");
                
                try
                {
                    foreach (var x in selectedPoll.Stat.Answers)
                    {

                        foreach (var y in selectedPoll.Stat.Answers)
                        {
                            if (x.VariantAnswer[index] == y.VariantAnswer[index])
                            {
                                count++;
                            }
                            if (count >= findElem.Count)
                            {
                                findElem.Count = count;
                                findElem.Answer = x.VariantAnswer[index];
                            }
                        }

                    }
                    Console.WriteLine($"Most popular answer was {findElem.Answer}");
                    Console.WriteLine();
                    index++;
                }
                catch
                {

                }
            }

            
            





        }
    }
}