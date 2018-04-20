using System;
using System.Collections.Generic;

namespace CourseScheduleCalendar.Domain
{
    public class Semester
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Course> Courses { get; set; }

        public Semester()
        {
            Courses = new List<Course>();
        }
    }
}