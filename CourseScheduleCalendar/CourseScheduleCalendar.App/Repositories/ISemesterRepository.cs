using CourseScheduleCalendar.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduleCalendar.App.Repositories
{
    public interface ISemesterRepository
    {
        void AddSemester(Semester semester);

        void UpdateSemester(Semester semester);

        Task<Semester> GetSemesterAsync(int semesterId);

        Task<Semester> GetSemesterAsync(string semesterName);

        void AddOfferedSectionForSemester(int semesterId, Section offeredSection);

        Task AddOfferedSectionForSemesterAsync(string semesterName, Section offeredSection);

        Task<IEnumerable<Section>> GetOfferedSectionsForSemesterAsync(int semesterId);

        Task<IEnumerable<Section>> GetOfferedSectionsForSemesterAsync(string semesterName);

        Task CommitChangesAsync();
    }
}
