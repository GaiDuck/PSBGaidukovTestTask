using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaidukov_PSB_TestTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matchResults = { "3:  1", "2:2", "0  :1", "4:2", "3:a", "3- 12", "3f:4", "1:12", ":11" };
            int aTeamTotalResult = 0;
            int bTeamTotalResult = 0;

            foreach (string matchResult in matchResults)
            {
                Console.Write($"({matchResult}) ");
            }

            Console.WriteLine("\n");

            foreach (string matchResult in matchResults) 
            {
                int position = matchResult.IndexOf(":");

                Console.Write($"Матч ({matchResult})");

                if (position < 0)
                {
                    Error();
                    continue;
                }

                bool firstParsed = int.TryParse(matchResult.Substring(0, position), out int aTeamResult);
                bool secondParsed = int.TryParse(matchResult.Substring(position+1), out int bTeamResult);

                if (!firstParsed || !secondParsed)
                {
                    Error();
                    continue;
                }

                if (aTeamResult > bTeamResult)
                {
                    Console.WriteLine(" - победила команда А.");
                    aTeamTotalResult += 3;
                }
                else if (aTeamResult == bTeamResult)
                {
                    Console.WriteLine(" - ничья.");
                    aTeamTotalResult++;
                    bTeamTotalResult++;
                }
                else
                {
                    Console.WriteLine(" - победила команда Б.");
                    bTeamTotalResult += 3;
                }

                Console.WriteLine($"Текущие результаты: у команды А {aTeamTotalResult} очков, у команды Б {bTeamTotalResult} очков.");
            }

            void Error()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nДанные не корректны.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nИтоговые результаты турнира: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"У команды А {aTeamTotalResult} очков, у команды Б {bTeamTotalResult} очков.");
            Console.ForegroundColor = ConsoleColor.Blue;

            if (aTeamTotalResult > bTeamTotalResult)
            {
                Console.WriteLine("Победила команда А.");
            }
            else if (aTeamTotalResult == bTeamTotalResult)
            {
                Console.WriteLine("Турнир закончился ничьей.");
            }
            else
            {
                Console.WriteLine("Победила команда Б.");
            }

            Console.ReadKey();
        }
    }
}
