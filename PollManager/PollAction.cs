using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace PollManager
{
    public class PollAction
    {
        private static int _id;
        public PollAction(List<Poll> pollList)
        {
            if (pollList.Count <= 0)
            {
                _id = 0;
            }
            else
            {
                _id = pollList.Last().Id;
            }
            
            _id++;
        }

        public void Update(List<Poll> pollList)
        {
            var update = JsonSerializer.Serialize(pollList);
            File.WriteAllText(path: "PollList.json", update);
        }
        public Poll AddPoll()
        {
            
            Console.Write("Name of poll = ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Incorrect input ");
                return null;
            }

            var questionsCount = 1;
            Console.WriteLine("How many questions will be in this poll");
            if (!int.TryParse(Console.ReadLine(), out questionsCount))
            {
                Console.WriteLine("Incorrect input ,  count must be integer ");
                return null;
            }
            string[] questions = new string[questionsCount];
            List<VariantAnswers> answers = new List<VariantAnswers>();
            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine( $"Input question number {i+1}");
                questions[i] = Console.ReadLine();
                Console.WriteLine("This question will have some variants of answer ? ");
                Console.WriteLine("If Yes , press Y , else press any another key  ");
                var isVariable = Console.ReadKey();
                if (isVariable.Key == ConsoleKey.Y)
                {
                    var variants = 2;
                    Console.WriteLine("How many variants answer this question will have ?");
                    if (!int.TryParse(Console.ReadLine(), out variants))
                    {
                        Console.WriteLine("Incorrect input ,  count must be integer ");
                        return null;
                    }

                    VariantAnswers variant = new VariantAnswers();
                    variant.IndexQuestion = i;
                    string[] variantsAnswer = new string[variants];
                    for (int k = 0; k < variants; k++)
                    {
                        Console.WriteLine($"Insert {k + 1} variant ");
                        variantsAnswer[k] =  Console.ReadLine();
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
                VariantAnswers = answers

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