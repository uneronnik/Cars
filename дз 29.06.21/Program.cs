/*Задание:
Разработать консольное приложение на C# .Net по описанию.
Для приложения написать план тестирования.
Исходные данные:
Необходимо разработать приложение для управления личными встречами.
Встреча – событие, которое планируется заранее, для которой всегда известно время начала и примерное время окончания.
Данные о встречах могут быть добавлены, изменены и удалены. Встречи всегда планируются только на будущее время. При этом встречи не должны пересекаться друг с другом.
Также для встречи может быть настроено время, за которое нужно уведомить пользователя о предстоящей встрече. Время напоминания также может быть изменено после создания встречи. При наступлении времени напоминания приложение информирует пользователя о предстоящей встрече и времени ее начала.
Пользователь может посмотреть расписание своих встреч на любой день, в том числе и прошедший.
Помимо просмотра он может с помощью приложения экспортировать расписание встреч за выбранный день в текстовый файл.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз_29._06._21.Classes;


namespace дз_29._06._21
{
    
    class Program
    {
        public static bool IsInteger(string str)
        {
            foreach(var ch in str)
                if (ch < '0' || ch > '9')
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            
            


            DailyPlanner planner = new DailyPlanner();
            NotificationChecker notificationChecker = new NotificationChecker(planner);

            DateTime beginTime = new DateTime(2021, 10, 6, 20, 50, 25); // 20.07.2015 18:30:25
            DateTime endTime = new DateTime(2022, 7, 20, 20, 30, 25); // 20.07.2016 15:30:25

            planner.AddMeeting(new Meeting(beginTime, endTime));
            

            //DateTime newBeginTime = new DateTime(2022, 7, 21, 18, 30, 25); // 21.07.2015 18:30:25
            //DateTime newEndTime = new DateTime(2022, 7, 21, 20, 30, 25); // 21.07.2016 15:30:25


            UI ui = new UI(planner);
            notificationChecker.StartChecking();
            while (true)
            {
                ui.ShowMainPage();
            }

            Console.ReadKey();


        }
    }
}
