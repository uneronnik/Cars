using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз_29._06._21.Classes;
using static дз_29._06._21.Program;
namespace дз_29._06._21.Classes
{
    class UI
    {


        DailyPlanner _dailyPlanner = new DailyPlanner();
        Meeting _targetMeeting = null;

        internal Meeting TargetMeeting { get => _targetMeeting; }

        private void ShowMeetings()
        {
            int index = 0;
            foreach(var meeting in _dailyPlanner.Meetings)
            {
                Console.WriteLine($"Встреча №{index + 1}");
                meeting.Show();
                index++;
                Console.WriteLine();
            }
        }

        public void ShowMainPage()
        {
            ResetTarget();
            ShowMeetings();
            Console.WriteLine("1 - Добавить встречу");
            Console.WriteLine("2 - Изменить или удалить встречу");
            Console.Write("Введите свой выбор: ");
            switch(UserInput.GetChoice(1, 2))
            {
                case 1:
                    Console.Clear();
                    AddMeeting();
                    break;

                case 2:
                    Console.Clear();
                    ShowMeetings();

                    ChooseTargetMeeting();

                    Console.Clear();
                    _targetMeeting.Show();

                    Console.WriteLine("1 - Изменить");
                    Console.WriteLine("2 - Удалить");
                    switch(UserInput.GetChoice(1, 2))
                    {
                        case 1:
                            Console.Clear();
                            ChangeTargetMeeting();
                            break;

                        case 2:
                            Console.Clear();
                            DeleteTargetMeeting();
                            break;
                    }
                    break;
            }
        }
        private void ChangeTargetMeeting()
        {
            Console.WriteLine("Введите новую встречу: ");
            Meeting newMeeting = UserInput.GetMeeting();
            Console.Write("Введите описание встречи: ");
            string description = Console.ReadLine();
            newMeeting.ChangeMeeting(newMeeting.BeginTime, newMeeting.EndTime, newMeeting.NotificationTime, description);
            _dailyPlanner.ChangeMeeting(_targetMeeting, newMeeting);
        }
        private void DeleteTargetMeeting()
        {
            _dailyPlanner.DeleteMeeting(_targetMeeting);
        }
        private void AddMeeting()
        {
            Meeting meetingToAdd = UserInput.GetMeeting();
            Console.Write("Введите описание встречи: ");
            string description = Console.ReadLine();
            meetingToAdd.ChangeMeeting(meetingToAdd.BeginTime, meetingToAdd.EndTime, meetingToAdd.NotificationTime, description);
            _dailyPlanner.AddMeeting(meetingToAdd);
        }

        private void ChooseTargetMeeting()
        {
            Console.WriteLine("Введите номер встречи которую хотите изменить: ");
            int indexOfTargetMeeting = UserInput.GetChoice(1, _dailyPlanner.Meetings.Count) - 1;
            int currentIndex = 0;
            foreach (var meeting in _dailyPlanner.Meetings)
            {
                if (indexOfTargetMeeting == currentIndex)
                    _targetMeeting = meeting;
                currentIndex++;
            }
        }

        public void ResetTarget()
        {
            _targetMeeting = null;
        }

        public UI(DailyPlanner dailyPlanner)
        {
            _dailyPlanner = dailyPlanner;
        }
        public UI(){ }
    }
}
