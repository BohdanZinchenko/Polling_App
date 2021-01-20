using System;
using System.Collections.Generic;
using System.Linq;


namespace ClassPollLibrary
{
    public class PollManagerMenu
    {
        private int _choseNum;
        private readonly List<Poll> _pollList;

        public PollManagerMenu(List<Poll> pollList)
        {
            _pollList = pollList;
        }
        public void ShowMenu()
        {
            
            while (true)
            {
                var stat = new StatShow();
                var action = new PollAction(_pollList);
                Console.WriteLine("1: Add poll ");
                Console.WriteLine("2: Delete poll");
                Console.WriteLine("3: Poll statistic");
                Console.WriteLine("4: Exit");
                while (!int.TryParse(Console.ReadLine(), out _choseNum) && _choseNum <= 0 || _choseNum > 4)
                {
                    Console.WriteLine("Error input , chose something from 1 to 4");
                }

                switch (_choseNum)
                {
                    case 1:
                        _pollList.Add(action.AddPoll());
                        if (_pollList.Last() == null) _pollList.Remove(_pollList.Last());
                        Update.UpdateFile(_pollList);
                        break;
                    case 2:
                        _pollList.Remove(action.PollDelete(_pollList));
                        Update.UpdateFile(_pollList);
                        break;
                    case 3:
                        stat.ShowStat(_pollList);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("You choose wrong command ,chose something from 1 to 4");
                        break;

                }
            }
        }
    }
}