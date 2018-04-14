using CourseScheduleCalendar.App.Data;
using CourseScheduleCalendar.App.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CourseScheduleCalendar.Tests.Repositories
{
    public  class SemesterRepositoryTests
    {
        private readonly CourseScheduleDbContext _courseScheduleDbContext;
        private readonly ISemesterRepository _semesterRepository;

        public SemesterRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _courseScheduleDbContext = new CourseScheduleDbContext(optionsBuilder.Options);
            _courseScheduleDbContext.Database.EnsureDeleted();

            _semesterRepository = new SemesterRepository(_courseScheduleDbContext);
        }

        [Fact, Trait("Category", "SemesterRepository")]
        public async Task AddSemester_Semester_IncreaseSemestersCountByOne()
        {
            // Arrange
            var semester = new Semester
            {
                Description = "Programming for All",
                Name = "CSC 1010",
            };

            const int addedSemestersCount = 1;
            int expectedSemestersCount = await _courseScheduleDbContext.Semesters.CountAsync() + addedSemestersCount;

            // Act
            _semesterRepository.AddSemester(semester);
            await _semesterRepository.CommitChangesAsync();

            // Assert
            int actualSemestersCount = await _courseScheduleDbContext.Semesters.CountAsync();

            Assert.Equal(expectedSemestersCount, actualSemestersCount);
        }
    }
}
