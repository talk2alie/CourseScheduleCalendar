using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseScheduleCalendar.App.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseScheduleCalendar.App.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly CourseScheduleDbContext _courseSchedulerDbContext;

        public SemesterRepository(CourseScheduleDbContext courseScheduleDbContext)
        {
            _courseSchedulerDbContext = courseScheduleDbContext;
        }

        public void AddOfferedSectionForSemester(int semesterId, Section offeredSection)
        {
            if(offeredSection.SemesterId == 0)
            {
                offeredSection.SemesterId = semesterId;
            }
            _courseSchedulerDbContext.Sections.Add(offeredSection);
        }

        public Task AddOfferedSectionForSemesterAsync(string semesterName, Section offeredSection)
        {
            return _courseSchedulerDbContext.Semesters.FindAsync(semesterName)
                .ContinueWith(previousTask =>
                {
                    Semester semester = previousTask.Result;
                    semester.Sections.Add(offeredSection);
                });
        }

        public void AddSemester(Semester semester)
        {

            _courseSchedulerDbContext.Semesters.Add(semester);
        }

        public Task<IEnumerable<Section>> GetOfferedSectionsForSemesterAsync(int semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Section>> GetOfferedSectionsForSemesterAsync(string semesterName)
        {
            throw new NotImplementedException();
        }

        public Task<Semester> GetSemesterAsync(int semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<Semester> GetSemesterAsync(string semesterName)
        {
            throw new NotImplementedException();
        }

        public void UpdateSemester(Semester semester)
        {
            throw new NotImplementedException();
        }

        public Task CommitChangesAsync()
        {
            return _courseSchedulerDbContext.SaveChangesAsync();
        }
    }
}
