namespace CourseScheduleCalendar.Data
{
    public class SectionInstructor
    {
        public int SectionId { get; set; }

        public Section Section { get; set; }

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
    }
}