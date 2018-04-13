using System.Collections.Generic;

namespace CourseScheduleCalendar.App.Data
{
    public class Instructor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ICollection<SectionInstructor> SectionInstructors { get; set; }

        public Instructor()
        {
            SectionInstructors = new HashSet<SectionInstructor>();
        }
    }
}