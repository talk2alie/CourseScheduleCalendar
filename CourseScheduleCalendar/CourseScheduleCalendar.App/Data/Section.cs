using System.Collections;
using System.Collections.Generic;

namespace CourseScheduleCalendar.App.Data
{
    public class Section
    {
        public int Id { get; set; }

        public int SemesterId { get; set; }

        public Semester Semester { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string Number { get; set; }

        public string Comment { get; set; }

        public ICollection<Attribute> Attributes { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ICollection<SectionInstructor> SectionInstructors { get; set; }

        public Section()
        {
            Attributes = new HashSet<Attribute>();
            Schedules = new HashSet<Schedule>();
            SectionInstructors = new HashSet<SectionInstructor>();
        }
    }
}