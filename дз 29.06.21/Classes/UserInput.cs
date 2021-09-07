using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static дз_29._06._21.Program;

namespace дз_29._06._21.Classes
{
    class UserInput
    {
        static public int GetChoice(int minValue, int maxValue)
        {
            string choice;
            int intChoice = -1;
            do
            {
                choice = Console.ReadLine();
                if (IsInteger(choice))
                    intChoice = Convert.ToInt32(choice);
            } while (intChoice < minValue || intChoice > maxValue);
            return intChoice;
        }
        
        static public int GetInt()
        {
            string str = "1";
            do
            {
                str = Console.ReadLine();
            } while (!IsInteger(str));
            return Convert.ToInt32(str);
        }

        static public TimeSpan GetTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan();
            Console.Write("Введите дни: ");
            timeSpan = timeSpan.Add(new TimeSpan(GetInt(), 0, 0, 0));
            Console.Write("Введите часы: ");
            timeSpan = timeSpan.Add(new TimeSpan(0, GetInt(), 0, 0));
            Console.Write("Введите минуты: ");
            timeSpan = timeSpan.Add(new TimeSpan(0, 0, GetInt(), 0));
            return timeSpan;
        }
        static public DateTime GetDateTime()
        {
            DateTime dateTime = new DateTime();
            Console.Write("Введите год: ");
            dateTime = dateTime.AddYears(GetInt());
            Console.Write("Введите месяц: ");
            dateTime = dateTime.AddMonths(GetInt());
            Console.Write("Введите день: ");
            dateTime = dateTime.AddDays(GetInt());
            Console.Write("Введите час: ");
            dateTime = dateTime.AddHours(GetInt());
            Console.Write("Введите минуту: ");
            dateTime = dateTime.AddMinutes(GetInt());
            return dateTime;
        }
        static public Meeting GetMeeting()
        {
            DateTime beginTime = new DateTime();
            DateTime endTime = new DateTime();
            TimeSpan notificationTime = new TimeSpan();

            Console.WriteLine("Время начала встречи");
            beginTime = GetDateTime();
            Console.WriteLine();
            Console.WriteLine("Время конца встречи");
            endTime = GetDateTime();
            Console.WriteLine();
            Console.WriteLine("Введите время за которое вас нужно предупредить");
            notificationTime = GetTimeSpan();
            return new Meeting(beginTime, endTime, notificationTime);
        }
    }
}
