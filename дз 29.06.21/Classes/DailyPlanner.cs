using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз_29._06._21.Classes;

namespace дз_29._06._21.Classes
{
    class DailyPlanner
    {
        private List<Meeting> _meetings = new List<Meeting>();

        internal IReadOnlyList<Meeting> Meetings { get => _meetings.AsReadOnly();}

        public bool AddMeeting(Meeting newMeeting)
        {
            if (!newMeeting.IsCorrect)
                return false;

            foreach (var meeting in _meetings)
            {
                if (DoMeetingIntersect(meeting, newMeeting))
                    return false;
            }
            _meetings.Add(newMeeting);
            return true;
        }
        public void DeleteMeeting(Meeting meetingToDelete)
        {
            _meetings.Remove(meetingToDelete);
        }
        public void ChangeMeeting(Meeting oldMeeting, Meeting newMeeting)
        {

            oldMeeting.ChangeMeeting(newMeeting.BeginTime, newMeeting.EndTime, newMeeting.NotificationTime);
            Console.WriteLine("Элемент с таким индексом не был найден");
        }

        private static bool DoMeetingIntersect(Meeting meetingA, Meeting meetingB)
        {
            

            if (meetingB.BeginTime >= meetingA.BeginTime && meetingB.BeginTime <= meetingA.EndTime)
                return true;
            else if (meetingB.EndTime >= meetingA.BeginTime && meetingB.EndTime <= meetingA.EndTime)
                return true;
            else 
                return false;
        }
    }
}
