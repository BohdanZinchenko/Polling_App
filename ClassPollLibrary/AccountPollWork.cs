using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPollLibrary
{
    public class AccountPollWork
    {
        public void WriteStat(Poll poll, RegistrationPerson person)
        {
            poll.Stat.Votes++;
            switch (person.IsGenderMan)
            {
                case false:
                    if (person.Age < 18)
                    {
                        poll.Stat.WomanTo18++;
                    }
                    else if (person.Age >= 18 && person.Age <=30)
                    {
                        poll.Stat.WomanFrom18To30++;
                    }
                    else
                    {
                        poll.Stat.WomanFrom30++;
                    }
                    break;
                case true:
                    if (person.Age < 18)
                    {
                        poll.Stat.ManTo18++;
                    }
                    else if (person.Age >= 18 && person.Age <= 30)
                    {
                        poll.Stat.ManFrom18To30++;
                    }
                    else
                    {
                        poll.Stat.ManFrom30++;
                    }
                    break;
            }
        }

        public void WriteAnswerStat(Poll poll, RegistrationPerson person,string[] answers)
        {
            var answersPuck = new ReadyAnswers
            {
                VariantAnswer = answers,
                Age = person.Age,
                IsMan = person.IsGenderMan
            };
            poll.Stat.Answers.Add(answersPuck); 
        }
        public void MakePoll(List<Poll> polList, RegistrationPerson person)
        {
            Console.WriteLine("Select a poll what you want to start  ");
            var sortedPolList = polList.Select(x => x).OrderBy(x => x.Id).ToList();
            sortedPolList.ForEach(x=>Console.WriteLine($"{x.Id} poll :  { x.PollName }" ));
            
            
            if (!int.TryParse(Console.ReadLine(), out var idPoll))
            {
                Console.WriteLine("Incorrect input , age must be correct ");
                return;
            }
            

            Poll selectedPoll;
            try
            {
                selectedPoll = polList.Select(x => x).Single(x => x.Id == idPoll);
            }
            catch
            {
                Console.WriteLine("Error input , you must choose id ");
                return;
            }

            if (selectedPoll.PassedLogins.Contains(person.Phone))
            {
                Console.WriteLine("You have been voted in this poll , choose another one ");
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

            selectedPoll.PassedLogins.Add(person.Phone);
            WriteStat(selectedPoll, person);
            WriteAnswerStat(selectedPoll, person, answers);
            var newPoll = selectedPoll;
            polList.Remove(selectedPoll);
            polList.Add(newPoll);
            Update.UpdateFile(polList);





        }
    }
}
