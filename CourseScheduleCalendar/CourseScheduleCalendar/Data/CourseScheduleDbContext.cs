using Microsoft.EntityFrameworkCore;

namespace CourseScheduleCalendar.Data
{
    public class CourseScheduleDbContext : DbContext
    {
        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public CourseScheduleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>(attribute =>
            {
                attribute.HasKey(entity => entity.Id)
                    .HasName("PK_Attribute_AttributeId");
                attribute.Property(entity => entity.Id)
                    .HasColumnName("AttributeId");
                attribute.Property(entity => entity.Description)
                    .HasMaxLength(512)
                    .IsRequired();
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(entity => entity.Id)
                    .HasName("PK_Course_CourseId");
                course.Property(entity => entity.Id)
                    .HasColumnName("CourseId");
                course.Property(entity => entity.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                course.Property(entity => entity.Description)
                    .HasMaxLength(255)
                    .IsRequired();
                course.HasIndex(entity => entity.Name)
                    .HasName("UNQ_Course_Name")
                    .IsUnique();
                course.HasMany(entity => entity.Sections)
                    .WithOne(section => section.Course);
            });

            modelBuilder.Entity<Instructor>(instructor =>
            {
                instructor.HasKey(entity => entity.Id)
                    .HasName("PK_Instructor_InstructorId");
                instructor.Property(entity => entity.Id)
                    .HasColumnName("InstructorId");
                instructor.Property(entity => entity.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();
                instructor.Property(entity => entity.MiddleName)
                    .HasMaxLength(50);
                instructor.Property(entity => entity.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                instructor.HasMany(entity => entity.SectionInstructors)
                    .WithOne(sectionInstructor => sectionInstructor.Instructor);
            });

            modelBuilder.Entity<Schedule>(schedule =>
            {
                schedule.HasKey(entity => entity.Id)
                    .HasName("PK_Schedule_ScheduleId");
                schedule.Property(entity => entity.Id)
                    .HasColumnName("ScheduleId");
                schedule.Property(entity => entity.EndTime)
                    .IsRequired()
                    .HasColumnType("time(7)");
                schedule.Property(entity => entity.StartTime)
                    .IsRequired()
                    .HasColumnType("time(7)");
                schedule.Property(entity => entity.Location)
                    .IsRequired();
                schedule.Property(entity => entity.Days)
                    .IsRequired();
            });

            modelBuilder.Entity<Section>(section =>
            {
                section.HasKey(entity => entity.Id)
                    .HasName("PK_Section_SectionId");
                section.Property(entity => entity.Id)
                    .HasColumnName("SectionId");
                section.HasIndex(entity => entity.Number)
                    .HasName("UNQ_Section_Number")
                    .IsUnique();
                section.Property(entity => entity.Number)
                    .HasMaxLength(10)
                    .IsRequired();
                section.Property(entity => entity.Comment)
                    .HasMaxLength(512);
                section.HasMany(entity => entity.Attributes)
                    .WithOne(attribute => attribute.Section);
                section.HasMany(entity => entity.Schedules)
                    .WithOne(schedule => schedule.Section);
                section.HasMany(entity => entity.SectionInstructors)
                    .WithOne(sectionInstructor => sectionInstructor.Section);
            });

            modelBuilder.Entity<SectionInstructor>()
                .HasKey(sectionIntructor => new { sectionIntructor.InstructorId, sectionIntructor.SectionId })
                .HasName("PK_Section_Instructor");

            modelBuilder.Entity<Semester>(semester =>
            {
                semester.HasKey(entity => entity.Id)
                    .HasName("PK_Semester_SemesterId");
                semester.Property(entity => entity.Id)
                    .HasColumnName("SemesterId");
                semester.Property(entity => entity.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                semester.Property(entity => entity.Description)
                    .HasMaxLength(255);
                semester.HasIndex(entity => entity.Name)
                    .IsUnique()
                    .HasName("UNQ_Semester_Name");
                semester.HasMany(entity => entity.Sections)
                    .WithOne(section => section.Semester);
            });
        }
    }
}