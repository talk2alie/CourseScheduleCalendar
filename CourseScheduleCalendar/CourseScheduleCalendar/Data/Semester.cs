using System;
using System.Collections.Generic;

namespace CourseScheduleCalendar.Data
{
    public class Semester
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<Section> Sections { get; set; }

        public Semester()
        {
            Sections = new HashSet<Section>();
        }
    }
}