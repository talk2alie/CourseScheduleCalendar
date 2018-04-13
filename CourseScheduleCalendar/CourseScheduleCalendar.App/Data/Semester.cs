using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduleCalendar.App.Data
{
    public class Semester
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Section> Sections { get; set; }

        public Semester()
        {
            Sections = new HashSet<Section>();
        }
    }
}
