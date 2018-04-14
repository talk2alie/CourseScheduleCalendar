using System;

namespace CourseScheduleCalendar.App.Data
{
    public class Schedule
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public DaysOfWeek Days { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }
    }
}