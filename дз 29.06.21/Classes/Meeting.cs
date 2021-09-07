using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace дз_29._06._21.Classes
{
    class Meeting // Встреча
    {
        private DateTime _beginTime; // Время и дата начала встречи
        private DateTime _endTime;   // Время и дата конца встречи
        private TimeSpan _notificationTime = new TimeSpan(1, 0, 0); // Время за которое нужно предупредить о встрече
        private string _description = null;
        bool _isCorrect = true;

        public bool IsCorrect { get => _isCorrect; }
        public TimeSpan NotificationTime { 
            get => _notificationTime;
            set
            {
                if (!(value < new TimeSpan()))
                    _notificationTime = value;
            }
        
        }

        public DateTime BeginTime { get => _beginTime; }
        public DateTime EndTime { get => _endTime; }
        public string Description { get => _description; }

        public void ChangeMeeting(DateTime beginTime, DateTime endTime, TimeSpan notificationTime, string description = null)
        {
            Meeting newMeeting = new Meeting(beginTime, endTime); // Создаю новую встречу, чтобы не писать заново проверки правильности
            if (newMeeting.IsCorrect)
            {
                _beginTime = newMeeting.BeginTime;
                _endTime = newMeeting.EndTime;
                _notificationTime = newMeeting._notificationTime;
                _description = description;
            }
        }

        public void Show()
        {
            Console.WriteLine($"Начало: {_beginTime}");
            Console.WriteLine($"Конец: {_endTime}");
            if(_description != null)
                Console.WriteLine(_description);
        }


        public Meeting(DateTime beginTime, DateTime endTime, TimeSpan notificationTime = new TimeSpan())
        {
            if (IsDateLess(endTime, beginTime) || IsDateLess(beginTime, DateTime.Now)) // Если начало позже конца или время начало позже, чем время сейчас, то встреча не корректна 
            {
                _isCorrect = false;
                return;
            }
            _beginTime = beginTime;
            _endTime = endTime;
            if (notificationTime != new TimeSpan()) // Если пользователь вводил время уведомления
            {
                if (notificationTime < new TimeSpan())// Если пользователь ввёл отрицательное время уведомления
                    Console.WriteLine("Время за которое нужно предупредить не может быть отрицателным, поэтому вас предупредят за час до встречи. Вы можете изменить это время в любой момент");
                else
                    _notificationTime = notificationTime;
            }
        }
        
        public static bool IsDateLess(DateTime dateTime1, DateTime dateTime2)
        {
            if (dateTime1.Subtract(dateTime2) < new TimeSpan())
                return true;
            return false;
        }
    }
}
