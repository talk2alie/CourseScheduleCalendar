﻿// <auto-generated />
using CourseScheduleCalendar.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CourseScheduleCalendar.App.Migrations
{
    [DbContext(typeof(CourseScheduleDbContext))]
    partial class CourseScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AttributeId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<int>("SectionId");

                    b.HasKey("Id")
                        .HasName("PK_Attribute_AttributeId");

                    b.HasIndex("SectionId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CourseId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_Course_CourseId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UNQ_Course_Name");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InstructorId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_Instructor_InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ScheduleId");

                    b.Property<int>("Days");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("time(7)");

                    b.Property<string>("Location");

                    b.Property<int>("SectionId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("time(7)");

                    b.HasKey("Id")
                        .HasName("PK_Schedule_ScheduleId");

                    b.HasIndex("SectionId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SectionId");

                    b.Property<string>("Comment")
                        .HasMaxLength(512);

                    b.Property<int>("CourseId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("SemesterId");

                    b.HasKey("Id")
                        .HasName("PK_Section_SectionId");

                    b.HasIndex("CourseId");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasName("UNQ_Section_Number");

                    b.HasIndex("SemesterId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.SectionInstructor", b =>
                {
                    b.Property<int>("InstructorId");

                    b.Property<int>("SectionId");

                    b.HasKey("InstructorId", "SectionId")
                        .HasName("PK_Section_Instructor");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionInstructor");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SemesterId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_Semester_SemesterId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UNQ_Semester_Name");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Attribute", b =>
                {
                    b.HasOne("CourseScheduleCalendar.App.Data.Section", "Section")
                        .WithMany("Attributes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Schedule", b =>
                {
                    b.HasOne("CourseScheduleCalendar.App.Data.Section", "Section")
                        .WithMany("Schedules")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.Section", b =>
                {
                    b.HasOne("CourseScheduleCalendar.App.Data.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseScheduleCalendar.App.Data.Semester", "Semester")
                        .WithMany("Sections")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseScheduleCalendar.App.Data.SectionInstructor", b =>
                {
                    b.HasOne("CourseScheduleCalendar.App.Data.Instructor", "Instructor")
                        .WithMany("SectionInstructors")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseScheduleCalendar.App.Data.Section", "Section")
                        .WithMany("SectionInstructors")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
