using CourseScheduleCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using CourseScheduleCalendar.Models;
using System.Threading.Tasks;

namespace CourseScheduleCalendar.Services
{
    public interface IModelToDomainService
    {
        Task<Semester> TransformModelToSemesterDomainAsync(SemesterViewModel semesterViewModel); 
    }
}
