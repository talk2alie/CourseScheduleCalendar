using System.Collections.Generic;

namespace CourseScheduleCalendar.Data
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

        public Course()
        {
            Sections = new HashSet<Section>();
        }
    }
}