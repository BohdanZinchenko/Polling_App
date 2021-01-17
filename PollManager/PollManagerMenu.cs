using System;


namespace PollManager
{
    public class PollManagerMenu
    {
        private int _choseNum;

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1: Add poll ");
                Console.WriteLine("2: Delete poll");
                Console.WriteLine("3: Poll statistic");
                Console.WriteLine("4: Exit");
                while (!int.TryParse(Console.ReadLine(), out _choseNum) && _choseNum <= 0 || _choseNum > 4)
                {
                    Console.WriteLine("Error input , chose something from 1 to 5");
                }

                switch (_choseNum)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
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