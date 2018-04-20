using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseScheduleCalendar.Domain;
using CourseScheduleCalendar.Models;

namespace CourseScheduleCalendar.Services
{
    public class CourseScheduleMappingService : ICourseScheduleMappingService
    {
        private readonly IMapper _mapper;

        public Task<Semester> MapViewModelToSemesterDomain(SemesterViewModel semesterViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
