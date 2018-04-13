using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduleCalendar.App.Data
{
    public class CourseScheduleDbContext : DbContext
    {
        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public CourseScheduleDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>()
                .HasKey(attribute => attribute.Id)
                .HasName("AttributeId");

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(entity => entity.Id).HasName("CourseId");
                course.Property(entity => entity.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                course.HasIndex(entity => entity.Name)
                    .HasName("UNQ_Course_Name")
                    .IsUnique();
                course.Property(entity => entity.Description)
                    .IsRequired();
                course.HasMany(entity => entity.Sections)
                    .WithOne(section => section.Course);
            });

            modelBuilder.Entity<Instructor>(instructor =>
            {
                instructor.HasKey(entity => entity.Id).HasName("InstructorId");
                instructor.Property(entity => entity.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();
                instructor.Property(entity => entity.MiddleName)
                    .HasMaxLength(50);
                instructor.Property(entity => entity.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Schedule>(schedule =>
            {
                schedule.HasKey(entity => entity.Id).HasName("ScheduleId");
                schedule.Property(entity => entity.EndTime)
                    .IsRequired()
                    .HasColumnType("time(7)");
                schedule.Property(entity => entity.StartTime)
                    .IsRequired()
                    .HasColumnType("time(7)");
                schedule.Property(entity => entity.Days)
                    .IsRequired();
            });
        }
    }
}
