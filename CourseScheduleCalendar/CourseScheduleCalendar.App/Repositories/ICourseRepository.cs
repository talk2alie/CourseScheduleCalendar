using CourseScheduleCalendar.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduleCalendar.App.Repositories
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);

        void UpdateCourse(Course course);

        Task<Course> GetCourseAsync(int courseId);

        Task<Course> GetCourseAsync(string courseName);

        Task AddSectionForCourseAsync(int courseId, Section section);

        Task AddSectionForCourseAsync(string courseName, Section section);

        Task<IEnumerable<Section>> GetSectionsForCourseAsync(int courseId);

        Task<IEnumerable<Section>> GetSectionsForCourseAsync(string courseName);

        Task CommitChangesAsync();
    }
}
