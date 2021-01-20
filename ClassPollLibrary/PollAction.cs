using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace ClassPollLibrary
{
    public class PollAction
    {
        private static int _id;
        public PollAction(List<Poll> pollList)
        {
            _id = pollList.Count <= 0 ? 0 : pollList.Last().Id;
            _id++;
        }

        
        public Poll AddPoll()
        {
            
            Console.Write("Name of poll = ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name.Trim()))
            {
                Console.WriteLine("Cant be empty");
                return null;
            }

            Console.WriteLine("How many questions will be in this poll");
            if (!int.TryParse(Console.ReadLine(), out var questionsCount))
            {
                Console.WriteLine("Incorrect input ,  count must be integer ");
                return null;
            }

            if (questionsCount <= 0)
            {
                Console.WriteLine("incorrect input ");
                return null;
            } 

            var questions = new string[questionsCount];
            var answers = new List<VariantAnswers>();
            Console.WriteLine("Input your questions , if you want stop it , enter 'back'");
            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine( $"Input question number {i+1}");
                questions[i] = Console.ReadLine();
                if (string.IsNullOrEmpty(questions[i].Trim()))
                {
                    Console.WriteLine("Cant be empty");
                    i--;
                    continue;
                }
                if (questions[i] == "back")
                {
                    return null;
                }
                Console.WriteLine("This question will have some variants of answer ? ");
                Console.WriteLine("If Yes , press Y , else press any another key  ");

                var isVariable = Console.ReadKey();
                Console.WriteLine();

                if (isVariable.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("How many variants answer this question will have ?");
                    if (!int.TryParse(Console.ReadLine(), out var variants))
                    {
                        Console.WriteLine("Incorrect input ,  count must be integer ");
                        return null;
                    }

                    if (variants <= 0)
                    {
                        Console.WriteLine("Incorrect input ");
                        return null;
                    }

                    var variant = new VariantAnswers();
                    variant.IndexQuestion = i;
                    var variantsAnswer = new string[variants];
                    for (var k = 0; k < variants; k++)
                    {
                        Console.WriteLine($"Insert {k + 1} variant ");
                        variantsAnswer[k] =  Console.ReadLine();
                        if (string.IsNullOrEmpty(variantsAnswer[k].Trim()))
                        {
                            Console.WriteLine("Cant be empty");
                            k--;
                            continue;
                        }
                    }
                    variant.VariantAnswer = variantsAnswer;
                    answers.Add(variant);
                }
                Console.WriteLine();

            }

            var poll = new Poll()
            {
                Id = _id,
                PollName = name,
                Questions = questions,
                VariantAnswers = answers,
                Stat = new Statistic() { ManFrom18To30 = 0,ManFrom30 = 0,ManTo18 = 0,WomanFrom18To30 = 0,WomanFrom30 = 0,WomanTo18 = 0 ,Votes = 0,Answers = new List<ReadyAnswers>()},
                PassedLogins = new List<int>()
                
                
            };
            return poll;


        }

        public Poll PollDelete(List<Poll> pollList)
        {
            Console.Write("Input id of note what you want to find : ");
            var id = Console.ReadLine();

            var foundedElem = pollList.Find(x => x.Id.ToString() == id);
            if (foundedElem == null)
            {
                Console.WriteLine("Note with that id not founded ");
                return null;
            }
            
            Console.WriteLine($"Are you sure you want to delete {foundedElem.PollName} poll ? ");
            Console.WriteLine("Yes is Y / N is No");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Poll was deleted ");
                return foundedElem;
            }
            Console.WriteLine();

            return null;


        }
    }
    
}