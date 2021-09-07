using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз_29._06._21.Classes;
namespace дз_29._06._21.Classes
{
    class NotificationChecker
    {
        //DateTime _lastCheck = DateTime.Now;
        DailyPlanner _dailyPlanner;
        List<Meeting> _notificatedMeetings = new List<Meeting>();

        public NotificationChecker(DailyPlanner dailyPlanner)
        {
            _dailyPlanner = dailyPlanner;
        }

        public async void StartChecking()
        {
            while (true)
            {
                foreach (var meeting in _dailyPlanner.Meetings)
                {
                    if (!(_notificatedMeetings.Any(_ => _ == meeting)))
                    {
                        if (Meeting.IsDateLess(meeting.BeginTime - meeting.NotificationTime, DateTime.Now))
                        {
                            Console.Write("\a");
                            _notificatedMeetings.Add(meeting);
                        }
                    }
                }
                await Task.Delay(1000);
            }
        }

        

    }
}
