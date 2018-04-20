
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseScheduleCalendar.Models
{
    public class SemesterViewModel
    {
        [Required, MaxLength(12)]
        public string SemesterName { get; set; }

        public DateTime SemesterEndDate { get; set; }

        public DateTime SemesterStartDate { get; set; }

        public IFormFile SemesterScheduleDataFile { get; set; }
    }
}
