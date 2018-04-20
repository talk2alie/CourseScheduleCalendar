namespace CourseScheduleCalendar.Data
{
    public class Attribute
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public string Description { get; set; }
    }
}