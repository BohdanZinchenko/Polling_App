using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPollLibrary
{
    public class AccountPollWork
    {
        public void MakePoll(List<Poll> polList)
        {
            Console.WriteLine("Select a poll what you want to start  ");
            polList.ForEach(x=>Console.WriteLine($"{x.Id} poll :  { x.PollName }" ));
            if (!int.TryParse(Console.ReadLine(), out var idPoll))
            {
                Console.WriteLine("Incorrect input , age must be correct ");
                return;
            }

            var selectedPoll = new Poll();
            try
            {
                selectedPoll = polList.Select(x => x).Single(x => x.Id == idPoll);
            }
            catch
            {
                Console.WriteLine("Error input , you must choose id ");
                return;
            }

            var answers = new string[selectedPoll.Questions.Length];
            
            
            for (var i = 0; i <= selectedPoll.Questions.Length-1; i++)
            {
                var index = 1;
                var variantAnswers = new VariantAnswers();
                Console.WriteLine(selectedPoll.Questions[i]);
                try
                {
                    variantAnswers = selectedPoll.VariantAnswers.Select(x => x).Single(x => x.IndexQuestion == i);
                    foreach (var answer in variantAnswers.VariantAnswer)
                    {
                        Console.WriteLine($"{index} : {answer}");
                        index++;
                    }
                }
                catch
                {

                }

                if (variantAnswers.VariantAnswer == null)
                {
                    answers[i] = Console.ReadLine();
                }
                else
                {
                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out var answerNum))
                        {
                            Console.WriteLine("Incorrect input , if you want and this poll , without save press 0 ");
                            continue;
                        }
                        if (answerNum == 0)
                        {
                            return;
                        }
                        try
                        {
                            answers[i] = variantAnswers.VariantAnswer[answerNum-1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Incorrect this id of answer, if you want and this poll , without save press 0 ");
                        }
                    }

                }


            }

                

        }
    }
}
